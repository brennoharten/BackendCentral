using Domain.Entities;
using FluentValidation;
using System;

namespace Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
    }
}
