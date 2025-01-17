using System.Collections;
using Logic.Handlers;
using Moq;
using Fleck;

namespace Tests.Handlers;

[TestClass]
public class WebSocketHandlerTest
{
    [TestMethod]
    public void AddSocket_SocketAddedToList()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket = new Mock<IWebSocketConnection>().Object;

        // Act
        handler.AssignUserToSocket(mockSocket, "TestUser");

        // Assert
        Console.WriteLine(handler.GetSockets());
        CollectionAssert.Contains((ICollection?)handler.GetSockets().Values, mockSocket);
    }

    [TestMethod]
    public void RemoveSocket_SocketRemovedFromList()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket = new Mock<IWebSocketConnection>().Object;
        handler.AssignUserToSocket(mockSocket, "TestUser");

        // Act
        handler.RemoveUserSocket(mockSocket, "TestUser");

        // Assert
        CollectionAssert.DoesNotContain(handler.GetSockets(), mockSocket);
    }

    [TestMethod]
    public void SendMessageToAll_AllSocketsReceiveMessage()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket1 = new Mock<IWebSocketConnection>();
        var mockSocket2 = new Mock<IWebSocketConnection>();
        const string message = "Test message";
        handler.AssignUserToSocket(mockSocket1.Object, "TestUser1");
        handler.AssignUserToSocket(mockSocket2.Object, "TestUser2");

        // Act
        handler.SendMessageToAll(message);

        // Assert
        mockSocket1.Verify(s => s.Send(message), Times.Once);
        mockSocket2.Verify(s => s.Send(message), Times.Once);
    }

    [TestMethod]
    public void SendMessageToAdmin()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket1 = new Mock<IWebSocketConnection>();
        const string message = "Test message";
        handler.AssignUserToSocket(mockSocket1.Object, "admin");
        
        // Act
        handler.sendMessageToAdmin(message, "TestUser1");
        
        // Assert
        mockSocket1.Verify(s => s.Send("TestUser1: Test message"), Times.Once);
    }

    [TestMethod]
    public void sendMessageToUser()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket1 = new Mock<IWebSocketConnection>();
        const string message = "Test message";
        handler.AssignUserToSocket(mockSocket1.Object, "TestUser1");
        
        // Act
        handler.sendMessageToUser(message, "TestUser1");
        
        // Assert
        mockSocket1.Verify(s => s.Send("Admin: Test message"), Times.Once);
    }
}