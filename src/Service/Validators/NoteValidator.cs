using System;
using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            
        }
    }
}