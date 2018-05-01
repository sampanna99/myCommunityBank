using AutomatedTellerMachine.Controllers;
using AutomatedTellerMachine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnesAboutView()
        {
            var homeController = new HomeController();

            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("I love your bank") as ViewResult;

            Assert.IsNotNull("Thanks!", result.ViewBag.TheMessage);
        }


        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.CheckingAccoutnts = new FakeDbSet<CheckingAccount>();

            var checkingAccount = new CheckingAccount { Id = 1, AccountNumber = "000123TEST", Balance = 0 };

            fakeDb.CheckingAccoutnts.Add(checkingAccount);

            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakeDb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 1, Amount = 25 });
            //checkingAccount.Balance = 25;

            Assert.AreEqual(25, checkingAccount.Balance);

        }



    }
}
