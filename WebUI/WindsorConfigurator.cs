using Omu.AwesomeDemo.Core.Model;
using Omu.AwesomeDemo.Core.Service;
using Omu.AwesomeDemo.Infra.Builder;
using Omu.AwesomeDemo.Infra.Dto;
using Omu.AwesomeDemo.Service;
using Omu.AwesomeDemo.Infra;

namespace Omu.AwesomeDemo.WebUI
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