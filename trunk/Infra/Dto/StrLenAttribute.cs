using System.ComponentModel.DataAnnotations;
using Omu.ProDinner.Resources;

namespace Omu.ProDinner.Infra.Dto
{
    public class StrLenAttribute : StringLengthAttribute
    {
        public StrLenAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessageResourceName = "strlen";
            ErrorMessageResourceType = typeof (Mui);
        }
    }
}