using MyRestfulApp.Application;
using MyRestfulApp.Data;
using MyRestfulApp.Data.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("config/appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Agrego las configuraciones personalizadas
builder.Services.Configure<Settings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.ConfigureApplication();
builder.Services.ConfigurePersistence();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
