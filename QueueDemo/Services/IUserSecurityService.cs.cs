using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public interface IUserSecurityService
    {
        // 加密所有用户密码
        bool EncryptedUserPwdByQueue();


        // 解密所有用户密码
        bool DecryptedUserPwdByQueue();
    }
}
