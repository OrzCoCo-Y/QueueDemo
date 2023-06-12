using System.Security.Cryptography.X509Certificates;
namespace QueueDemo.Model.Dto
{
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
