namespace EmployeeAPI.Business.Exceptions;

public class BaseHttpException : Exception
{
    public BaseHttpException(string errorMessage, int statusCode) : base(message: errorMessage)
    {
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public string ErrorMessage { get; set; }
    public int StatusCode { get; set; }
}