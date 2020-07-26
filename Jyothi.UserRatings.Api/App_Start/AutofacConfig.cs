using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Jyothi.UserRatings.Api.Data;
using Jyothi.UserRatings.Api.Utilities;

namespace Jyothi.UserRatings.Api.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {
            //bldr.RegisterType<CampContext>()
            //  .InstancePerRequest();

            bldr.RegisterType<BeerRespository>()
              .As<IBeersRepository>()
              .InstancePerRequest();

            bldr.RegisterType<JsonUtility>()
              .As<IJsonUtility>()
              .InstancePerRequest();
        }
    }
}