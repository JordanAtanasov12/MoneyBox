using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class TransferMoney : MoneyOperation
    {
        public TransferMoney(IAccountRepository accountRepository, INotificationHandler notificationHandler, IAccountValidator accountValidator)
        : base(accountRepository, notificationHandler, accountValidator)
        {

        }
        
        //Fix naming convention for better readbility
        public override void Execute(decimal amount, params Guid[] accountIds)
        {
            var withdrawAccount = this.accountRepository.GetAccountById(accountIds[0]);
            var receiveAccount = this.accountRepository.GetAccountById(accountIds[1]);

            var withdrawalBalance = withdrawAccount.Balance - amount;
            accountValidator.ValidateBalance(withdrawalBalance);

            var paidIn = receiveAccount.PaidIn + amount;
            accountValidator.ValidatePayment(paidIn);

            withdrawAccount.Balance -= amount;
            withdrawAccount.Withdrawn -= amount;

            receiveAccount.Balance += amount;
            receiveAccount.PaidIn +=  amount;

            this.accountRepository.Update(withdrawAccount);
            this.accountRepository.Update(receiveAccount);

            notificationHandler.HandleLowFunds(withdrawalBalance, withdrawAccount.User);
            notificationHandler.HandleApproachingPayInLimit(AccountValidator.PAY_IN_LIMIT - paidIn, receiveAccount.User);
        }
    }
}
