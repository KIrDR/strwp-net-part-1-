﻿using System.Net;
using System.Net.WebSockets;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();



        app.UseStaticFiles();
        app.UseWebSockets();

        app.MapGet("/", (HttpContext context) =>
        {
            string path = "C:\\MyStudy\\3курс1семестр\\СТР - Смелов\\2\\nextTry\\nextTry\\laba1b.html";
            context.Response.ContentType = "text/html";
            return context.Response.SendFileAsync(path);
        });

        app.MapGet("/websocket", async (HttpContext context) =>
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await WebSocketRequest(webSocket);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        });
        async Task WebSocketRequest(WebSocket webSocket)
        {
            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var message = DateTime.Now.ToString("HH:mm:ss");
                    var buffer = Encoding.UTF8.GetBytes(message);
                    var segment = new ArraySegment<byte>(buffer);

                    await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);

                    await Task.Delay(2000);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                var buffer = Encoding.UTF8.GetBytes(message);
                var segment = new ArraySegment<byte>(buffer);
                await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        app.Run();
    }
}