using Microsoft.AspNetCore.SignalR;

namespace RSAProcessing.MVC.Hubs
{
    /// <summary>
    /// 聊天的消息中心
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
