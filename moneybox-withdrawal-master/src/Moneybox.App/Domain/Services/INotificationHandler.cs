using Moneybox.App.DataAccess;

namespace Moneybox.App.Domain.Services
{
    public interface INotificationHandler
    {
        void HandleLowFunds(decimal limit, IUser user);
        void HandleApproachingPayInLimit(decimal balance, IUser user);
    }
}
