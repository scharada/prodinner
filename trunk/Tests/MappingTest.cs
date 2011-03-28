using System;
using NUnit.Framework;
using Omu.Encrypto;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ProDinner.Data;
using System.Collections.Generic;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Tests
{
    public class MappingTest : IntegrationTestsBase
    {
        private UniRepo u;

        [SetUp]
        public void Start()
        {
            u = new UniRepo(new DbContextFactory());
        }

        [Test]
        public void AutoTest()
        {
            var types = new[]
                            {
                                typeof (Dinner), 
                                typeof (Meal), 
                                typeof (Chef), 
                                typeof (Country), 
                                typeof (User), 
                                typeof (Role), 
                            };

            foreach (var type in types)
            {
                Console.WriteLine("testing " + type.Name);
                dynamic o = Activator.CreateInstance(type).InjectFrom(new Fill(u));
                u.Insert(o);
                u.Save();
                Assert.IsTrue(o.Id != 0);
                Console.WriteLine(type.Name + " ok");
            }
        }
    }

    public class Fill : NoSourceValueInjection
    {
        private readonly IUniRepo u;

        private static long s;
        private static int i;
        private readonly bool isChild;

        public Fill(IUniRepo u, bool isChild = false)
        {
            this.u = u;
            this.isChild = isChild;
        }

        protected override void Inject(object target)
        {
            var props = target.GetProps();
            for (var j = 0; j < props.Count; j++)
            {
                var p = props[j];
                if (p.PropertyType == typeof(string)) p.SetValue(target, "a" + ++s);
                else if (p.PropertyType == typeof(int) && !p.Name.EndsWith("Id")) p.SetValue(target, ++i);
                else if (p.PropertyType == typeof(DateTime)) p.SetValue(target, DateTime.Now);
                else if (p.PropertyType.IsSubclassOf(typeof(DelEntity)))
                {
                    dynamic o = Activator.CreateInstance(p.PropertyType).InjectFrom(new Fill(u, true));
                    u.Insert(o);
                    u.Save();
                    p.SetValue(target, o);
                }
                else if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) && !isChild)
                {
                    var t = p.PropertyType.GetGenericArguments()[0];
                    if (!t.IsSubclassOf(typeof(DelEntity))) continue;

                    var tlist = typeof(List<>).MakeGenericType(t);
                    dynamic list = Activator.CreateInstance(tlist);
                    for (var k = 0; k < 3; k++)
                    {
                        dynamic o = Activator.CreateInstance(t).InjectFrom(new Fill(u, true));
                        u.Insert(o);
                        u.Save();
                        list.Add(o);
                    }
                    p.SetValue(target, list);
                }
            }
        }
    }
}