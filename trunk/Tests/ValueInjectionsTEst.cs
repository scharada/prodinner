using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Data;
using Omu.ProDinner.Infra;
using Omu.ProDinner.Infra.Builder;
using Omu.ProDinner.Infra.Dto;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Tests
{
    public class ValueInjectionsTest
    {
        [Test]
        public void EntitiesToIntsTest()
        {
            var s = new Dinner { Meals = new List<Meal> { new Meal { Id = 3 }, new Meal { Id = 7 } } };

            var t = new DinnerInput();

            t.InjectFrom<EntitiesToInts>(s);

            Assert.IsNotNull(t.Meals);
            Assert.AreEqual(2, t.Meals.Count());
            Assert.AreEqual(3, t.Meals.First());
        }

        [Test]
        public void IntsToEntities()
        {
            WindsorRegistrar.RegisterSingleton(typeof(IRepo<>), typeof(Repo<>));
            WindsorRegistrar.RegisterSingleton(typeof(IDbContextFactory), typeof(DbContextFactory));
            using (var scope = new TransactionScope())
            {
                var repo = new Repo<Meal>(new DbContextFactory());
                var m1 = new Meal { Name = "a" };
                var m2 = new Meal { Name = "b" };

                repo.Insert(m1);
                repo.Insert(m2);
                repo.Save();

                var s = new DinnerInput { Meals = new List<int> { m1.Id, m2.Id } };
                var t = new Dinner();

                t.InjectFrom<IntsToEntities>(s);

                Assert.IsNotNull(t.Meals);
                Assert.AreEqual(2, t.Meals.Count);
                Assert.AreEqual(m1.Id, t.Meals.First().Id);
            }
        }

        [Test]
        public void EntityToNullInt()
        {

            var s = new Dinner { Country = new Country { Id = 43 }, Chef = new Chef { Id = 7 } };
            var t = new DinnerInput();
            t.InjectFrom<EntityToNullInt>(s);

            Assert.AreEqual(s.Country.Id, t.Country);
            Assert.AreEqual(s.Chef.Id, t.Chef);
        }

        [Test]
        public void NullIntToEntity()
        {
            WindsorRegistrar.RegisterSingleton(typeof(IRepo<>), typeof(Repo<>));
            WindsorRegistrar.RegisterSingleton(typeof(IDbContextFactory), typeof(DbContextFactory));
            using (var scope = new TransactionScope())
            {
                var rChef = new Repo<Chef>(new DbContextFactory());
                var chef = new Chef {Id = 33, FName = "a", LName = "b"};
                rChef.Insert(chef);
                rChef.Save();

                var rCountry = new Repo<Country>(new DbContextFactory());
                var country = new Country {Id = 44, Name = "Ua"};
                rCountry.Insert(country);
                rCountry.Save();

                
                var s = new DinnerInput {Chef = chef.Id, Country = country.Id};
                var t = new Dinner();

                t.InjectFrom<NullIntToEntity>(s);

                Assert.AreEqual(s.Chef, t.Chef.Id);
                Assert.AreEqual(s.Country, t.Country.Id);
            }

        }
    }
}