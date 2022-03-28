using Demo.Domain.StoreContext.Commands.Inputs;
using Demo.Shared.Commands;
using Demo.Shared.Commands.Outputs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<ICommandResult> Post([FromBody] CreateUserCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await _mediator.Send(command);
            return new CommandResult(false, "Errors", command.Notifications);
        }

        [HttpPut]
        [Route("")]
        public async Task<ICommandResult> Put([FromBody] UpdateUserCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await _mediator.Send(command);
            return new CommandResult(false, "Errors", command.Notifications);
        }
    }
}
