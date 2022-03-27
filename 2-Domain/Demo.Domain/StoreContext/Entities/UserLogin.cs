using Demo.Domain.StoreContext.Entities.Enums;
using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class UserLogin : Entity
    {
        private UserLogin() { }
        public UserLogin(User user, 
            string password, 
            UserLoginStatus status)
            : this()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            this.user = user;
            Password = password;
            this.status = status;
        }
        public User user { get; private set; }
        public string Password { get; private set; }
        public UserLoginStatus status { get; private set; }
    }
}
