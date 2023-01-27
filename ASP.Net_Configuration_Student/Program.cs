using ASP.Net_Configuration_Student.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("student.json").AddXmlFile("academy.xml");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Map("/info", async (IConfiguration appConfig, HttpContext context) =>
{
    string color = appConfig["color"];
    Student student = appConfig.GetSection("student").Get<Student>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<h1 style ='color: {color};'>Firstname: {student?.Profile?.Firstname}; Surname: {student?.Profile?.Surname}; Age: {student?.Profile?.Age}</h1>");

});

app.Map("/academy", async (IConfiguration appConfig, HttpContext context) =>
{
    string color = appConfig["color"];
    var subjects = appConfig.GetSection("student:Academy:Subjects");
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Subjects:");
    sb.AppendLine($"<ul style = 'color: {color};'>");
    foreach (var subject in subjects.GetChildren())
    {
        sb.AppendLine($"<li>{subject.Value}</li>");
    }
    sb.AppendLine("</ul>");
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"{sb.ToString()}");
});

app.Run();
