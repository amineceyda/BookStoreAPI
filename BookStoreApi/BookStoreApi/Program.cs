using BookStoreApi.DBOperations; // Add the namespace where DataGenerator and BookStoreDbContext are located
using BookStoreApi.Middlewares;
using BookStoreApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext as a service with in-memory database
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();//Deðiþime açýklýk saðlýyor
//Solid Prensipleri 

var app = builder.Build();

// Seed the initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services); // Change 'Initialize' to 'initialize'
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCustomExceptionMiddleware();//custom middleware


app.MapControllers();

app.Run();
