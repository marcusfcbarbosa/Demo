using Demo.Domain.StoreContext.Entities.Enums;
using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class UserLogin : Entity
    {
        private UserLogin() { }
        public UserLogin(Guid userId, User user, 
            string login, string password, 
            UserLoginStatus status)
             : this()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            this.userId = userId;
            this.user = user;
            Login = login;
            Password = password;
            this.status = status;
        }

        public Guid userId { get; private set; }
        public User user { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public UserLoginStatus status { get; private set; }
    }
}
