using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using SimpleDemo.Models;

namespace SimpleDemo.Controllers
{
    public class HobbyAutocompleteController : Controller
    {
        //data storage, for demo purposes
        private static readonly IEnumerable<Hobby> Data = new[] {
                                                                    new Hobby {Id = 1, Name = "coding"},
                                                                    new Hobby {Id = 2, Name = "sleeping"},
                                                                    new Hobby {Id = 3, Name = "cooking"},
                                                                    new Hobby {Id = 5, Name = "running"},
                                                                    new Hobby {Id = 6, Name = "gaming"},
                                                                    new Hobby {Id = 7, Name = "legos"},
                                                                };

        public ActionResult Search(string searchText, int maxResults)
        {
            return Json(Data.Where(
                o => o.Name.ToLower().Contains(searchText.ToLower()))
                            .Take(maxResults)
                            .Select(v => new IdTextItem { Id = v.Id, Text = v.Name }));
        }
    }
}