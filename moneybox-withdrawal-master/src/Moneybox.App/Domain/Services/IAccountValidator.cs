namespace Moneybox.App.Domain.Services
{
    public interface IAccountValidator
    {
        void ValidateBalance(decimal balance);
        void ValidatePayment(decimal payment);
    }
}
