using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class AjaxDropdownDemoInput
    {
        [Required]
        public int? Country { get; set; }
        
        [UIHint("AjaxDropdown")]
        [Required]
        public int? Hobby { get; set; }
        
        [UIHint("AjaxDropdown")]
        [DisplayName("this uses Guid as a key")]
        [AjaxDropdown(Controller = "HobbyGuidAjaxDropdown")]
        public Guid? HobbyGuid { get; set; }

        public int? Show { get; set; }

        [UIHint("AjaxDropdown")]
        [AjaxDropdown(Controller = "PersonAjaxDropDown",  ParentId = "Show")]
        public int? Character { get; set; }
    }
}