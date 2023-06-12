using QueueDemo.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ������������̨����            
UserQueueHandler ledgerQueue = new UserQueueHandler();
var cancellationTokenSource = new CancellationTokenSource();
Task task = Task.Run(() => ledgerQueue.ProcessQueue(builder.Services, UserQueue.requestQueue, cancellationTokenSource.Token));

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

app.Run();
