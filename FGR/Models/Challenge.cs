using System;
using System.Collections.Generic;

namespace FGR.Models
{
    public partial class Challenge
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int ChallengerPlayerID { get; set; }
        public int RivalPlayerID { get; set; }
        public System.DateTime Date { get; set; }
        public short Status { get; set; }
        public virtual Game Game { get; set; }
        public virtual Ranking Ranking { get; set; }
        public virtual Ranking Ranking1 { get; set; }
    }
}
