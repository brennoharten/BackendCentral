using System.Net.Mime;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RankTypeRepository : BaseRepository<RankType> ,IRankTypeRepository
    {
        protected readonly Context _mySqlContext;

        public RankTypeRepository(Context mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
    }
}