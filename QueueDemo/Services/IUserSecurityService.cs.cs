using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public interface IUserSecurityService
    {
        // 加密用户密码
        Task<bool> EncryptedUserPwd(string password);

        // 加密所有用户密码
        Task<bool> EncryptedUserPwdByQueue(DecryptRequest requsetDto);
    }
}
