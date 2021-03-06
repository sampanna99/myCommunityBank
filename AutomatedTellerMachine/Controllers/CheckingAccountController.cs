﻿using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckingAccount
        [Authorize]
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var checkingAccountId = db.CheckingAccoutnts.Where(a => a.ApplicationUserId == userId).First().Id;

            ViewBag.CheckingAccountId = checkingAccountId;


            return View();
        }

        // GET: CheckingAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccount = db.CheckingAccoutnts.Where(a => a.ApplicationUserId == userId).First();
            //var checkingAccount = new CheckingAccount
            //{
            //    AccountNumber = "0000123456",
            //    FirstName = "Michael",
            //    LastName = "Scott",
            //    Balance = 500
            //};
            return View(checkingAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var checkingAccount = db.CheckingAccoutnts.Find(id);
            return View("Details", checkingAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.CheckingAccoutnts.ToList());
        }


        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
