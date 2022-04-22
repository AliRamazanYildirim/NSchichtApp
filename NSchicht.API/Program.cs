using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSchicht.API.Filter;
using NSchicht.API.Middleware;
using NSchicht.API.Modules;
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
builder.Services.AddAutoMapper(typeof(KartierungsProfil));



builder.Services.AddDbContext<AppDbKontext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Sqlconnection"), option =>
     {
         option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbKontext)).GetName().Name);
     }
    );
});

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new QuelleDienstModule()));

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
