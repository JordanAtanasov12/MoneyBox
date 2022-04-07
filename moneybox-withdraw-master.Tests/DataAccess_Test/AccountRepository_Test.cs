using Xunit;
using Moneybox.App.Domain.Services;
using Moneybox.App.DataAccess;

namespace moneybox_withdraw_master.Tests.DataAccess_Test
{

    public class AccountRepository_Test
    {

        [Fact]
        public void GetAccountById()
        {
            /* arrange */
            var accountRepository = new Mock<IAccountRepository>();
            var accountService = new IAccountRepository();
            

            var account = new IAccount  ()
            {
                Id = new System.Guid(),
                Balance = 4000m
            };
            
            /* act */
            accountRepository.Setup(_ => _.GetAccountById(account.Id)).Returns(account);
            var updatedAccount = accountService.Update(account);

            /* assert */
            Assert.IsTrue(updatedAccount);
            
        }

    }
}
