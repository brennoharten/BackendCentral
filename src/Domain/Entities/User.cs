using System;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public virtual Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
