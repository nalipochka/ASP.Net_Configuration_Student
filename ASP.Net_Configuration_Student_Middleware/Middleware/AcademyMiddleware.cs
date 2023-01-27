using ASP.Net_Configuration_Student.Models;
using Microsoft.Extensions.Options;
using System.Text;

namespace ASP.Net_Configuration_Student_Middleware.Middleware
{
    public class AcademyMiddleware
    {
        public AcademyMiddleware(RequestDelegate _) { }

        public async Task Invoke(HttpContext context, IOptions<Student> options, IConfiguration appConfig)
        {
            string color = appConfig["color"];
            Student student = options.Value;
            var subs = student?.Academy?.Subjects;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h2 style='color: {color};'>Subjects:</h2>");
            sb.AppendLine($"<ul style='font-size: 18px; color: {color};'>");
            foreach (var sub in subs!)
            {
                sb.AppendLine($"<li>{sub}</li>");
            }
            sb.AppendLine("</ul>");
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync( sb.ToString() );
        }
    }
}
