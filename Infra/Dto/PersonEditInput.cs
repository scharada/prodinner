using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class PersonEditInput : EntityEditInput
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [UIHint("AjaxDropdown")]
        [Required]
        public int? Country { get; set; }

        [UIHint("Lookup")]
        [Required]
        [Lookup(Controller = "CountryIdLookup", ClearButton = false)]
        public int? Home { get; set; }

        [UIHint("Lookup")]
        [Lookup(Controller = "HobbyLookup", Title = "write some letter from the start, hit enter/click search", Multiselect = true)]
        public IEnumerable<int> Hobbies { get; set; }
    }
}