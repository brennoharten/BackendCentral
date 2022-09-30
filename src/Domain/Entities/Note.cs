using System;

namespace Domain.Entities
{
    public class Note : BaseEntity
    {
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
