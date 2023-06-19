using System;

namespace Application.ViewModels
{
    public class ActivityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Deadline { get; set;}
        public bool Status { get; set; }
        public string Type { get; set;}
        public int Score { get; set;}
        public bool DailyActivity { get; set;}
    }
}
