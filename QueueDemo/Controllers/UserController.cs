using Microsoft.AspNetCore.Mvc;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public bool EnQueue(string email, string password)
        {
            return true;
        }
    }
}
