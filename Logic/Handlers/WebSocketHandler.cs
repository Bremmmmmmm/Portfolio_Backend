using Fleck;
using Interface.Interfaces.Logic;

namespace Logic.Handlers;

public class WebSocketHandler : IWebSocketHandler
{
    private readonly List<IWebSocketConnection> _sockets;

    public WebSocketHandler()
    {
        _sockets = new List<IWebSocketConnection>();
    }

    public void AddSocket(IWebSocketConnection socket)
    {
        _sockets.Add(socket);
    }

    public void RemoveSocket(IWebSocketConnection socket)
    {
        _sockets.Remove(socket);
    }

    public void SendMessageToAll(string message)
    {
        foreach (var socket in _sockets)
        {
            socket.Send(message);
        }
    }
    public List<IWebSocketConnection> GetSockets()
    {
        return _sockets;
    }
}