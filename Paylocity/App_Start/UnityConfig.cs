using Paylocity.Interfaces;
using Paylocity.Services;
using Paylocity.Services.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Paylocity
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<ICalculationService, CalculationService>();
            container.RegisterType<IDeductionByType, DeductionByType>();
            container.RegisterType<IDiscountCalculator, DiscountCalculator>();
            container.RegisterType<IDeductionCalculator, DeductionCalculator>();
        }
    }
}