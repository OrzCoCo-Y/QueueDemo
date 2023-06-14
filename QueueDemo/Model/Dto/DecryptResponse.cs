namespace QueueDemo.Model.Dto
{
    public class DecryptResponse
    {
        public DecryptResponse(string userIndex, string encryptedPwd, string decryptedPwd)
        {
            UserIndex = userIndex;
            EncryptedPwd = encryptedPwd;
            DecryptedPwd = decryptedPwd;
        }

        public string UserIndex { get; set; }
        public string EncryptedPwd { get; set; }

        public string DecryptedPwd { get; set; }
    }
}
