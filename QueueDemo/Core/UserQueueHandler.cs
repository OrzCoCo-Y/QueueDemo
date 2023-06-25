using Newtonsoft.Json;
using QueueDemo.Model;
using QueueDemo.Model.Dto;
using QueueDemo.Services;

namespace QueueDemo.Core
{
    public class UserQueueHandler
    {
        private QueueHub _queueHub;
        public UserQueueHandler(QueueHub queueHub)
        {
            _queueHub = queueHub;
        }

        public async Task DeProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"Decrypt ProcessQueue Start! ");

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
                                var userInfo = GlobalUserInfo.UserInfos.First(x => x.Index == deScryptRsp.UserIndex);
                                userInfo.DecryptedPwd = deScryptRsp.DecryptedPwd;
                                await _queueHub.SendDecryptDequeue(userInfo.UserId, userInfo.DecryptedPwd);
                                await Console.Out.WriteLineAsync($"DeProcessQueue Success! UserId--{userInfo.UserId} UserIndex--{deScryptRsp.UserIndex} ");
                            }
                            await Task.Delay(1000);
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync($"DeProcessQueue Error --{JsonConvert.SerializeObject(ex)} ");
                        }
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

        public async Task EnProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"Encrypt ProcessQueue Start! ");

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
                            var userInfo = GlobalUserInfo.UserInfos.First(x => x.Index == enScryptRsp.UserIndex);
                            userInfo.EncryptedPwd = enScryptRsp.EncryptedPwd;

                            await _queueHub.SendEncryptDequeue(userInfo.UserId, userInfo.EncryptedPwd);
                            await Console.Out.WriteLineAsync($"EnProcessQueue Success! UserId--{userInfo.UserId} UserIndex--{enRequest.UserIndex} ");
                            await Task.Delay(1000);
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync($"EnProcessQueue Error --{JsonConvert.SerializeObject(ex)} ");
                        }
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
