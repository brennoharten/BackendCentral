using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class ProfileService : BaseService<Profile>, IProfileService
    {
        public ProfileService(IProfileRepository repository) : base(repository)
        {
        }
    }
}