using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;
using Omu.ProDinner.Resources;

namespace Omu.ProDinner.Infra.Dto
{
    public class Input
    {
        public int Id { get; set; }
    }

    public class CountryInput : Input
    {
        [Req]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }
    }

    public class ChefInput : Input
    {
        [Req]
        [StrLen(15)]
        [Display(ResourceType = typeof(Mui), Name = "First_Name")]
        public string FirstName { get; set; }

        [Req]
        [StrLen(15)]
        [Display(ResourceType = typeof(Mui), Name = "Last_Name")]
        public string LastName { get; set; }

        [Req]
        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name = "Country")]
        public int? CountryId { get; set; }
    }

    public class MealInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Comments")]
        public string Comments { get; set; }
    }

    public class DinnerInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name="Name")]
        public string Name { get; set; }

        [Req]
        [UIHint("Lookup")]
        [Display(ResourceType = typeof(Mui), Name="Country")]
        public int? CountryId { get; set; }

        [Req]
        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name="Chef")]
        public int? ChefId { get; set; }

        [Req]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name="Address")]
        public string Address { get; set; }

        [Req]
        [Display(ResourceType = typeof(Mui), Name="Date")]
        public DateTime? Date { get; set; }

        [Req]
        [UIHint("Lookup")]
        [Lookup(Multiselect = true, Fullscreen = true)]
        [Display(ResourceType = typeof(Mui), Name="Meals")]
        public IEnumerable<int> Meals { get; set; }
    }

    public class CropInput
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public int Id { get; set; }
    }

    public class ReqAttribute : RequiredAttribute
    {
        public ReqAttribute()
        {
            ErrorMessageResourceName = "required";
            ErrorMessageResourceType = typeof(Mui);
        }
    }

    public class StrLenAttribute : StringLengthAttribute
    {
        public StrLenAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessageResourceName = "strlen";
            ErrorMessageResourceType = typeof (Mui);
        }
    }
}