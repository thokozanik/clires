using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Data.UOW;

namespace Tateeda.Clires.System
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            var container = BuildAutofacContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        ///   Builds the Autofac container.
        /// </summary>
        /// <returns> </returns>
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register<IDbContext>(c => new Entities()).InstancePerDependency();
            builder.Register<IAdminUnitOfWork>(r => new AdminUnitOfWork(r.Resolve<IDbContext>())).InstancePerDependency();
            builder.Register<IUtilUnitOfWork>(r => new UtilUnitOfWork(r.Resolve<IDbContext>())).InstancePerDependency();
            var container = builder.Build();
            return container;
        }
    }
}