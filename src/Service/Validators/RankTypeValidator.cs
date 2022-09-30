using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class RankTypeValidator : AbstractValidator<RankType>
    {
        public RankTypeValidator()
        {
            
        }
    }
}