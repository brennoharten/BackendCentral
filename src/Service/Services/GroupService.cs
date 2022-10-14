using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(IGroupRepository repository) : base(repository)
        {
        }
    }
}