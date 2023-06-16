using QueueDemo.Model.Dto;
using System.Collections.Concurrent;

namespace QueueDemo.Core
{
    public static class UserQueue
    {
        public static ConcurrentQueue<DecryptRequest> DecryptQueue = new();
        public static ConcurrentQueue<EncryptRequest> EncryptQueue = new();
    }
}
