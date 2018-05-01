using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var checkingAccountId = db.CheckingAccoutnts.Where(a => a.ApplicationUserId == userId).First().Id;

            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having truble send s a message";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            //Do 

            ViewBag.TheMessage = "Thanks, got it";

            return PartialView("_ContactThanks");
            //return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVCATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }
    }
}