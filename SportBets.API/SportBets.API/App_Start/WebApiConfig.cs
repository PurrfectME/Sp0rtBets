using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FluentValidation.WebApi;

namespace SportBets.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //Fluent Validation
            FluentValidationModelValidatorProvider.Configure(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "BetApi",
            //    routeTemplate: "{controller}/{action}/{id}/{itemtype}/{coefficient}/{betdate}/{user}",
            //    defaults: new {user = RouteParameter.Optional});
                

            //config.Routes.MapHttpRoute(
            //    name: "UserApi",
            //    routeTemplate: "{controller}/{action}/{id}/{email}/{passwordhash}/{registrationdate}",
            //    defaults:new {registrationDate = RouteParameter.Optional});


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
