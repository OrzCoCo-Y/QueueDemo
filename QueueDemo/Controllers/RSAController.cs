using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        /// <summary>
        /// 生成秘钥
        /// </summary>
        /// <returns></returns>
        [HttpPost("keypair")]
        public GenerateResponse GenerateKeyPair()
        {
            RSAProcessing.GenerateKeys(out string publicKey, out string pricateKey);
            return new GenerateResponse(publicKey, pricateKey);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("encrypt")]
        public EncryptResponse Encrypt([FromBody] EncryptRequest request)
        {
            var encryptedPwd = RSAProcessing.Encrypt(request.Plaintext, request.PublicKey);
            return new EncryptResponse(encryptedPwd, request.UserIndex);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("decrypt")]
        public DecryptResponse Decrypt([FromBody] DecryptRequest request)
        {
            var decryptedText = RSAProcessing.Decrypt(request.EncryptedPwd, request.PrivateKey);
            return new DecryptResponse(request.UserIndex, request.EncryptedPwd, decryptedText);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("sign")]
        public SignResponse Sign([FromBody] SignRequest request)
        {
            var signText = RSAProcessing.Sign(request.Plaintext, request.PrivateKey);
            return new SignResponse(request.UserIndex, signText);
        }

        /// <summary>
        /// 校验签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("verify")]
        public VerifyResponse Verify([FromBody] VerifyRequest request)
        {
            var verifyResult = RSAProcessing.Verify(request.Plaintext, request.SignText, request.PublicKey);
            return new VerifyResponse(request.UserIndex, verifyResult);
        }
    }
}
