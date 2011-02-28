using System;
using Castle.MicroKernel.Registration;

namespace Omu.ProDinner.Infra
{
    public class WindsorRegistrar
    {
        public static void Register(Type interfaceType, Type implementationType)
        {
            IoC.Container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.PerWebRequest);
        }

        public static void RegisterAllFromAssemblies(string a)
        {
            IoC.Container.Register(AllTypes.FromAssemblyNamed(a).Pick()
                                  .WithService.DefaultInterface()
                                  .Configure(c => c.LifeStyle.PerWebRequest));
        }
    }
}
