using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSchicht.API.Filter;
using NSchicht.API.Middleware;
using NSchicht.Dienst.Dienste;
using NSchicht.Dienst.Kartierungen;
using NSchicht.Dienst.Validierungen;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.Quellen;
using NSchicht.Quelle;
using NSchicht.Quelle.ArbeitsEinheiten;
using NSchicht.Quelle.Quellen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>  options.Filters.Add(new ValidiereFilterAttribut())).AddFluentValidation(x =>
x.RegisterValidatorsFromAssemblyContaining<ProduktDüoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(FilterNichtGefunden<>));

builder.Services.AddScoped<IArbeitsEinheit, ArbeitsEinheit>();
builder.Services.AddScoped(typeof(IGenerischeQuelle<>), typeof(GenerischeQuelle<>));
builder.Services.AddScoped(typeof(IDienst<>), typeof(Dienst<>));
builder.Services.AddAutoMapper(typeof(KartierungsProfil));

builder.Services.AddScoped<IProduktQuelle, ProduktQuelle>();
builder.Services.AddScoped<IProduktDienst, ProduktDienst>();

builder.Services.AddScoped<IKategorieQuelle, KategorieQuelle>();
builder.Services.AddScoped<IKategorieDienst, KategorieDienst>();

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

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
