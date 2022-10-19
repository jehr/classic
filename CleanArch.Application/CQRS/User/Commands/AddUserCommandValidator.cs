using Application.Interfaces.User;
using FluentValidation;

namespace Application.CQRS.User.Commands
{
    public class AddUserCommandValidator : AbstractValidator<PostUserCommand>
    {
        private readonly IUserService _userService;

        public AddUserCommandValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.Document)
                .NotEmpty()
                .WithMessage("El documento no puede estar vacío");

            RuleFor(x => x.Names)
             .NotEmpty()
             .WithMessage("El nombre no puede estar vacío");          


            RuleFor(u => u)
                .MustAsync((x, cancellation) => _userService.CheckUserExistsByDocument(x.Document))
                .WithMessage("El usuario ya se encuentra registrado");

        }

    }
}
