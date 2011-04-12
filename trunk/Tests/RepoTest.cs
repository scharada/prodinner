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
            var o = r.Get(c.Id);
            Assert.AreEqual(c.Name, o.Name);
        }

        [Test]
        public static void TestRemove()
        {
            var r = new Repo<Country>(new DbContextFactory());
            var c = new Country {Name = "a"};
            r.Insert(c);
            r.Save();

            r.Delete(c);
            r.Save();

            var o = r.Get(c.Id);
            Assert.IsTrue(o.IsDeleted);
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

            var o = r.Get(c.Id);
            Assert.AreEqual(c.Name, o.Name);
        }
    }
}