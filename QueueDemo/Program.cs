using QueueDemo.Core;
using QueueDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// 创建并启动后台任务            
UserQueueHandler ledgerQueue = new();
CancellationTokenSource cancellationTokenSource = new();
Task task = Task.Run(() => ledgerQueue.ProcessQueue(builder.Services, cancellationTokenSource.Token));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
