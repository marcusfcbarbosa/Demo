using Demo.Domain.StoreContext.Entities.Enums;
using Demo.Shared.Commands;
using Demo.Shared.Extensions;
using Demo.Shared.ValueObjects;
using FluentValidator;
using FluentValidator.Validation;
using MediatR;

namespace Demo.Domain.StoreContext.Commands.Inputs
{
    public class CreateUserCommand : Notifiable, ICommand, IRequest<ICommandResult>
    {

        public UserRoles Role { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumnber { get; set; }
        public UserStatus Status { get; set; }
        public Address address { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
               .Requires()
               .IsNotNullOrEmpty(Name, "Name", "Inválid Name")
               );
            AddNotifications(new ValidationContract()
               .Requires()
               .IsNotNullOrEmpty(Name, "Name", "Inválid Name")
               );
            AddNotifications(new ValidationContract()
               .Requires()
               .IsFalse(Email.IsValidEmail(), "E-mail", "Inválid E-mail")
               );
            AddNotifications(new ValidationContract()
               .Requires()
               .IsFalse(SocialSecurityNumnber.IsSocialSecurityNumber(), "SocialSecurityNumnber", "Inválid SocialSecurityNumnber")
               );
        }
    }
}
