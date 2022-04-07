using Moneybox.App.Domain.Services;

namespace Moneybox.App.Features
{
    public class AccountValidator : IAccountValidator
    {
        public const decimal PAY_IN_LIMIT = 4000m;
        public void ValidateBalance(decimal balance)
        {
            if (balance < 0m)
            {
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }
        }
        public void ValidatePayment(decimal payment){
            if (payment > PAY_IN_LIMIT)
            {
                throw new InvalidOperationException("Account pay in limit reached");
            }
        }
    }
}
