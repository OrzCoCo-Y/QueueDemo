using QueueDemo.Core;
using QueueDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:5067")
               .AllowCredentials(); // �������ƾ��;
    });
});

builder.Services.AddTransient<IUserSecurityService, UserSecurityService>();
builder.Services.AddTransient<IRSAService, RSAService>();
builder.Services.AddSignalR();

// ������������̨����            
UserQueueHandler ledgerQueue = new(new QueueHub());
Task task = Task.Run(() => ledgerQueue.DeProcessQueue(builder.Services, UserQueue.DecryptCancelToken.Token));
Task task2 = Task.Run(() => ledgerQueue.EnProcessQueue(builder.Services, UserQueue.EncryptCancelToken.Token));

var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();
app.MapHub<QueueHub>("/queueHub");
app.Run();
