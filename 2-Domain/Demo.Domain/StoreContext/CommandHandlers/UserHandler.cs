using Demo.Domain.StoreContext.Commands.Inputs;
using Demo.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Domain.StoreContext.CommandHandlers
{
    public class UserHandler
        : IRequestHandler<CreateUserCommand, ICommandResult>,
          IRequestHandler<UpdateUserCommand, ICommandResult>
    {
        public Task<ICommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}