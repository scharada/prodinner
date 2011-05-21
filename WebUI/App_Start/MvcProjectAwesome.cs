using System.Web.Mvc;
using Omu.Awesome.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Omu.ProDinner.WebUI.App_Start.MvcProjectAwesome), "Start")]
namespace Omu.ProDinner.WebUI.App_Start
{    
    public static class MvcProjectAwesome
    {
        public static void Start()
        {
            ModelMetadataProviders.Current = new AwesomeModelMetadataProvider();
        }
    }
}