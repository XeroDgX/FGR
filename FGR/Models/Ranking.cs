using System;
using System.Collections.Generic;

namespace FGR.Models
{
    public partial class Ranking
    {
        public Ranking()
        {
            this.Challenges = new List<Challenge>();
            this.Challenges1 = new List<Challenge>();
        }

        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int BattleScore { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Challenge> Challenges { get; set; }
        public virtual ICollection<Challenge> Challenges1 { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
