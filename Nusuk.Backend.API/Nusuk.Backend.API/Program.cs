using Nusuk.Infrastructure;
using Nusuk.Services;
using Quizzy.Backend.API.Extensions;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
    {
        "application/json",
        "text/plain",
        "application/javascript",
        "text/css"
    });
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerExtension();

var configuration = builder.Configuration;
builder.Services.AddInfrastructure(configuration);
builder.Services.AddService(configuration);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenCors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseResponseCompression();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("OpenCors");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();