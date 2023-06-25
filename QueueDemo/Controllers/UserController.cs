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

        /// <summary>
        /// 注入用户安全服务
        /// </summary>
        /// <param name="userSecurityService"></param>
        public UserController(IUserSecurityService userSecurityService)
        {
            _userSecurityService = userSecurityService;
        }

        /// <summary>
        /// 获取秘钥
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 获取用户列表（内存）
        /// </summary>
        /// <returns></returns>
        [HttpGet("userlist")]
        public List<UserInfo> UserList()
        {
            return GlobalUserInfo.UserInfos;
        }

        /// <summary>
        /// 加密队列
        /// </summary>
        /// <returns></returns>
        [HttpPost("queue/encryption")]
        public bool EncryptEnQueue()
        {
            return _userSecurityService.EncryptedUserPwdByQueue();
        }

        /// <summary>
        /// 解密队列
        /// </summary>
        /// <returns></returns>
        [HttpPost("queue/decryption")]
        public bool DecryptEnQueue()
        {
            return _userSecurityService.DecryptedUserPwdByQueue();
        }
    }
}
