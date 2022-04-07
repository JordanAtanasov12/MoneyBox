using System;

namespace Moneybox.App.DataAccess
{
    public interface IUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
