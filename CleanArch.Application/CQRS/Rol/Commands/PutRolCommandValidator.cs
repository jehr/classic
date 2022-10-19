﻿using FluentValidation;

namespace Application.CQRS.Rol.Commands
{
    public class PutRolCommandValidator : AbstractValidator<PutRolCommand>
    {
        public PutRolCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre no puede estar vacío");

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .WithMessage("El campo mostrar nombre no puede estar vacío");

            RuleFor(x => x.Status)
                           .NotEmpty()
                           .WithMessage("El estado no puede estar vacío");
        }
    }
}
