﻿using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;
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

                var service = new CheckingAccountService(db);
                service.UpdateBalance(transaction.CheckingAccountId);

                return RedirectToAction("Index", "Home");

            }

            return View();
        }
    }
}
