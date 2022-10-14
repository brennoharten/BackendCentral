using System.Net.Mime;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class GroupProfileRepository : BaseRepository<GroupProfile> ,IGroupProfileRepository
    {
        protected readonly Context _mySqlContext;

        public GroupProfileRepository(Context mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
    }
}