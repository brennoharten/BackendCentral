using System;

namespace Domain.Entities
{
    public class GroupProfile : BaseEntity
    {
        public int ProfileId { get; set; }
        public int GroupId { get; set; }
        public int ScoreGroup { get; set; }
        public virtual Group Group { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
