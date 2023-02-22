using System;
using System.Collections.Generic;

namespace Lab9_CodeFirst.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public int TeamId { get; set; }
        public int? PlayerAge { get; set; }
        public decimal? PlayerSalary { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
