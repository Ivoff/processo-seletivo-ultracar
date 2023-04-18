using ServicesManager.Domain.DependencyInjection;
using ServicesManager.Domain.QrCodeService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.Configure<QrCodeApiOptions>(builder.Configuration.GetSection(QrCodeApiOptions.Position));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
