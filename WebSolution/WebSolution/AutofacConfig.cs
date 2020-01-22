using Autofac;
using Autofac.Integration.Mvc;
using Library.Implementations;
using Library.Interfaces;
using System.Web.Mvc;

namespace WebSolution
{
    public class AutofacConfig 
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ExcelDataSaver>()
                .As<IDataSaver>()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

    }
}