using System.Text;

namespace lab001;

internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        
        #region task1
        
        app.MapGet("/{name}.ddd", context =>{
            var paramA = context.Request.Query["ParmA"];
            var paramB = context.Request.Query["ParmB"];;

            var response = $"GET-Http-XYZ:ParmA = {paramA},ParmB = {paramB}";
            
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });
        #endregion
        
        #region task2
        
        app.MapPost("/{name}.ddd", context =>{
            var paramA = context.Request.Query["ParmA"];
            var paramB = context.Request.Query["ParmB"];;
            
            var response = $"POST-Http-XYZ:ParmA = {paramA},ParmB = {paramB}";
            
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });
        #endregion
        
        #region task3
        
        app.MapPut("/{name}.ddd", context =>{
            var paramA = context.Request.Query["ParmA"];
            var paramB = context.Request.Query["ParmB"];;
            
            var response = $"PUT-Http-XYZ:ParmA = {paramA},ParmB = {paramB}";
            
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(response);
        });
        #endregion
        
        #region task4
        
        app.MapPost("/{name}.sum", async context =>{
            var paramX = context.Request.Form["X"];
            var paramY = context.Request.Form["Y"];

            if (int.TryParse(paramX, out var x) && int.TryParse(paramY, out var y))
            {
                var responseText = (x + y).ToString();

                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync(responseText);
            }
            else
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid parameters");
            }
        });
        
        
        #endregion

        #region task5
        
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

        
        app.MapPost("/{name}.task5", async context =>{
            var x = Convert.ToInt32(context.Request.Form["x"]);
            var y = Convert.ToInt32(context.Request.Form["y"]);
            var result = x * y;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(result.ToString());
        });
        #endregion
        
        #region task6
        
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

        
        app.MapPost("/{name}.task6", async context =>{
            var x = Convert.ToInt32(context.Request.Form["x"]);
            var y = Convert.ToInt32(context.Request.Form["y"]);
            var result = x * y;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(result.ToString());
        });
        #endregion
        
        app.Run();
    }
}