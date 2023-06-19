using QueueDemo.Core;
using QueueDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddTransient<IUserSecurityService, UserSecurityService>();
builder.Services.AddTransient<IRSAService, RSAService>();

// 创建并启动后台任务            
UserQueueHandler ledgerQueue = new();
Task task = Task.Run(() => ledgerQueue.DeProcessQueue(builder.Services, UserQueue.DecryptCancelToken.Token));
Task task2 = Task.Run(() => ledgerQueue.EnProcessQueue(builder.Services, UserQueue.DEncryptCancelToken.Token));

var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
