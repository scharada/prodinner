using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Core;
using SimpleDemo.Models;

namespace SimpleDemo.Controllers
{
    public class PagerDemoController: Controller
    {
        private readonly IList<Hobby> data = new List<Hobby>();

        public PagerDemoController()
        {
            for (var i = 1; i < 1000; i++)
            {
                data.Add(new Hobby {Id = i, Name = "hobby" + i});
            }
        }

        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            var pageIndex = page ?? 1;
            return View(new Pageable<Hobby> 
                            { 
                                PageIndex = pageIndex, 
                                PageCount = GetPageCount(pageSize, data.Count),
                                Page = data.Skip(--pageIndex * pageSize).Take(pageSize)
                            });
        }

        static int GetPageCount(int pageSize, int count)
        {
            var pages = count / pageSize;
            if (count % pageSize > 0) pages++;
            return pages;
        }
    }
}