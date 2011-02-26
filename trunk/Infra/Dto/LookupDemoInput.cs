using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class Team
    {
        [UIHint("Lookup")]
        [DisplayName("The inside person")]
        [Lookup(Controller = "PersonLookup")]
        public int? ThePerson { get; set; }
    }

    public class LookupDemoInput
    {
        public Team Team { get; set; }

        [UIHint("Lookup")]
        [DisplayName("Person")]
        [Lookup(Paging = true, Title = "type 'a', hit enter/click search", Fullscreen = true)]
        public int? Person { get; set; }

        [UIHint("Lookup")]
        [Lookup(Title = "drag and drop items, up and down", Fullscreen = true, Multiselect = true, Controller = "PersonaLookup")]
        public IEnumerable<int> People { get; set; }

        [Required]
        public int? CountryId { get; set; }

        [UIHint("Lookup")]
        [DisplayName("Hobbies")]
        [Lookup(Paging = true, Controller = "HobbyLookup", Title = "write some letters from the start, hit enter/click search", Multiselect = true, Fullscreen = true, ClearButton = true)]
        [Required]
        public IEnumerable<int> Hobbies { get; set; }

        [UIHint("Lookup")]
        [DisplayName("this uses Guid as key")]
        [Lookup(Title = "write some letters from the start, hit enter/click search", Controller = "HobbyGuidLookup", ClearButton = true)]
        [Required]
        public Guid? HobbyGuid { get; set; }

        [UIHint("AjaxDropdown")]
        public int? Show { get; set; }

        [UIHint("Lookup")]
        [Lookup(Multiselect = true, Fullscreen = true)]
        public IEnumerable<int> Characters { get; set; }
    }
}