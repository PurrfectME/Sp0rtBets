using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportBets.DAL.EntitiesContext.SportBetsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportBets.DAL.EntitiesContext.SportBetsContext context)
        {
            var user1 = new User()
            {
                
                Email = "it.efr99@gmail.com",
                PasswordHash = "123456789",
                RegistrationDate = new DateTime(2018, 1, 14)
            };
            var user2 = new User()
            {
                
                Email = "dog01@gmail.com",
                PasswordHash = "987654321",
                RegistrationDate = new DateTime(2018, 9, 10)
            };
            var user3 = new User()
            {
                
                Email = "it.efr99@gmail.com",
                PasswordHash = "123456789",
                RegistrationDate = new DateTime(2018, 8, 8)
            };

            var horse1 = new Horse()
            {
                Id = 1,
                Age = 15,
                WinsCount = 43,
                LossesCount = 12,
                Weight = 380,
                HorseName = "Junky"
            };
            var horse2 = new Horse()
            {
                Id = 2,
                Age = 13,
                WinsCount = 65,
                LossesCount = 1,
                Weight = 450,
                HorseName = "Sonic"
            };
            var horse3 = new Horse()
            {
                Id = 3,
                Age = 20,
                WinsCount = 43,
                LossesCount = 42,
                Weight = 553,
                HorseName = "Marco"
            };

            var ftTeam1 = new FootballTeam()
            {
                Id = 1,
                WinsCount = 23,
                LossesCount = 16,
                TeamName = "Spark"
            };
            var ftTeam2 = new FootballTeam()
            {
                Id = 2,
                WinsCount = 30,
                LossesCount = 1,
                TeamName = "OG"
            };
            var ftTeam3 = new FootballTeam()
            {
                Id = 3,
                WinsCount = 14,
                LossesCount = 16,
                TeamName = "Bizons"
            };

            var btTeam1 = new BasketballTeam()
            {
                Id = 1,
                LossesCount = 4,
                TeamName = "Team Liquid",
                WinsCount = 10
            };
            var btTeam2 = new BasketballTeam()
            {
                Id = 2,
                LossesCount = 15,
                TeamName = "EG",
                WinsCount = 2
            };
            var btTeam3 = new BasketballTeam()
            {
                Id = 3,
                LossesCount = 1,
                TeamName = "Virtus",
                WinsCount = 18
            };

            //  This method will be called after migrating to the latest version.
            var users = new List<User>
            {
                user1,
                user2,
                user3
            };
            var horses = new List<Horse>
            {
                horse1,
                horse2,
                horse3
            };
            var ftTeams = new List<FootballTeam>
            {
                ftTeam1,
                ftTeam2,
                ftTeam3
            };
            var btTeams = new List<BasketballTeam>
            {
                btTeam1,
                btTeam2,
                btTeam3
            };


            //Users
            context.Users.AddOrUpdate(x => x.Id,
                user1,
                user2,
                user3);

            //Bets
            context.Bets.AddOrUpdate(x => x.Id,
                new Bet() { BetDate = DateTime.Today, BetItemType = ItemType.Horse, Coefficient = 9.25, User = user1},
                new Bet() { BetDate = DateTime.Today, BetItemType = ItemType.Football, Coefficient = 2.78, User = user2},
                new Bet() { BetDate = DateTime.Today, BetItemType = ItemType.Basketball, Coefficient = 3.45, User = user3});
            
            //Horses
            context.Horses.AddOrUpdate(x => x.Id,
                horse1,
                horse2,
                horse3);
            
            //Football Teams
            context.FootballTeams.AddOrUpdate(x => x.Id,
                ftTeam1,
                ftTeam2,
                ftTeam3);
            
            //Basketball Teams
            context.BasketballTeams.AddOrUpdate(x => x.Id,
                btTeam1,
                btTeam2,
                btTeam3);
        }
    }
}
