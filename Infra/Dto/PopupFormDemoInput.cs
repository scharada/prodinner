using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class PopupFormDemoInput
    {
        [Required]
        public string Name { get; set; }

        [DisplayName("Say something")]
        public string SaySomething { get; set; }
    }
}