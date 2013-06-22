using System;
using System.Collections.Generic;

namespace FGR.Models
{
    public partial class Game
    {
        public Game()
        {
            this.Challenges = new List<Challenge>();
            this.Rankings = new List<Ranking>();
        }

        public int ID { get; set; }
        public string GameTitle { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Challenge> Challenges { get; set; }
        public virtual ICollection<Ranking> Rankings { get; set; }
    }
}
