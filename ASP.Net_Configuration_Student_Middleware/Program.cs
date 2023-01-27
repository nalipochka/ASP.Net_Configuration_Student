using ASP.Net_Configuration_Student.Models;
using ASP.Net_Configuration_Student_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("student.json").AddXmlFile("academy.xml");

builder.Services.Configure<Student>(builder.Configuration.GetSection("student"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Map("/info", (app) =>
{
    app.UseMiddleware<ProfileMiddleware>();
});

app.Map("/academy", (app) =>
{
    app.UseMiddleware<AcademyMiddleware>();
});

app.Run();
