﻿using System;

namespace Domain.Entities
{
    public class Note : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
