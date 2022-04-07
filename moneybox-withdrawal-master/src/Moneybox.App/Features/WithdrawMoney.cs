using System;
using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;

namespace Moneybox.App.Features
{
    public class WithdrawMoney : MoneyOperation
    {
        public WithdrawMoney(IAccountRepository accountRepository, INotificationHandler notificationHandler, IAccountValidator accountValidator)
        : base(accountRepository, notificationHandler, accountValidator)
        {

        }
        //The client money operation uses Data Acccess and Validation services throug constructor injection
        public override void Execute(decimal amount, params Guid[] accountIds)
        {
            var withdrawAccount = this.accountRepository.GetAccountById(accountIds[0]);

            var balanceLeftInAccount = withdrawAccount.Balance - amount;
            accountValidator.ValidateBalance(balanceLeftInAccount);

            withdrawAccount.Balance = balanceLeftInAccount;
            withdrawAccount.Withdrawn -= amount;

            this.accountRepository.Update(withdrawAccount);

            notificationHandler.HandleLowFunds(balanceLeftInAccount, withdrawAccount.User);
        }
    }
}
