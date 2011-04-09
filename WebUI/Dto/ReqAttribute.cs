using System.ComponentModel.DataAnnotations;
using Omu.ProDinner.Resources;

namespace Omu.ProDinner.WebUI.Dto
{
    public class ReqAttribute : RequiredAttribute
    {
        public ReqAttribute()
        {
            ErrorMessageResourceName = "required";
            ErrorMessageResourceType = typeof(Mui);
        }
    }
}