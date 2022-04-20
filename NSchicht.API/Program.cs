using Microsoft.EntityFrameworkCore;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Quellen;
using NSchicht.Quelle;
using NSchicht.Quelle.ArbeitsEinheiten;
using NSchicht.Quelle.Quellen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArbeitsEinheit, ArbeitsEinheit>();
builder.Services.AddScoped(typeof(IGenerischeQuelle<>), typeof(GenerischeQuelle<>));

builder.Services.AddDbContext<AppDbKontext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Sqlconnection"), option =>
     {
         option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbKontext)).GetName().Name);
     }
    );
});

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
