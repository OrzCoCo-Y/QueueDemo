using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("userlist")]
        public List<UserInfo> UserList()
        {
            return GlobalUserInfo.UserInfos;
        }

        [HttpPost("queue/encryption")]
        public bool EncryptEnQueue()
        {
            return true;
        }

        [HttpPost("queue/decryption")]
        public bool DecryptEnQueue(string email, string password)
        {
            return true;
        }
    }
}
