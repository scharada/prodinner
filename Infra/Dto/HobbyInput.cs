using System.ComponentModel.DataAnnotations;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class HobbyInput : EntityEditInput
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}