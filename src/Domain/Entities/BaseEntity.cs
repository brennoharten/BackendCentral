using System;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime AlterationDate { get; set; }
        public int AlterationUser { get; set; }
    }
}
