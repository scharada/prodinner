using System.ComponentModel.DataAnnotations;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class CountryInput : EntityEditInput
    {
        [Required]
        public string Name { get; set; }
    }
}