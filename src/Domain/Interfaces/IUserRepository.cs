using Domain.Entities;
using System;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User Get(string username, string password);
    }
}
