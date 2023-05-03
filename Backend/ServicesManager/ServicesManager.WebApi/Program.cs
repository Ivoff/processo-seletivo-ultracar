using FluentValidation;
using ServicesManager.Application.DependencyInjection;
using ServicesManager.Domain.DependencyInjection;
using ServicesManager.Domain.QrCodeService;
using ServicesManager.Infra.DependencyInjection;
using ServicesManager.Infra.ConnectionStrings;
using ServicesManager.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddInfra();
builder.Services.AddApplication();

builder.Services.AddScoped<IValidator<CarQrCodeRequest>, CarQrCodeRequestValidator>();
builder.Services.AddScoped<IValidator<NewServiceRequest>, NewServiceRequestValidator>();
builder.Services.AddScoped<IValidator<ServiceIdRequest>, ServiceIdRequestValidator>();
builder.Services.AddScoped<IValidator<AddPartRequest>, AddPartRequestValidator>();
builder.Services.AddScoped<IValidator<RemovePartRequest>, RemovePartRequestValidator>();

builder.Services.Configure<QrCodeApiOptions>(builder.Configuration.GetSection(QrCodeApiOptions.Position));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(ConnectionStrings.Position));

var app = builder.Build();

app.UseCors();
// app.UseAuthentication();
// app.UseAuthorization();
// app.UseHttpsRedirection();
app.MapControllers();
app.Run();
