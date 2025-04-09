using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NSchicht.Dienst.Kartierungen;
using NSchicht.Dienst.Validierungen;
using NSchicht.Quelle;
using NSchicht.Web;
using NSchicht.Web.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x =>
x.RegisterValidatorsFromAssemblyContaining<ProduktDüoValidator>());
builder.Services.AddAutoMapper(typeof(KartierungsProfil));
builder.Services.AddDbContext<AppDbKontext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Sqlconnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbKontext)).GetName().Name);
    }
    );
});
builder.Services.AddScoped(typeof(FilterNichtGefunden<>));
builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
containerBuilder.RegisterModule(new QuelleDienstModule()));

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
