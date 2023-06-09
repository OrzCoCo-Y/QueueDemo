using QueueDemo.Model;
using QueueDemo.Model.Dto;
using System.Collections.Concurrent;

namespace QueueDemo.Core
{
    public static class UserQueue
    {
        public static ConcurrentQueue<SecurityRequsetDto> requestQueue = new ConcurrentQueue<SecurityRequsetDto>();
    }
}
