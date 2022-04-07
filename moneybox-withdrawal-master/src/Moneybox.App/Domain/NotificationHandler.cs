using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;

namespace Moneybox.App.Features
{
    public class NotificationHandler : INotificationHandler
    {
        private INotificationService notificationService;
        private const decimal LOW_FUNDS_LIMIT = 500m;
        private const decimal PAYMENT_LIMIT = 500m;

        public NotificationHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void HandleLowFunds(decimal balance, IUser user)
        {
            if (balance < PAYMENT_LIMIT)
            {
                this.notificationService.NotifyFundsLow(user.Email);
            }
        }
        public void HandleApproachingPayInLimit(decimal limit, IUser user)
        {
            if (limit < LOW_FUNDS_LIMIT)
            {
                this.notificationService.NotifyApproachingPayInLimit(user.Email);
            }
        }

    }
}
