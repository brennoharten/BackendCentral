using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime AlterationDate { get; set; }
        public int AlterationUser { get; set; }
    }
}
