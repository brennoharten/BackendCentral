using System;

namespace Domain.Entities
{
    public class GroupProfile : BaseEntity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int ScoreGroup { get; set; }
        public virtual Group Group { get; set; }
        public virtual User user { get; set; }
    }
}
