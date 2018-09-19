using Autofac;
using SportBets.DAL.EntitiesContext;

namespace SportBets.DAL.AutofacModules
{
    public class ContextModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SportBetsContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
