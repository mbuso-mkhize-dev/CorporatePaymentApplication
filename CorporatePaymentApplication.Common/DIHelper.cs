using CorporatePaymentApplication.ApplicationLogic.Service;
using CorporatePaymentApplication.ApplicationLogic.Service.Interface;
using CorporatePaymentApplication.Repository;
using CorporatePaymentApplication.Repository.Models;
using CorporatePaymentApplication.Repository.Repositories;
using CorporatePaymentApplication.Repository.Repositories.Interfaces;
using Unity;
using Unity.Lifetime;

namespace CorporatePaymentApplication.Common
{
    public static class DIHelper
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Database context, one per request, ensure it is disposed

            RegisterComponents<HierarchicalLifetimeManager>(container);
            //container.BindInRequestScope<ISessionHelper, SessionHelper>();

            return container;
        }

        public static void RegisterComponents<T>(UnityContainer container) where T : LifetimeManager, new()
        {
            container.RegisterType<IRepository<CorporatePayment>, DBRepository<CorporatePayment>>(new T());
            container.RegisterType<ITransactionService, TrasactionService>(new T());
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new T());
        }
    }
}