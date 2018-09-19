using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using SportBets.BLL.AutofacModules;
using SportBets.BLL.Entities;
using SportBets.DAL.AutofacModules;
using SportBets.DAL.EntitiesContext;

namespace SportBets.API.DI
{
    public class AutofacConfiguration
    {
        public static void ConfigureContainer()
        {
            //Autofac configuration
            var builder = new ContainerBuilder();

            //Getting HTTP configuration
            var config = GlobalConfiguration.Configuration;

            //Register Web Api 2 controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Register IDSet<> entity
            builder.Register((ctx) => ctx.Resolve<SportBetsContext>().Bets).As<IDbSet<Bet>>()
                .InstancePerLifetimeScope();
            builder.Register((ctx) => ctx.Resolve<SportBetsContext>().Users).As<IDbSet<User>>()
                .InstancePerLifetimeScope();
            builder.Register((ctx) => ctx.Resolve<SportBetsContext>().Horses).As<IDbSet<Horse>>()
                .InstancePerLifetimeScope();
            builder.Register((ctx) => ctx.Resolve<SportBetsContext>().FootballTeams).As<IDbSet<FootballTeam>>()
                .InstancePerLifetimeScope();
            builder.Register((ctx) => ctx.Resolve<SportBetsContext>().BasketballTeams).As<IDbSet<BasketballTeam>>()
                .InstancePerLifetimeScope();

            //Register services
            builder.RegisterModule<ServiceModule>();

            //Register repository
            builder.RegisterModule<RepositoryModule>();

            //Register UOF
            builder.RegisterModule<UnitOfWorkModule>();

            //Register context
            builder.RegisterModule<ContextModule>();

            //Register finders
            builder.RegisterModule<FinderModule>();


            //Setting dependency resolver to be Autofac
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}