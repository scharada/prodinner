using System;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;

namespace SimpleDemo.Models
{
    public class Person
    {
        [UIHint("Lookup")]
        [Lookup(Title = "double click a country", Height = 300, Width = 300)]
        public int Country { get; set; }
        
        [UIHint("AjaxDropdown")]
        public int Hobby { get; set; }
    }
}