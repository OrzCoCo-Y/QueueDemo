using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        [HttpPost("keypair")]
        public GenerateResponse GenerateKeyPair()
        {
            RSAProcessing.GenerateKeys(out string publicKey, out string pricateKey);
            return new GenerateResponse(publicKey, pricateKey);
        }

        [HttpPost("encrypt")]
        public EncryptResponse Encrypt([FromBody] EncryptRequest request)
        {
            var encryptedPwd = RSAProcessing.Encrypt(request.Plaintext, request.PublicKey);
            return new EncryptResponse(encryptedPwd, request.UserIndex);
        }

        [HttpPost("decrypt")]
        public DecryptResponse Decrypt([FromBody] DecryptRequest request)
        {
            var decryptedText = RSAProcessing.Decrypt(request.EncryptedPwd, request.PrivateKey);
            return new DecryptResponse(request.UserIndex, request.EncryptedPwd, decryptedText);
        }

        [HttpPost("sign")]
        public SignResponse Sign([FromBody] SignRequest request)
        {
            var signText = RSAProcessing.Sign(request.Plaintext, request.PrivateKey);
            return new SignResponse(request.UserIndex, signText);
        }

        [HttpPost("verify")]
        public VerifyResponse Verify([FromBody] VerifyRequest request)
        {
            var verifyResult = RSAProcessing.Verify(request.Plaintext, request.SignText, request.PublicKey);
            return new VerifyResponse(request.UserIndex, verifyResult);
        }
    }
}
