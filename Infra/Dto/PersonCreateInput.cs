using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class PersonCreateInput
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Birth")]
        public DateTime DateOfBirth { get; set; }

        [UIHint("AjaxDropdown")]
        [Required]
        public int? Country { get; set; }        
        
        [UIHint("Lookup")]
        [Required]
        [Lookup(Controller = "CountryIdLookup", Title = "write some letters from the start, hit enter/click search")]
        public int? Home { get; set; }
        
        [UIHint("Lookup")]
        [Lookup(Controller = "HobbyLookup", Title = "write some letter from the start, hit enter/click search", Multiselect = true)]
        public IEnumerable<int> Hobbies { get; set; }
    }
}