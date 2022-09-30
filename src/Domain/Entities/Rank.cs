using System;

namespace Domain.Entities
{
    public class Rank : BaseEntity
    {
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public int RankTypeId { get; set; }
        public virtual RankType RankType { get; set; }
        public int Score { get; set; }
    }
}
