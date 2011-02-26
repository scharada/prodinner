using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class AutocompleteDemoInput
    {
        public string Person { get; set; }
        public int? PersonId { get; set; }
        
        [Required]
        public string Show2 { get; set; }

        [Required]
        public string Show { get; set; }
        public int? ShowId { get; set; }

        [UIHint("Autocomplete")]
        [Autocomplete(Controller = "PersonAutocomplete", ParentId = "ShowId")]
        public string Character { get; set; }
        public int? CharacterId { get; set; }

        public string Character2 { get; set; }

        [Required(ErrorMessage = "the value wasn't selected from the autocomplete list")]
        public int? Character2Id { get; set; }
    }
}