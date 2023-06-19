using Newtonsoft.Json;
using QueueDemo.Model.Dto;
using QueueDemo.Services;

namespace QueueDemo.Core
{
    public class UserQueueHandler
    {
        public async Task DeProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"ProcessQueue Start! ");
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    if (UserQueue.DecryptQueue.TryDequeue(out DecryptRequest deRequest))
                    {
                        await Console.Out.WriteLineAsync($"DeProcessQueue UserIndexId -- {deRequest.UserIndex} -- {JsonConvert.SerializeObject(deRequest)} ");
                        try
                        {
                            var deScryptRsp = rsaService.Decrypt(deRequest);
                            if (deScryptRsp != null)
                            {
                                GlobalUserInfo.UserInfos.First(x => x.Index == deScryptRsp.UserIndex).DecryptedPwd = deScryptRsp.DecryptedPwd;
                                await Console.Out.WriteLineAsync($"DeProcessQueue Success! UserIndex--{deScryptRsp.UserIndex} ");
                            }
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync($"DeProcessQueue Error --{JsonConvert.SerializeObject(ex)} ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        public async Task EnProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"ProcessQueue Start! ");
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    if (UserQueue.EncryptQueue.TryDequeue(out EncryptRequest enRequest))
                    {
                        await Console.Out.WriteLineAsync($"EnProcessQueue UserIndexId -- {enRequest.UserIndex} -- {JsonConvert.SerializeObject(enRequest)} ");
                        try
                        {
                            var enScryptRsp = rsaService.Encrypt(enRequest);
                            await Console.Out.WriteLineAsync($"EnProcessQueue Success! UserIndex--{enRequest.UserIndex} ");
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync($"EnProcessQueue Error --{JsonConvert.SerializeObject(ex)} ");
                        }
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
