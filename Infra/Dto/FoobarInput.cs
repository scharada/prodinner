using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class FoobarInput : EntityEditInput
    {
        [Required]
        public string Name { get; set; }
        
        [UIHint("lookup")]
        [Lookup(Title = "type 'a', hit enter/click search")]
        [Required]
        public int? Person { get; set; }

        [UIHint("lookup")]
        [Lookup(Controller = "PersonLookup", Title = "type 'a', hit enter/click search")]
        public int? Person2 { get; set; }

        [UIHint("AjaxDropdown")]
        public int? Show { get; set; }

        [UIHint("AjaxDropdown")]
        [AjaxDropdown(Controller = "PersonAjaxDropdown", ParentId = "Show")]
        public int? Character { get; set; }

        [UIHint("Autocomplete")]
        [Autocomplete(MaxResults = 7)]
        public string Hobby { get; set; }

        /// <summary>
        /// this is used toghether with Hobby, it's the key for the autocomplete
        /// </summary>
        public int? HobbyId { get; set; }

    }
}