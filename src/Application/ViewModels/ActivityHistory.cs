using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.ViewModels
{
    public class ActivityHistoryViewModel
    {
        public int GroupId { get; set; }
        public int ActivityId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
