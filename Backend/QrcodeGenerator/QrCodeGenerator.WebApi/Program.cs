using FluentValidation;
using QrCodeGenerator.WebApi.Controllers.Generate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<GenerateQrCodeRequest>, GenerateQrCodeRequestValidator>();

var app = builder.Build();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
