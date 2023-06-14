namespace QueueDemo.Model.Dto
{
    public class EncryptRequest
    {
        public string UserIndex { get; set; }
        public string PublicKey { get; set; }
        public string Plaintext { get; set; }
    }
}
