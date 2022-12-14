using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.Domain.Services;
using Cdr.ContactMicroservice.Persistence;
using Cdr.ContactMicroservice.Persistence.Postgre;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext< Cdr.ContactMicroservice.Persistence.Postgre.ContactDbContext >(opts =>
{
    //for postgre
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    //opts.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddScoped(typeof(IReadRepository<>), typeof(Cdr.ContactMicroservice.Persistence.Postgre.EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Cdr.ContactMicroservice.Persistence.Postgre.EfRepository<>));
builder.Services.AddScoped<IContactService, ContactService>();


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
        var contactContext = scopedProvider.GetRequiredService<Cdr.ContactMicroservice.Persistence.Postgre.ContactDbContext>();
        await Cdr.ContactMicroservice.Persistence.Postgre.ContactContextSeed.SeedAsync(contactContext);


    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();
