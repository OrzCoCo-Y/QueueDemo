using Newtonsoft.Json;
using QueueDemo.Model;
using QueueDemo.Model.Dto;
using QueueDemo.Services;
using System.Collections.Concurrent;

namespace QueueDemo.Core
{
    public class UserQueueHandler
    {
        public async Task ProcessQueue(IServiceCollection services, ConcurrentQueue<DecryptRequest> requestQueue, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var myService = serviceProvider.GetRequiredService<IUserSecurityService>();
                await Console.Out.WriteLineAsync($"ProcessQueue Start! ");
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    if (requestQueue.TryDequeue(out DecryptRequest request))
                    {
                        await Console.Out.WriteLineAsync($"TryDequeue LeaseId{request.UserIndex} -- {JsonConvert.SerializeObject(request)} ");
                        try
                        {
                            var docId = await myService.EncryptedUserPwdByQueue(request);
                            await Console.Out.WriteLineAsync($"UploadLedgerToDocumentCenterAsync Success! docId--{docId} ");
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync($"UploadLedgerToDocumentCenterAsync Error --{JsonConvert.SerializeObject(ex)} ");
                        }

                        await Task.Delay(1000);
                    }
                    else
                    {
                        await Task.Delay(10000);
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
