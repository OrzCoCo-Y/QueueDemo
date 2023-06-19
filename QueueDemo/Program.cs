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

// ������������̨����            
UserQueueHandler ledgerQueue = new();
CancellationTokenSource cancelToken = new();
Task task = Task.Run(() => ledgerQueue.DeProcessQueue(builder.Services, cancelToken.Token));
Task task2 = Task.Run(() => ledgerQueue.EnProcessQueue(builder.Services, cancelToken.Token));

var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
