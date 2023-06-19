using QueueDemo.Core;
using QueueDemo.Model;
using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        public async Task<bool> EncryptedUserPwdByQueue()
        {
            GlobalUserInfo.UserInfos.ForEach(async info =>
            {
                UserQueue.EncryptQueue.Enqueue(new EncryptRequest()
                {
                    Plaintext = info.Pwd,
                    PublicKey = GlobalSecretInfo.publicKey,
                    UserIndex = info.Index
                });
            });
            return true;
        }

        public Task<bool> DecryptedUserPwdByQueue()
        {
            throw new NotImplementedException();
        }
    }
}
