using System.Collections.Concurrent;
using Fleck;
using Interface.Interfaces.Logic;

namespace Logic.Handlers;

public class WebSocketHandler : IWebSocketHandler
{
    private readonly ConcurrentDictionary<string, IWebSocketConnection> _userSockets = new();
    private readonly List<IWebSocketConnection> _sockets = [];
    
    public void SendMessageToAll(string message)
    {
        foreach (var s in _userSockets)
        {
            s.Value.Send(message);
        }
    }

    public void AssignUserToSocket(IWebSocketConnection socket, string userId)
    {
        _userSockets[userId] = socket;
    }

    public void RemoveUserSocket(IWebSocketConnection socket, string userId)
    {
        _userSockets.TryRemove(userId, out _);
    }

    public void sendMessageToAdmin(string message, string userId)
    {
        if (_userSockets.TryGetValue("admin", out var socket))
        {
            string formattedMessage = $"{userId}: {message}";
            socket.Send(formattedMessage);  // Assuming the admin has a dedicated socket to receive messages.
        }
        else
        {
            
            Console.WriteLine($"No socket found for user admin.");
        }
    }

    public void sendMessageToUser(string message, string userId)
    {
        if (_userSockets.TryGetValue(userId, out var socket))
        {
            string formattedMessage = $"Admin: {message}";
            socket.Send(formattedMessage);
        }
        else
        {
            Console.WriteLine($"No socket found for user admin.");
        }
    }

    public ConcurrentDictionary<string, IWebSocketConnection> GetSockets()
    {
        return _userSockets;
    }
}