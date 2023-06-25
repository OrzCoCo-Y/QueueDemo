using QueueDemo.Model.Dto;
using System.Collections.Concurrent;

namespace QueueDemo.Core
{
    /// <summary>
    /// 全局用户队列初始化
    /// </summary>
    public static class GlobalUserQueue
    {
        /// <summary>
        /// 解密队列 退出循环开关
        /// </summary>
        public static CancellationTokenSource DecryptCancelToken = new();
        /// <summary>
        /// 加密队列 退出循环开关
        /// </summary>
        public static CancellationTokenSource EncryptCancelToken = new();

        /// <summary>
        /// 解密队列
        /// </summary>
        public static ConcurrentQueue<DecryptRequest> DecryptQueue = new();

        /// <summary>
        /// 加密队列
        /// </summary>
        public static ConcurrentQueue<EncryptRequest> EncryptQueue = new();
    }
}
