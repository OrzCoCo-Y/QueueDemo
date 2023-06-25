using QueueDemo.Core;
using QueueDemo.Model;
using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        public bool EncryptedUserPwdByQueue()
        {
            GlobalUserInfo.UserInfos.ForEach(info =>
            {
                GlobalUserQueue.EncryptQueue.Enqueue(new EncryptRequest()
                {
                    Plaintext = info.Pwd,
                    PublicKey = GlobalSecretInfo.PublicKey,
                    UserIndex = info.Index
                });
            });
            return true;
        }

        public bool DecryptedUserPwdByQueue()
        {
            GlobalUserInfo.UserInfos.ForEach(info =>
            {
                GlobalUserQueue.DecryptQueue.Enqueue(new DecryptRequest()
                {
                    EncryptedPwd = info.EncryptedPwd,
                    PrivateKey = GlobalSecretInfo.PrivateKey,
                    UserIndex = info.Index
                });
            });
            return true;
        }
    }
}
