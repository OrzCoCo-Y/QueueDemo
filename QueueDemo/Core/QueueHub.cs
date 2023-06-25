using Microsoft.AspNetCore.SignalR;

namespace QueueDemo.Core
{
    /// <summary>
    /// 队列的signalR总线
    /// </summary>
    public class QueueHub : Hub
    {
        /// <summary>
        /// 加入连接的事件
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            GlobalUserInfo.Clients = Clients;
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// signalR推送加密信息
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="message">加密数据</param>
        /// <returns></returns>
        public async Task SendEncryptDequeue(int userId, string message)
        {
            await GlobalUserInfo.Clients.All.SendAsync("ReceiveEncrypt", userId, message);
        }

        /// <summary>
        ///  signalR推送解密信息
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="message">解密数据</param>
        /// <returns></returns>
        public async Task SendDecryptDequeue(int userId, string message)
        {
            await GlobalUserInfo.Clients.All.SendAsync("ReceiveDecrypt", userId, message);
        }
    }
}
