namespace QueueDemo.Model.Dto
{
    public class VerifyRequest
    {
        public string UserIndex { get; set; }
        public string PublicKey { get; set; }
        public string Plaintext { get; set; }
        public string SignText { get; set; }
    }
}
