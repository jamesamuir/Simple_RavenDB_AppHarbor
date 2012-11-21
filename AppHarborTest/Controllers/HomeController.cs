using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;
using AppHarborTest.Raven;

namespace AppHarborTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Test()
        {

            using (IDocumentSession Session = DataDocumentStore.Instance.OpenSession())
            {
                string newId = Guid.NewGuid().ToString();
                Session.Store(new TestModel
                {
                    Id = newId,
                    Text = "punnnnnchy!"
                });
                Session.SaveChanges();

                ViewBag.TestId = newId;

            }

            
            return View();
        }
    }
}
