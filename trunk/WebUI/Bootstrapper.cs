using System.Web.Mvc;
using System.Web.Routing;
using Omu.AwesomeDemo.Infra;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.WebUI
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
            Settings.PopupForm.ClientSideValidation = true;
        }
    }
}