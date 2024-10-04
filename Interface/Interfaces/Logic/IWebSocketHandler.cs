using Fleck;

namespace Interface.Interfaces.Logic;

public interface IWebSocketHandler
{
    void AddSocket(IWebSocketConnection socket);
    void RemoveSocket(IWebSocketConnection socket);
}