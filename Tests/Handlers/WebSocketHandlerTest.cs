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
        handler.AddSocket(mockSocket);

        // Assert
        CollectionAssert.Contains(handler.GetSockets(), mockSocket);
    }

    [TestMethod]
    public void RemoveSocket_SocketRemovedFromList()
    {
        // Arrange
        var handler = new WebSocketHandler();
        var mockSocket = new Mock<IWebSocketConnection>().Object;
        handler.AddSocket(mockSocket);

        // Act
        handler.RemoveSocket(mockSocket);

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
        var message = "Test message";
        handler.AddSocket(mockSocket1.Object);
        handler.AddSocket(mockSocket2.Object);

        // Act
        handler.SendMessageToAll(message);

        // Assert
        mockSocket1.Verify(s => s.Send(message), Times.Once);
        mockSocket2.Verify(s => s.Send(message), Times.Once);
    }
}