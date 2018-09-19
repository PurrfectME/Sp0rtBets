using Autofac;

namespace SportBets.DAL.AutofacModules
{
    public class FinderModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Name.EndsWith("Finder"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}