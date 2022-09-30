using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ActivityHistory : BaseEntity
    {
        public int GroupId { get; set; }
        public int ActivityId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public virtual Group Group { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
