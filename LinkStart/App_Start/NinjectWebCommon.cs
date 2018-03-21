using System;
using System.Web;
using LinkStart;
using LinkStart.Core;
using LinkStart.Core.Repositories;
using LinkStart.Persistence;
using LinkStart.Persistence.Repositories;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]



namespace LinkStart
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch 
            {   
                kernel.Dispose();
                throw;
            }

        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}