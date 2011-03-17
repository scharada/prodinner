using Omu.ProDinner.Resources;

namespace Omu.ProDinner.WebUI
{
    public static class AwesomeMui
    {
        public static string GetTranslate(string type, string key)
        {
            //if (type == "Confirm" && key == "Title") return "please confirm";
            //if (type == "PopupForm" && key == "Title") return "fill the form, hit ok";
            //if (type == "Lookup" && key == "Title") return "select something";
            switch (key)
            {
                case "Cancel": return Mui.Cancel;
                case "Yes": return Mui.Yes;
                case "No": return Mui.No;
                case "More": return Mui.more;
            }
            return null;
        }
    }
}