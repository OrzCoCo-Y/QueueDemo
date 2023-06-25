using Newtonsoft.Json;
using QueueDemo.Model;
using QueueDemo.Model.Dto;
using QueueDemo.Services;

namespace QueueDemo.Core
{
    /// <summary>
    /// 用户队列处理程序
    /// </summary>
    public class UserQueueHandler
    {
        private QueueHub _queueHub;

        /// <summary>
        /// 注入队列总线
        /// </summary>
        /// <param name="queueHub"></param>
        public UserQueueHandler(QueueHub queueHub)
        {
            _queueHub = queueHub;
        }

        /// <summary>
        /// 启动解密队列
        /// </summary>
        /// <param name="services">注册服务</param>
        /// <param name="cancellationToken">退出Token控制器</param>
        /// <returns></returns>
        public async Task DeProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                // Rsa加解密服务
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"Decrypt ProcessQueue Start! ");

                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    // 解密队列出队
                    if (GlobalUserQueue.DecryptQueue.TryDequeue(out DecryptRequest deRequest))
                    {
                        await Console.Out.WriteLineAsync($"DeProcessQueue UserIndexId -- {deRequest.UserIndex} -- {JsonConvert.SerializeObject(deRequest)} ");
                        try
                        {
                            // 解密
                            var deScryptRsp = rsaService.Decrypt(deRequest);
                            if (deScryptRsp != null)
                            {
                                var userInfo = GlobalUserInfo.UserInfos.First(x => x.Index == deScryptRsp.UserIndex);
                                userInfo.DecryptedPwd = deScryptRsp.DecryptedPwd;

                                // 推送解密信息到前端
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
                        // 队列中无数量 则休眠10秒
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

        /// <summary>
        /// 启动加密队列
        /// </summary>
        /// <param name="services">注册服务</param>
        /// <param name="cancellationToken">退出Token控制器</param>
        /// <returns></returns>
        public async Task EnProcessQueue(IServiceCollection services, CancellationToken cancellationToken)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                // Rsa加解密服务
                var rsaService = serviceProvider.GetRequiredService<IRSAService>();
                await Console.Out.WriteLineAsync($"Encrypt ProcessQueue Start! ");

                //  逻辑同解密队列逻辑
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    if (GlobalUserQueue.EncryptQueue.TryDequeue(out EncryptRequest enRequest))
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
