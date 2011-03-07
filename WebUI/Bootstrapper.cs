using System.Web.Mvc;
using System.Web.Routing;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Infra;

namespace Omu.ProDinner.WebUI
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            RouteConfigurator.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
            WindsorConfigurator.Configure();
            ModelMetadataProviders.Current = new AwesomeModelMetadataProvider();

            Settings.Confirm.NoText = "No";
            Settings.PopupForm.OkText = "Submit";
            Settings.PopupForm.ClientSideValidation = false;
        }
    }
}