using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class RankValidator : AbstractValidator<Rank>
    {
        public RankValidator()
        {
            
        }
    }
}