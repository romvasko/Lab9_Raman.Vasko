using System;
using System.Collections.Generic;

namespace Lab9_CodeFirst.Models
{
    public partial class Coach
    {
        public Coach()
        {
            Teams = new HashSet<Team>();
        }

        public int CoachId { get; set; }
        public string CoachName { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; }
    }
}
