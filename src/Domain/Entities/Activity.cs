using System;

namespace Domain.Entities
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set;}
        public bool Status { get; set; }
        public string Type { get; set;}
        public int Score { get; set;}
        public bool DailyActivity { get; set;}
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
