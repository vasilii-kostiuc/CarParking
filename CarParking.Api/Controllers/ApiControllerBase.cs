using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarParking.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult ExceptionResult(Exception ex)
        {
            return ex switch
            {
                // TODO To add different Exception types
                _ => StatusCode((int)HttpStatusCode.BadRequest, ex.Message)
            };
        }
    }
}
