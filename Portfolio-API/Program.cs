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


var server = new WebSocketServer("ws://127.0.0.1:8080");
server.Start(socket =>
{
    socket.OnOpen = () =>
    {
        Console.WriteLine("WebSocket Opened");
        webSocketManager.AddSocket(socket);
    };
    socket.OnClose = () =>
    {
        Console.WriteLine("WebSocket Closed");
        webSocketManager.RemoveSocket(socket);
    };
});

app.Run();