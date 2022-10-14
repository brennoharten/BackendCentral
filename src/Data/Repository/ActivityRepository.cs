using System.Net.Mime;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class ActivityRepository : BaseRepository<Activity> ,IActivityRepository
    {
        protected readonly Context _mySqlContext;

        public ActivityRepository(Context mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
    }
}