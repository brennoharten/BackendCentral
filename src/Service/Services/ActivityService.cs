using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class ActivityService : BaseService<Activity>, IActivityService
    {
        public ActivityService(IActivityRepository repository) : base(repository)
        {
        }
    }
}