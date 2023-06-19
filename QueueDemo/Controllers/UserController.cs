using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model;
using QueueDemo.Model.Dto;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("keypair")]
        public GenerateResponse GenerateKeys()
        {
            RSAProcessing.GenerateKeys(out string publicKey, out string pricateKey);
            if (string.IsNullOrWhiteSpace(GlobalSecretInfo.privateKey))
            {
                GlobalSecretInfo.privateKey = pricateKey;
            }
            if (string.IsNullOrWhiteSpace(GlobalSecretInfo.publicKey))
            {
                GlobalSecretInfo.publicKey = publicKey;
            }

            return new GenerateResponse(publicKey, pricateKey);
        }

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
