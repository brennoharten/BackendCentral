using System;

namespace Domain.Entities
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }
        public string Genre { get; set; }
    }
}
