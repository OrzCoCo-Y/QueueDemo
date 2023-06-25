using Microsoft.AspNetCore.SignalR;

namespace QueueDemo.Core
{
    public class QueueHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            GlobalUserInfo.Clients = Clients;
            await base.OnConnectedAsync();
        }

        public async Task SendEncryptDequeue(int userId, string message)
        {
            await GlobalUserInfo.Clients.All.SendAsync("ReceiveEncrypt", userId, message);
        }

        public async Task SendDecryptDequeue(int userId, string message)
        {
            await GlobalUserInfo.Clients.All.SendAsync("ReceiveDecrypt", userId, message);
        }
    }
}
