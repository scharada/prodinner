using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Service;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;
using Omu.ProDinner.Service;
using Omu.ProDinner.Infra;

namespace Omu.ProDinner.WebUI
{
    public class WindsorConfigurator
    {
        public static void Configure()
        {
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.Data");
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Omu.ProDinner.Infra");
        }
    }
}