using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

using PatientManager.Data;
using PatientManager.Data.Model;
using PatientManager.Service;

namespace PatientManager.WebAPI.App_Start
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver()
            : this(new StandardKernel())
        {

        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {

            kernel.Bind(typeof(I_RepositoryCRUD<>)).To(typeof(RepositoryCrud<>)).InSingletonScope();
           
            kernel.Bind<IPatientService>().To<PatientService>().InSingletonScope();
            kernel.Bind<IComtabService>().To<ComtabService>().InSingletonScope();
            kernel.Bind<IRendezvousService>().To<RendezvousService>().InSingletonScope();

            return kernel;
        }
    }
}
