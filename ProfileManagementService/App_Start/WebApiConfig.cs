using ProfileManagementService.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace ProfileManagementService
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			UnityContainer container = new UnityContainer();
			container.RegisterType<IProfileService, ProfileService>();
			container.RegisterType<IProfileOperations, ProfileOperations>();
			config.DependencyResolver = new UnityResolver(container);
		}
	}
}
