using AutomatedTellerMachine.Models;
using System.Linq;

namespace AutomatedTellerMachine.Services
{



    public class CheckingAccountService
    {
        private ApplicationDbContext db;

        public CheckingAccountService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateCheckingAccount(string FirstName, string LastName, string userId, decimal initialBalance)
        {
            var accountNumber = (12345 + db.CheckingAccoutnts.Count()).ToString().PadLeft(10, '0');
            var checkingAccount =
                new CheckingAccount()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    AccountNumber = accountNumber,
                    Balance = 0,
                    ApplicationUserId = userId
                };
            db.CheckingAccoutnts.Add(checkingAccount);
            db.SaveChanges();

        }

    }
}