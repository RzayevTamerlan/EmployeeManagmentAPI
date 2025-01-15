using System.Text;
using EmployeeAPI.Business;
using EmployeeAPI.Business.Exceptions;
using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT"
                },
                Scheme = "bearer",
                Name = "JWT",
                In = ParameterLocation.Header,
            },
            new string[] { }
        }
    });
});


// 1. Настройка JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<EmployeeAPIDbContext>()
    .AddDefaultTokenProviders();

// 2. Регистрация DbContext
builder.Services.AddDbContext<EmployeeAPIDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseNpgsql(connectionString); // Используем PostgreSQL
});

// 3. Регистрация DAL сервисов
builder.Services.AddDALServices();

// 4. Регистрация сервисов
builder.Services.AddBusinessServices();

var app = builder.Build();

// Инициализация данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.GetRequiredService<UserManager<Employee>>();
    services.GetRequiredService<RoleManager<IdentityRole>>();
    services.GetRequiredService<EmployeeAPIDbContext>();
    
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        // Вызываем метод seeding
        await DataSeeder.SeedDataAsync(app, services);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionFeature?.Error is BaseHttpException baseHttpException)
        {
            context.Response.StatusCode = (int)baseHttpException.StatusCode;

            var response = new
            {
                error = baseHttpException.Message,
                statusCode = baseHttpException.StatusCode
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response)).ConfigureAwait(false);
        }
        else if (exceptionFeature?.Error != null) // Для других исключений
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                error = "An unexpected error occurred.",
                statusCode = StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response)).ConfigureAwait(false);
        }
    });
});

app.MapControllers();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();