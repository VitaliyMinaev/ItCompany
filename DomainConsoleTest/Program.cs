// See https://aka.ms/new-console-template for more information

using Domain.Client;
using Domain.Company;
using Domain.Company.Abstract;
using DomainConsoleTest.Logger;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

var programLogger = loggerFactory.CreateLogger<Program>();
var logger = loggerFactory.CreateLogger<LoggerAdapter>();
var adapter = new LoggerAdapter(logger);

var company = new Company(Guid.NewGuid(), "New company");
var department1 = new Department(Guid.NewGuid(), "Department #1", new List<BaseEmployeeCommand>()
{
    new EmployeeCommand(Guid.NewGuid(), Random.Shared.Next(4, 7)),
    new EmployeeCommand(Guid.NewGuid(), Random.Shared.Next(4, 7)),
    new EmployeeCommand(Guid.NewGuid(), Random.Shared.Next(4, 7))
});
department1.SetLogger(adapter);
company.AddDepartment(department1);

var clientProj = new ClientProject(Guid.NewGuid(), "Project #1",
    3400, DateOnly.FromDateTime(DateTime.Now.AddMonths(2)));
var client = new Client(company, Guid.NewGuid(), "Test user #1");

var thread = new Thread(() =>
{
    var result = client.OrderProject(clientProj);
    if (result == true)
    {
        programLogger.LogInformation("Project has been ordered!");
    }
    else
    {
        programLogger.LogCritical("Project has not been ordered!");
    }
});

thread.Start();
programLogger.LogInformation("Going away ...");
Console.ReadKey();
