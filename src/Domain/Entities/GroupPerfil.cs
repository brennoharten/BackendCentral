using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupPerfil 
    {
        public int PerfilId { get; set; }
        public int GroupId { get; set; }
        public int RankPerfil { get; set; }
        public int ScorePerfil { get; set; }
    }
}
