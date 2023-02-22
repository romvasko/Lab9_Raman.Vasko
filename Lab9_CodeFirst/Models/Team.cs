using System;
using System.Collections.Generic;

namespace Lab9_CodeFirst.Models
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public int CoachId { get; set; }
        public decimal? Rate { get; set; }

        public virtual Coach Coach { get; set; } = null!;
        public virtual ICollection<Player> Players { get; set; }
    }
}
