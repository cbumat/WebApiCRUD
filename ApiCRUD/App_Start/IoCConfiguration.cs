using ApiCRUD.Data;
using ApiCRUD.Repositories;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace ApiCRUD.App_Start
{
    public class IoCConfiguration
    {
        public static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());          
        }

        private static void RegisterRepos(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
        }

        private static void RegisterClass(ContainerBuilder builder)
        {
            builder.Register(z => new UserContext()).InstancePerRequest();
        }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterControllers(builder);
            RegisterRepos(builder);
            RegisterClass(builder);
            IContainer container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}