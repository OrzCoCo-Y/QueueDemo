namespace QueueDemo.Model.Dto
{
    public class EncryptRequest
    {
        public string UserIndex { get; set; } = "test";
        public string PublicKey { get; set; }
        public string Plaintext { get; set; }
    }
}
