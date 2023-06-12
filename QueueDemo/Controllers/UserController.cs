using Microsoft.AspNetCore.Mvc;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public bool enQueue(string email, string password)
        {
            return true;
        }
    }
}
