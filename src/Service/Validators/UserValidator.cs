using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please enter the password.")
                .NotNull().WithMessage("Please enter the password.");

            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Please enter the username.")
                .NotNull().WithMessage("Please enter the username.");

            RuleFor(c => c.Role)
                .NotEmpty().WithMessage("Please enter the role.")
                .NotNull().WithMessage("Please enter the roel.");
        }
    }
}