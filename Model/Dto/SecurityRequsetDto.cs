namespace QueueDemo.Model.Dto
{
    public class SecurityRequsetDto
    {
        public int UserIndex { get; set; }
        public string UserPwd { get; set; }
        public string EncryptedPwd { get; set; }
    }
}
