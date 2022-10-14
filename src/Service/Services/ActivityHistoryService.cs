using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class ActivityHistoryService : BaseService<ActivityHistory>, IActivityHistoryService
    {
        public ActivityHistoryService(IActivityHistoryRepository repository) : base(repository)
        {
        }
    }
}