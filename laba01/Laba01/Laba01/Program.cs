using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //1 

        app.MapGet("/{name}.DKA", context => {
            var paramA = context.Request.Query["ParmA"];
            var paramB = context.Request.Query["ParmB"]; ;

            var response = $"GET-Http-DKA:ParmA = {paramA},ParmB = {paramB}";

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });

        //2

        app.MapPost("/{name}/post.DKA", context => {
            var paramA = context.Request.Query["ParmAa"];
            var paramB = context.Request.Query["ParmBb"]; ;

            var response = $"POST-Http-ZXC:ParmAa = {paramA},ParmBb = {paramB}";

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });
            
        // 3

        app.MapPut("/{name}/put.DKA", context => {
            var paramA = context.Request.Query["ParmAa"];
            var paramB = context.Request.Query["ParmBb"]; ;

            var response = $"PUT-Http-XYZ:ParmAa = {paramA},ParmBb = {paramB}";

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });


        //4

        app.MapPost("/{name}/calc",async context => {
            var paramX = context.Request.Form["X"];
            var paramY = context.Request.Form["Y"];

            if (int.TryParse(paramX, out var x) && int.TryParse(paramY, out var y))
            {
                var result = x + y; 

                var responseText = result.ToString();
                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync(responseText);
            }
            else
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid parameters");
            }

        });


        //5 

        app.MapGet("/{name}.task5", context =>
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Task5.html");

            if (File.Exists(filePath))
            {
                context.Response.ContentType = "text/html";
                return context.Response.SendFileAsync(filePath);
            }

            context.Response.StatusCode = 404;
            return Task.CompletedTask;
        });


        app.MapPost("/{name}.task5", async context => {
            var x = Convert.ToInt32(context.Request.Form["x"]);
            var y = Convert.ToInt32(context.Request.Form["y"]);
            var result = x * y;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(result.ToString());
        });

        //6

        app.MapGet("/{name}.task6", context =>
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Task6.html");

            if (File.Exists(filePath))
            {
                context.Response.ContentType = "text/html";
                return context.Response.SendFileAsync(filePath);
            }

            context.Response.StatusCode = 404;
            return Task.CompletedTask;
        });


        app.MapPost("/{name}.task6", async context => {
            var x = Convert.ToInt32(context.Request.Form["x"]);
            var y = Convert.ToInt32(context.Request.Form["y"]);
            var result = x * y;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(result.ToString());
        });

        app.Run();  
    }
}