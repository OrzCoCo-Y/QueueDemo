using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    /// <summary>
    /// RSA 加解密服务
    /// </summary>
    public class RSAService : IRSAService
    {
        public DecryptResponse Decrypt(DecryptRequest request)
        {
            var decryptedText = RSAProcessing.Decrypt(request.EncryptedPwd, request.PrivateKey);
            return new DecryptResponse(request.UserIndex, request.EncryptedPwd, decryptedText);
        }

        public EncryptResponse Encrypt(EncryptRequest request)
        {
            var encryptedPwd = RSAProcessing.Encrypt(request.Plaintext, request.PublicKey);
            return new EncryptResponse(encryptedPwd, request.UserIndex);
        }

        public SignResponse Sign(SignRequest request)
        {
            var signText = RSAProcessing.Sign(request.Plaintext, request.PrivateKey);
            return new SignResponse(request.UserIndex, signText);
        }

        public VerifyResponse Verify(VerifyRequest request)
        {
            var verifyResult = RSAProcessing.Verify(request.Plaintext, request.SignText, request.PublicKey);
            return new VerifyResponse(request.UserIndex, verifyResult);
        }
    }
}
