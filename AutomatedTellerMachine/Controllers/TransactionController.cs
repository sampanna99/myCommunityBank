using AutomatedTellerMachine.Models;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {

        private IApplicationDbContext db;

        public TransactionController()
        {
            db = new ApplicationDbContext();
        }
        public TransactionController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public ActionResult Deposit(int CheckingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {

            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");

            }

            return View();
        }
    }
}
