using System.ComponentModel.DataAnnotations;

namespace Omu.ProDinner.Infra.Dto
{
    public class Input
    {
        public int Id { get; set; }
    }
    public class CountryInput:Input
    {
        [Required]
        public string Name { get; set;}
    }
}