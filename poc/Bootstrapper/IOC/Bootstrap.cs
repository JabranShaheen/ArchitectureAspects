using Unity;
using EntityAbstractions.Entities;
using BLL.Entities;
using DataService.Entities;
using EntityManagerAbstractions.EntityManagers;
using EntityManager;
using Unity.Injection;
using EntitiyChangeLog;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.InterceptionBehaviors;
using System;

namespace Bootstrapper.IOC
{
    public class Bootstrap
    {
        public static void Register(IUnityContainer unityContainer)
        {
            //unityContainer.AddNewExtension<Interception>();
            //unityContainer.RegisterType(typeof(AbstractProduct), typeof(Product));
            //unityContainer.RegisterType(typeof(AbstractCustomer), typeof(Customer));

            ////unityContainer.RegisterType(typeof(IDataService<>), typeof(EntityDataService<>));
            //unityContainer.RegisterType(typeof(IEntityManager<>), typeof(GenericEntityManager<>));

            //unityContainer.RegisterType<IEntityManager<AbstractOrder>, OrderManager>
            //(
            //     new Unity.Lifetime.ContainerControlledLifetimeManager(),
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ChangeLogBehaviour<AbstractOrder, AbstractEntityChangeLog>>()
            //);


        }
    }
}
