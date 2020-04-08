using Employer.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Employer
{
    public static class UnityConfig
    {
        public static IUnityContainer Container;
        public static void RegisterComponents()
        {
			Container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            Container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            Container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}