using Autofac;
using Autofac.Integration.WebApi;
using System.Web;
using System.Web.Mvc;

namespace ActiveDirectoryService
{
    public sealed class IoCConfig
	{
		private IoCConfig() { }

		public static AutofacWebApiDependencyResolver RegisterDependencies(HttpServerUtility httpserver)
		{
			#region Create the builder
			var builder = new ContainerBuilder();
			#endregion

			#region Setup a common pattern
			//placed here before RegisterControllers as last one wins

			builder.RegisterAssemblyTypes(
				typeof(ServiceImplementation.ActiveDirectorySync).Assembly,
				typeof(ServiceContracts.IActiveDirectorySync).Assembly
				)
//					.Where(t => t.Name.EndsWith("Service"))
				   .AsImplementedInterfaces()
				   .AsSelf()
				   .InstancePerRequest();
            #endregion

			#region Register API controllers for the assembly

			// Register your Web API controllers.
			builder.RegisterApiControllers(typeof(WebApiApplication).Assembly)
				   .InstancePerRequest();

			// OPTIONAL: Register the Autofac filter provider.
			//builder.RegisterWebApiFilterProvider(config);

			#endregion



			#region Register modules

			builder.RegisterAssemblyModules(typeof(WebApiApplication).Assembly);
			builder.RegisterAssemblyModules(typeof(ServiceImplementation.ActiveDirectorySync).Assembly);
			builder.RegisterAssemblyModules(typeof(ServiceContracts.IActiveDirectorySync).Assembly);
			#endregion

			#region Model binder providers - excluded - not sure if need
			//builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
			//builder.RegisterModelBinderProvider();
			#endregion

			#region Inject HTTP Abstractions
			/*
			 The MVC Integration includes an Autofac module that will add HTTP request 
			 lifetime scoped registrations for the HTTP abstraction classes. The 
			 following abstract classes are included: 
			-- HttpContextBase 
			-- HttpRequestBase 
			-- HttpResponseBase 
			-- HttpServerUtilityBase 
			-- HttpSessionStateBase 
			-- HttpApplicationStateBase 
			-- HttpBrowserCapabilitiesBase 
			-- HttpCachePolicyBase 
			-- VirtualPathProvider 

			To use these abstractions add the AutofacWebTypesModule to the container 
			using the standard RegisterModule method. 
			*/
			//builder.RegisterModule<AutofacWebTypesModule>();

			#endregion

			#region Set the MVC dependency resolver to use Autofac
			var container = builder.Build();

			return new AutofacWebApiDependencyResolver(container);
			#endregion
		}
	}
}
