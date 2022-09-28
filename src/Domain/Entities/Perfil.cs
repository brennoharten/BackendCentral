using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Perfil : BaseEntity
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }
        public string Genre { get; set; }
        public int Rank { get; set; }
        public int GlobalScore { get; set;}
    }
}
