using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;
using FluentValidation.WebApi;

namespace SportBets.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Fluent Validation
            FluentValidationModelValidatorProvider.Configure(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            #region HorseApi

            config.Routes.MapHttpRoute(
                name: "HorsApi",
                routeTemplate: "controller/action/",
                defaults: new {controller = "Horse", action = "CreateHorse"});

            config.Routes.MapHttpRoute(
                name: "HoseApi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "Horse", action = "DeleteHorse" });

            config.Routes.MapHttpRoute(
                name: "HorseApi",
                routeTemplate: "controller/action/{age}",
                defaults: new {controller = "Horse", action = "ByAge"});

            config.Routes.MapHttpRoute(
                name: "HorseAp",
                routeTemplate: "controller/action/{weight}",
                defaults: new {controller = "Horse", action = "ByWeight"});

            config.Routes.MapHttpRoute(
                name: "HorseAi",
                routeTemplate: "controller/action/{wins}",
                defaults: new {controller = "Horse", action = "ByWins"});

            config.Routes.MapHttpRoute(
                name: "HorsePi",
                routeTemplate: "controller/action/{losses}",
                defaults: new {controller = "Horse", action = "ByLosses"});

            config.Routes.MapHttpRoute(
                name: "Horse",
                routeTemplate: "controller/action/{name}",
                defaults: new {controller = "Horse", action = "ByName"});

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "controller/action/{id}",
                defaults: new {controller = "Horse", action = "ById"}
            );

            #endregion

            #region FootballTeamApi

            config.Routes.MapHttpRoute(
                name: "FootbalTeamApi",
                routeTemplate: "controller/action/",
                defaults: new { controller = "FootballTeam", action = "CreateTeam" });

            config.Routes.MapHttpRoute(
                name: "FotballTeamApi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "FootballTeam", action = "DeleteTeam" });

            config.Routes.MapHttpRoute(
                name: "FootballTeamApi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "FootballTeam", action = "ById" });

            config.Routes.MapHttpRoute(
                name: "FootballTeamAp",
                routeTemplate: "controller/action/{name}",
                defaults: new { controller = "FootballTeam", action = "ByName" });

            config.Routes.MapHttpRoute(
                name: "FootballTeamAi",
                routeTemplate: "controller/action/{wins}",
                defaults: new { controller = "FootballTeam", action = "ByWins" });

            config.Routes.MapHttpRoute(
                name: "FootballTeamPi",
                routeTemplate: "controller/action/{losses}",
                defaults: new { controller = "FootballTeam", action = "ByLosses" });

            #endregion

            #region BasketballTeamApi

            config.Routes.MapHttpRoute(
                name: "BasketballTeamApi",
                routeTemplate: "controller/action/",
                defaults: new {controller = "BasketballTeam", action = "CreateTeam"});

            config.Routes.MapHttpRoute(
                name: "BasketballTeamAp",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "BasketballTeam", action = "DeleteTeam" });

            config.Routes.MapHttpRoute(
                name: "BasketballTeamAi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "BasketballTeam", action = "ById" });

            config.Routes.MapHttpRoute(
                name: "BasketballTeampi",
                routeTemplate: "controller/action/{name}",
                defaults: new { controller = "BasketballTeam", action = "ByName" });

            config.Routes.MapHttpRoute(
                name: "BasketbalTeamApi",
                routeTemplate: "controller/action/{wins}",
                defaults: new { controller = "BasketballTeam", action = "ByWins" });

            config.Routes.MapHttpRoute(
                name: "BasktballTeamApi",
                routeTemplate: "controller/action/{losses}",
                defaults: new { controller = "BasketballTeam", action = "ByLosses" });

            #endregion

            #region UserApi

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "controller/action/",
                defaults: new {controller = "User", action = "CreateUser"});

            config.Routes.MapHttpRoute(
                name: "Userpi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "User", action = "DeleteUser" });

            config.Routes.MapHttpRoute(
                name: "UserAp",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "User", action = "ById" });

            config.Routes.MapHttpRoute(
                name: "UserAi",
                routeTemplate: "controller/action/{date}",
                defaults: new { controller = "User", action = "ByReg" });

            config.Routes.MapHttpRoute(
                name: "UsrApi",
                routeTemplate: "controller/action/",
                defaults: new { controller = "User", action = "AllUsers" });

            config.Routes.MapHttpRoute(
                name: "serApi",
                routeTemplate: "controller/action/",
                defaults: new { controller = "User", action = "Count" });

            #endregion

            #region BetApi

            config.Routes.MapHttpRoute(
                name: "BetApi",
                routeTemplate: "controller/action/",
                defaults: new {controller = "Bet", action = "CreateBet"});

            config.Routes.MapHttpRoute(
                name: "BetAp",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "Bet", action = "DeleteBet" });

            config.Routes.MapHttpRoute(
                name: "BetAi",
                routeTemplate: "controller/action/{id}",
                defaults: new { controller = "Bet", action = "ById" });

            config.Routes.MapHttpRoute(
                name: "Betpi",
                routeTemplate: "controller/action/{type}",
                defaults: new { controller = "Bet", action = "ByType" });

            config.Routes.MapHttpRoute(
                name: "BeApi",
                routeTemplate: "controller/action/{date}",
                defaults: new { controller = "Bet", action = "ByDate" });

            config.Routes.MapHttpRoute(
                name: "BtApi",
                routeTemplate: "controller/action/",
                defaults: new { controller = "Bet", action = "AllBets" });

            #endregion

        }
    }
}
