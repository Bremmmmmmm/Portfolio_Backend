using Fleck;

namespace Interface.Interfaces.Logic;

public interface IWebSocketHandler
{
    void AddSocket(IWebSocketConnection socket);
    void RemoveSocket(IWebSocketConnection socket);
    void SendMessageToAll(string message);
    List<IWebSocketConnection> GetSockets();
}