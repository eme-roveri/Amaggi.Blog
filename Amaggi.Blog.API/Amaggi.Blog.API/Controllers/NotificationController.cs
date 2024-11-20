using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    // Presentation/Controllers/NotificationController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        //private readonly WebSocketServer _webSocketServer;

        //public NotificationController(WebSocketServer webSocketServer)
        //{
        //    _webSocketServer = webSocketServer;
        //}

        //[HttpGet("ws")]
        //public async Task Get()
        //{
        //    if (HttpContext.WebSockets.IsWebSocketRequest)
        //    {
        //        await _webSocketServer.AcceptWebSocketAsync(HttpContext);
        //    }
        //    else
        //    {
        //        HttpContext.Response.StatusCode = 400;
        //    }
        //}
    }
}
