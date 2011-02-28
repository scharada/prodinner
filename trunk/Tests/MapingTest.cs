using System;
using NUnit.Framework;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Data;
using System.Collections.Generic;

namespace Omu.ProDinner.Tests
{
    public class MapingTest : IntegrationTestsBase
    {
        private UniRepo u;

        [SetUp]
        public void Start()
        {
            u = new UniRepo(new DbContextFactory());
        }

        [Test]
        public void CountryTest()
        {
            var c = new Country { Name = "LULU" };
            u.Insert(c);
            u.Save();

            Assert.AreEqual(c.Name, u.Get<Country>(c.Id).Name);
        }
        [Test]
        public void ChefTest()
        {
            var c = new Chef { LName = "Su", FName = "Vanea" };
            u.Insert(c);
            u.Save();

            Assert.AreEqual(c.LName, u.Get<Chef>(c.Id).LName);
            Assert.AreEqual(c.FName, u.Get<Chef>(c.Id).FName);
        }
        [Test]
        public void MealTest()
        {
            var c = new Meal { Name = "LULU" };
            u.Insert(c);
            u.Save();

            Assert.AreEqual(c.Name, u.Get<Meal>(c.Id).Name);
        }
        [Test]
        public void DinnerTest()
        {
            var country = new Country { Name = "ValiLandia" };
            u.Insert(country);

            var chef = new Chef { LName = "Valentini", FName = "Mazzixnii" };
            u.Insert(chef);

            var meals = new List<Meal> { new Meal { Name = "Catlete" } };
            meals.ForEach(o => u.Insert(o));
            u.Save();

            var c = new Dinner { Name = "LULU", Date = new DateTime(2008, 1, 1), Country = country, Chef = chef, Meals = meals };
            u.Insert(c);
            u.Save();

            Assert.AreEqual(c.Name, u.Get<Dinner>(c.Id).Name);
        }
    }
}