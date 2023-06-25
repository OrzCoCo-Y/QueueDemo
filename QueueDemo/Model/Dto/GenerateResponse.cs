namespace QueueDemo.Model.Dto
{
    /// <summary>
    /// 生成秘钥回应DTO
    /// </summary>
    public class GenerateResponse
    {
        public GenerateResponse(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}
