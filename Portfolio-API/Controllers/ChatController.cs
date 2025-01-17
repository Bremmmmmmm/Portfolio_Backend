using Interface.Interfaces.Logic;
using Interface.RequestBodies;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API.Controllers;

public class ChatController(IWebSocketHandler webSocketHandler) : Controller
{
    [HttpPost]
    [Route("Send_message_to_admin")]
    public Task<IActionResult> SendMessage([FromBody] MessageBody request)
    {
        try
        {
            webSocketHandler.sendMessageToAdmin(request.Message, request.UserId);
            return Task.FromResult<IActionResult>(Ok());
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return Task.FromResult<IActionResult>(StatusCode(500, $"Could not send message:\r\n{e.Message}"));
        }
    }

    [HttpPost]
    [Route("Send_message_to_user")]
    public Task<IActionResult> SendMessageToUser([FromBody] MessageBody request)
    {
        try
        {
            webSocketHandler.sendMessageToUser(request.Message, request.UserId);
            return Task.FromResult<IActionResult>(Ok());
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return Task.FromResult<IActionResult>(StatusCode(500, $"Could not send message:\r\n{e.Message}"));
        }
    }
}