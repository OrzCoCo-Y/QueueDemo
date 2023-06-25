namespace QueueDemo.Model.Dto
{
    /// <summary>
    /// 加密请求DTO
    /// </summary>
    public class EncryptRequest
    {
        public string UserIndex { get; set; } = "test";
        public string PublicKey { get; set; }
        public string Plaintext { get; set; }
    }
}
