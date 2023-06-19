using Domain.Entities;
using FluentValidation;
using System;

namespace Domain.Interfaces
{
    public interface IActivityService : IBaseService<Activity>
    {
        IList<Activity> GetByUserId(int id);
    }
}
