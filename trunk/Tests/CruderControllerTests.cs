using System;
using FakeItEasy;
using NUnit.Framework;
using Omu.AwesomeDemo.Core;
using Omu.AwesomeDemo.Core.Model;
using Omu.AwesomeDemo.Core.Service;
using Omu.AwesomeDemo.Infra.Builder;
using Omu.AwesomeDemo.Infra.Dto;
using Omu.AwesomeDemo.WebUI.Controllers;
using System.Linq;

namespace Omu.AwesomeDemo.Tests
{
   public class CruderControllerTests
    {
        HobbyController c;

        [Fake]
#pragma warning disable 649
        IBuilder<Hobby, HobbyInput> v;
        [Fake]
        ICrudService<Hobby> s;
#pragma warning restore 649

       [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
            c = new HobbyController(s, v);
        }

        [Test]
        public void IndexShouldReturnViewCruds()
        {
            c.Index().ShouldBeViewResult().ViewName.ShouldEqual("cruds");
        }

        [Test]
        public void CreateShouldBuildNewInput()
        {
            c.Create();
            A.CallTo(() => v.BuildInput(A<Hobby>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void CreateShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Create(A.Fake<HobbyInput>()).ShouldBeViewResult();
        }

        [Test]
        public void CreateShouldReturnJson()
        {
            c.Create(A.Fake<HobbyInput>()).ShouldBeJson();
        }

        [Test]
        public void EditShouldReturnCreateView()
        {
            A.CallTo(() => s.Get(1)).Returns(A.Fake<Hobby>());
            c.Edit(1).ShouldBeViewResult().ShouldBeCreate();
            A.CallTo(() => s.Get(1)).MustHaveHappened();
        }

        [Test]
        public void EditShouldThrowException()
        {
            A.CallTo(() => s.Get(1)).Returns(null);
            Assert.Throws<AwesomeDemoException>(() => c.Edit(1));
            A.CallTo(() => v.BuildInput(A<Hobby>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public void EditShouldReturnJson()
        {
            c.Edit(A.Fake<HobbyInput>()).ShouldBeJson();
            A.CallTo(() => v.BuildEntity(A<HobbyInput>.Ignored, A<int>.Ignored)).MustHaveHappened();
            A.CallTo(() => s.Save(A<Hobby>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void EditShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Edit(A.Fake<HobbyInput>()).ShouldBeViewResult().ShouldBeCreate();
            A.CallTo(() => v.RebuildInput(A<HobbyInput>.Ignored, A<int>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void EditShouldReturnContentOnError()
        {
            A.CallTo(() => v.BuildEntity(A<HobbyInput>.Ignored, A<int>.Ignored)).Throws(new AwesomeDemoException("aa"));
            c.Edit(A.Fake<HobbyInput>()).ShouldBeContent().Content.ShouldEqual("aa");
        }

        [Test]
        public void DeleteShouldRedirectToIndex()
        {
            c.Delete(1).ShouldBeJson();
            A.CallTo(() => s.Delete(1)).MustHaveHappened();
        }
    }
}