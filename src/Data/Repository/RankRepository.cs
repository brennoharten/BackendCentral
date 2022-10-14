using System.Net.Mime;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RankRepository : BaseRepository<Rank> ,IRankRepository
    {
        protected readonly Context _mySqlContext;

        public RankRepository(Context mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
    }
}