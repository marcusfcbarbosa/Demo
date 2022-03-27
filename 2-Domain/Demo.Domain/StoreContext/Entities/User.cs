using Demo.Domain.StoreContext.Entities.Enums;
using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class User : Entity
    {
        private User() { }
        public User(UserRoles roles, UserType type, string name, 
            string email, string socialSecurityNumnber, 
            string address, UserStatus status): this()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            Roles = roles;
            Type = type;
            Name = name;
            Email = email;
            SocialSecurityNumnber = socialSecurityNumnber;
            Address = address;
            this.status = status;
        }
        public UserRoles Roles { get; private set; }
        public UserType Type { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string SocialSecurityNumnber { get; private set; }
        public string Address { get; private set; }
        public UserStatus status { get; private set; }
    }
}
