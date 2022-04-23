using Autofac;
using NSchicht.Dienst.Dienste;
using NSchicht.Dienst.Kartierungen;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.Quellen;
using NSchicht.Quelle;
using NSchicht.Quelle.ArbeitsEinheiten;
using NSchicht.Quelle.Quellen;
using System.Reflection;
using Module = Autofac.Module;
namespace NSchicht.Web.Modules
{
    public class QuelleDienstModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenerischeQuelle<>)).As(typeof(IGenerischeQuelle<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Dienst<>)).As(typeof(IDienst<>)).InstancePerLifetimeScope();

            builder.RegisterType<ArbeitsEinheit>().As<IArbeitsEinheit>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var quelleAssembly = Assembly.GetAssembly(typeof(AppDbKontext));
            var dienstAssembly = Assembly.GetAssembly(typeof(KartierungsProfil));

            builder.RegisterAssemblyTypes(apiAssembly, quelleAssembly, dienstAssembly).Where(x =>
            x.Name.EndsWith("Quelle")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, quelleAssembly, dienstAssembly).Where(x =>
            x.Name.EndsWith("Dienst")).AsImplementedInterfaces().InstancePerLifetimeScope();

            

        }
    }
}
