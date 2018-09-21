using BusinessLayer;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace TaskManagerWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = new Container();
            container.Register<IUserService, UserService>();
            container.Register<IProjectService, ProjectService>();
            container.Register<ITaskService, TaskService>();
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
