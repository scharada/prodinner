using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace Omu.AwesomeDemo.Infra.Dto
{
    public class UserInput : EntityEditInput
    {
        [Required]
        public string Name { get; set; }

        [UIHint("lookup")]
        [Lookup(Multiselect = true, Fullscreen = true)]
        [Required(ErrorMessage = "please select at least one role")]
        public IEnumerable<int> Roles { get; set; }
    }
}