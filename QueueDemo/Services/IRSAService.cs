using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public interface IRSAService
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        EncryptResponse Encrypt(EncryptRequest request);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DecryptResponse Decrypt(DecryptRequest request);

        /// <summary>
        /// 签字
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SignResponse Sign(SignRequest request);

        /// <summary>
        /// 校验签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        VerifyResponse Verify(VerifyRequest request);
    }
}
