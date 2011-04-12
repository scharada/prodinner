using System;
using System.Collections.Generic;

namespace Omu.ProDinner.Core.Model
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public interface IDel
    {
        bool IsDeleted { get; set; }
    }

    public class DelEntity : Entity, IDel
    {
        public bool IsDeleted { get; set; }
    }

    public class Country : DelEntity
    {
        public string Name { get; set; }
    }

    public class Meal : DelEntity
    {
        public string Name { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
        public string Picture { get; set; }
    }

    public class Chef : DelEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }

    public class Dinner : DelEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }

    public class User : DelEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }

    public class Role : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}