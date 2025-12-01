using Nusuk.Infrastructure;
using Nusuk.Services;
using Quizzy.Backend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder .Services.AddSwaggerExtension();

var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);
builder.Services.AddService(configuration);
builder.Services.AddCors();

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
