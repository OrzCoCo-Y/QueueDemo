using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model;
using QueueDemo.Model.Dto;
using QueueDemo.Services;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSecurityService _userSecurityService;

        public UserController(IUserSecurityService userSecurityService)
        {
            _userSecurityService = userSecurityService;
        }

        [HttpPost("keypair")]
        public GenerateResponse GenerateKeys()
        {
            RSAProcessing.GenerateKeys(out string publicKey, out string pricateKey);
            if (string.IsNullOrWhiteSpace(GlobalSecretInfo.PrivateKey))
            {
                GlobalSecretInfo.PrivateKey = pricateKey;
            }
            if (string.IsNullOrWhiteSpace(GlobalSecretInfo.PublicKey))
            {
                GlobalSecretInfo.PublicKey = publicKey;
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
            return _userSecurityService.EncryptedUserPwdByQueue();
        }

        [HttpPost("queue/decryption")]
        public bool DecryptEnQueue()
        {
            return _userSecurityService.DecryptedUserPwdByQueue();
        }
    }
}
