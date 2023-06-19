using QueueDemo.Model.Dto;
using System.Collections.Concurrent;

namespace QueueDemo.Core
{
    public static class UserQueue
    {
        /// <summary>
        /// 解密队列 退出循环开关
        /// </summary>
        public static CancellationTokenSource DecryptCancelToken = new();
        /// <summary>
        /// 加密队列 退出循环开关
        /// </summary>
        public static CancellationTokenSource EncryptCancelToken = new();

        public static ConcurrentQueue<DecryptRequest> DecryptQueue = new();
        public static ConcurrentQueue<EncryptRequest> EncryptQueue = new();
    }
}
