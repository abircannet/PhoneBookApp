using Cdr.ContactMicroservice.Persistence;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Cdr.ReportMicroservice.Domain.Services;
using Cdr.ReportMicroservice.Infrastructure.MessageServices;
using Cdr.ReportMicroservice.Infrastructure.ReportServices;
using Cdr.ReportMicroservice.Persistence;
using Cdr.ReportMicroservice.RestfullAPI.BackgroundServices;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using RabbitMQ.Client;
using IModel = RabbitMQ.Client.IModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
ExcelPackage.LicenseContext = LicenseContext.Commercial;

builder.Services.AddDbContext<ReportDbContext>(opts =>
{

    opts.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IMessageService, RabbitMQMessageProducer>();
builder.Services.AddSingleton<IExcelReportService, ExcelReportService>();
builder.Services.AddSingleton(typeof(IReporterClientService<IModel>), typeof(ReporterClientService));
builder.Services.AddSingleton<IReportApiService, ReportApiService>();
builder.Services.AddSingleton(sp => new ConnectionFactory()
{
    HostName = builder.Configuration.GetSection("RabbitMQService").Value,
    DispatchConsumersAsync = true
});
builder.Services.AddHostedService<ReportBackgroundService>();
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

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var reportContext = scopedProvider.GetRequiredService<ReportDbContext>();
        await ReportDbContextSeed.SeedAsync(reportContext);


    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();
