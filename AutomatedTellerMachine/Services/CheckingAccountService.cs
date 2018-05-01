using AutomatedTellerMachine.Models;
using System.Linq;

namespace AutomatedTellerMachine.Services
{



    public class CheckingAccountService
    {
        private IApplicationDbContext db;

        public CheckingAccountService(IApplicationDbContext dbContext)
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

        public void UpdateBalance(int checkingAccountId)
        {
            var checkingAccout = db.CheckingAccoutnts.First(c => c.Id == checkingAccountId);

            checkingAccout.Balance = db.Transactions.Where(c => c.CheckingAccountId == checkingAccountId)
                .Sum(c => c.Amount);
            db.SaveChanges();

        }

    }
}