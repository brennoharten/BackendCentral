using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class ActivityHistoryValidator : AbstractValidator<ActivityHistory>
    {
        public ActivityHistoryValidator()
        {
            
        }
    }
}