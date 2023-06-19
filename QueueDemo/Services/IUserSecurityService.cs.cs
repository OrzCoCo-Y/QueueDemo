using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Services
{
    public interface IUserSecurityService
    {
        /// <summary>
        /// 入队-加密所有用户密码
        /// </summary>
        /// <returns></returns>
        bool EncryptedUserPwdByQueue();

        /// <summary>
        /// 入队-解密所有用户密码-队列
        /// </summary>
        /// <returns></returns>
        bool DecryptedUserPwdByQueue();

    }
}
