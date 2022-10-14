using System.Net.Mime;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        protected readonly Context _mySqlContext;

        public UserRepository(Context mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public User Get(string username,string password)
        {
            return _mySqlContext.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}