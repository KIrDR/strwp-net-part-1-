internal class Program
{
    private static void Main(string[] args)
    {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddControllers();
                var app = builder.Build();
                var webSocketOptions = new WebSocketOptions
                {
                    KeepAliveInterval = TimeSpan.FromMinutes(2)
                };
                app.UseWebSockets(webSocketOptions);
                app.UseDefaultFiles(new DefaultFilesOptions
                {
                    DefaultFileNames = new List<string> { "Laba1b.html" }
                });
                app.UseStaticFiles();
                app.MapControllers();
                app.Run();

    }
}