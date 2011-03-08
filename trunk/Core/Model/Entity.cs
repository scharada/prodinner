using System;
using System.Collections.Generic;

namespace Omu.ProDinner.Core.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Country : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Chef> Chefs { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
    }

    public class Meal : Entity
    {
        public string Name { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
        public bool HasPic { get; set; }
    }

    public class Chef : Entity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
    }

    public class Dinner : Entity
    {
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual Chef Chef { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}