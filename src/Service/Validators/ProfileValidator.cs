using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            
        }
    }
}