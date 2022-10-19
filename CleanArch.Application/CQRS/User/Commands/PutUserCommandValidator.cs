using Application.Interfaces.User;
using FluentValidation;

namespace Application.CQRS.User.Commands
{
    public class PutUserCommandValidator : AbstractValidator<PutUserCommand>
    {
        private readonly IUserService _userService;

        public PutUserCommandValidator(
            IUserService userService
            )
        {
            _userService = userService;

            RuleFor(x => x.Document)
                    .NotEmpty()
                    .WithMessage("El documento no puede estar vacío");

            RuleFor(x => x.Names)
                    .NotEmpty()
                    .WithMessage("El nombre no puede estar vacío");

            RuleFor(x => x.LastName)
                   .NotEmpty()
                   .WithMessage("El apellido no puede estar vacía");        

            RuleFor(x => x.login)
                   .NotEmpty()
                   .WithMessage("El login no puede estar vacía");

            RuleFor(x => x.PassWord)
                   .NotEmpty()
                   .WithMessage("El password no puede estar vacía");

        }

    }
}
