using System;
using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;

namespace Moneybox.App
{

    //Using constructor dependency injection to inject Data Access and Validation logi to  a generic money operation client
    //The client money operation uses Data Acccess and Validation services throug constructor injection
    public abstract class MoneyOperation
    {
        protected IAccountRepository accountRepository;
        protected IAccountValidator accountValidator;
        protected INotificationHandler notificationHandler;

        public MoneyOperation(IAccountRepository accountRepository, INotificationHandler notificationHandler, IAccountValidator accountValidator)
        {
            this.accountRepository = accountRepository;
            this.notificationHandler = notificationHandler;
            this.accountValidator = accountValidator;
        }

        public abstract void Execute(decimal amount, params Guid[] accountIds);
    }
}
