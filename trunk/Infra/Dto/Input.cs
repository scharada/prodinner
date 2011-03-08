using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Core.Model;

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
    public class ChefInput:Input
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [UIHint("AjaxDropdown")]
        public int? Country { get; set; }
    }
    public class MealInput:Input
    {
        [Required]
        public string Name{ get; set;}
        public string Comments { get; set; }
    }
    public class DinnerInput:Input
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("Lookup")]
        public int?  Country { get; set; }
        [Required]
        [UIHint("AjaxDropdown")]
        public int?  Chef { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [UIHint("Lookup")]
        [Lookup(Multiselect = true, Fullscreen = true)]
        public IEnumerable<int> Meals { get; set; }
    }

    public class CropInput
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public int Id { get; set; }
    }
}