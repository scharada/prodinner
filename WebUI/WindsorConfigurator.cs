using Omu.Encrypto;
using Omu.ProDinner.Core.Security;
using Omu.ProDinner.Infra;
using Omu.ProDinner.WebUI.Controllers;

namespace Omu.ProDinner.WebUI
{
    public class WindsorConfigurator
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IFormsAuthentication), typeof(FormAuthService));
            WindsorRegistrar.Register(typeof(IHasher), typeof(Hasher));
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.Data");
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.WebUI");
        }
    }
}