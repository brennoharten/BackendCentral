using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class GroupProfileService : BaseService<GroupProfile>, IGroupProfileService
    {
        public GroupProfileService(IGroupProfileRepository repository) : base(repository)
        {
        }
    }
}