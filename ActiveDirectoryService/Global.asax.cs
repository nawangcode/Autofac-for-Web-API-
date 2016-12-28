using System.Web.Http;

namespace ActiveDirectoryService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            var autofacWebApiResolver = IoCConfig.RegisterDependencies(Server);
            config.DependencyResolver = autofacWebApiResolver;

        }
    }
}
