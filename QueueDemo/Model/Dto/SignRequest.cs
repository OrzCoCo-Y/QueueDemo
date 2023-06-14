namespace QueueDemo.Model.Dto
{
    public class SignRequest
    {
        public string UserIndex { get; set; } = "test";
        public string PrivateKey { get; set; }
        public string Plaintext { get; set; }
    }
}
