using Xunit;
using Moneybox.App.Domain.Services;
using Moneybox.App.DataAccess;

namespace moneybox_withdraw_master.Tests.Services_Test
{

    public class NotificationHandler_Test
    {
        [TestMethod()]
        public void SendLowFundsNotification()
        {
            var notificationHandler = new INotificationHandler();
            var user = new Mock<IUser>();
            user.Email = "test@test.test";

            /*
                Asuming that the Notification Service sends email,
                Check that mail for low funds is being properly sent, and no error
                is thrown
            */
            var mailSendingExcpetionThrown = notificationHandler.HandleLowFunds(decimal.Subtract(500m, 10m), user.Email);
            Assert.Null(mailSendingExcpetionThrown);
        }

        [TestMethod()]
        public void NotifyForApprochingLimits()
        {
            var notificationHandler = new INotificationHandler();
            var user = new IUser();
            user.Email = "test@test.test";

            /*
                Asuming that the Notification Service sends email,
                Check user is being properly notified for approching Pay Limit
            */
            var mailSendingExcpetionThrown = notificationHandler.HandleApproachingPayInLimit(decimal.Subtract(500m, 10m), user.Email);
            Assert.Null(mailSendingExcpetionThrown);
        }

    }
}
