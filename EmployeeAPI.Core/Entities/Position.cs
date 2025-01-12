﻿namespace EmployeeAPI.Core.Entities;

public class Position : BaseEntity
{
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }
}