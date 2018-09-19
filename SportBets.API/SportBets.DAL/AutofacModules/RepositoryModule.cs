using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SportBets.BLL.Entities;
using SportBets.DAL.Repositories;

namespace SportBets.DAL.AutofacModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<User>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Repository<Bet>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Repository<Horse>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Repository<FootballTeam>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Repository<BasketballTeam>>().AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}
