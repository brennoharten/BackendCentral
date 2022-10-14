using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}