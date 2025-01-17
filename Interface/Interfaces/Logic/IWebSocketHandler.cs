using Fleck;

namespace Interface.Interfaces.Logic;

public interface IWebSocketHandler
{
    void SendMessageToAll(string message);
    void AssignUserToSocket(IWebSocketConnection socket, string userId);
    void RemoveUserSocket(IWebSocketConnection socket, string userId);
    void sendMessageToAdmin(string message, string userId);
    void sendMessageToUser(string message, string userId);
}