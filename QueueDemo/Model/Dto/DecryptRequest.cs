namespace QueueDemo.Model.Dto
{
    /// <summary>
    /// 解密请求DTO
    /// </summary>
    public class DecryptRequest
    {
        public string UserIndex { get; set; } = "test";
        public string EncryptedPwd { get; set; }
        public string PrivateKey { get; set; }
    }
}
