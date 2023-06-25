namespace QueueDemo.Model.Dto
{
    /// <summary>
    /// 加密回应DTO
    /// </summary>
    public class EncryptResponse
    {
        public EncryptResponse(string encryptedPwd, string userIndex)
        {
            EncryptedPwd = encryptedPwd ?? string.Empty;
            UserIndex = userIndex ?? string.Empty;
        }
        public string UserIndex { get; set; }
        public string EncryptedPwd { get; set; }
    }
}
