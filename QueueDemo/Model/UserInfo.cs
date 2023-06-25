namespace QueueDemo.Model
{
    /// <summary>
    /// 用户信息Model
    /// </summary>
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Index { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string EncryptedPwd { get; set; }
        public string DecryptedPwd { get; set; }
    }
}
