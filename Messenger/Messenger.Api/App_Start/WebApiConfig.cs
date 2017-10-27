using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Messenger.Api.Handlers;
namespace Messenger.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.MessageHandlers.Add(new LoggingHandler());
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
