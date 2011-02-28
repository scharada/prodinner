using NUnit.Framework;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Data;

namespace Omu.ProDinner.Tests
{
    public class RepoTest : IntegrationTestsBase
    {
        [Test]
        public static void TestInsert()
        {
            var r = new Repo<Country>(new DbContextFactory());
            var c = new Country {Name = "Asaaa"};
            r.Insert(c);
            r.Save();
            var cFromDb = r.Get(c.Id);
            Assert.AreEqual(c.Name, cFromDb.Name);
        }

        [Test]
        public static void TestRemove()
        {
            var r = new Repo<Country>(new DbContextFactory());
            var c = new Country {Name = "AsaaaRemove"};
            r.Insert(c);
            r.Save();

            r.Delete(c);
            r.Save();

            var cDb = r.Get(c.Id);
            Assert.IsNull(cDb);
        }

        [Test]
        public static void TestUpdate()
        {
            var r = new Repo<Country>(new DbContextFactory());
            var c = new Country {Name = "Asaaa"};
            r.Insert(c);
            r.Save();

            c.Name = "Lulu";
            r.Save();

            var cFromDb = r.Get(c.Id);
            Assert.AreEqual(c.Name, cFromDb.Name);
        }
    }
}