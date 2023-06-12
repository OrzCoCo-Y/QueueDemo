using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        public async Task<bool> EncryptedUserPwd(string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EncryptedUserPwdByQueue(SecurityRequsetDto requsetDto)
        {
            throw new NotImplementedException();
        }
    }
}
