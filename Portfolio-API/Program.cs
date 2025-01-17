using DataAccess.Factories;
using Fleck;
using Interface.Config;
using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;
using Logic.Factories;
using Logic.Handlers;
using Portfolio_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin();
        corsPolicyBuilder.AllowAnyMethod();
        corsPolicyBuilder.AllowAnyHeader();
    });
});

//Dependency injection
builder.Services.AddSingleton<IConfigLoader, ConfigLoader>();
builder.Services.AddScoped<IDalFactory, DalFactory>();
builder.Services.AddScoped<ILogicFactoryBuilder, LogicFactoryBuilder>();

// Register WebSocketManager as a singleton
builder.Services.AddSingleton<IWebSocketHandler, WebSocketHandler>();

var app = builder.Build();

var webSocketManager = app.Services.GetRequiredService<IWebSocketHandler>();

app.UseWebSockets();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var server = new WebSocketServer("ws://127.0.0.1:8081");
server.Start(socket =>
{
    socket.OnOpen = () =>
    {
        // Extract the path and manually parse query parameters
        var path = socket.ConnectionInfo.Path; // Example: "/?user=admin"
        var user = ExtractQueryParameter(path, "user");

        if (user == "admin")
        {
            Console.WriteLine("Admin user connected.");
            webSocketManager.AssignUserToSocket(socket, user);
        }
        else
        {
            Console.WriteLine("Normal user connected.");
            webSocketManager.AssignUserToSocket(socket, user);
        }
    };

    socket.OnClose = () =>
    {
        var path = socket.ConnectionInfo.Path;
        var user = ExtractQueryParameter(path, "user");
        
        if (user == "admin")
        {
            webSocketManager.RemoveUserSocket(socket, user);
            Console.WriteLine("Admin user disconnected.");
        }
        else
        {
            webSocketManager.RemoveUserSocket(socket, user);
            Console.WriteLine("WebSocket Closed");
        }
    };
    
    string ExtractQueryParameter(string path, string key)
    {
        var queryStart = path.IndexOf("?");
        if (queryStart >= 0)
        {
            var query = path.Substring(queryStart + 1); // Remove "?"
            var pairs = query.Split('&');
            foreach (var pair in pairs)
            {
                var keyValue = pair.Split('=');
                if (keyValue.Length == 2 && keyValue[0] == key)
                {
                    return keyValue[1]; // Return value associated with the key
                }
            }
        }
        return null;
    }
});

app.Run();