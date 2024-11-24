using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blog.API.Controllers
{
    public class CustomResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CustomResponse(string status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public static CustomResponse Success(string message, object data)
        {
            return new CustomResponse("success", message, data);
        }

        public static CustomResponse Error(string message)
        {
            return new CustomResponse("error", message, string.Empty);
        }
    }
}
