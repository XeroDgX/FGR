using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FGR.Models
{
    public partial class Player
    {
        public Player()
        {
            this.Rankings = new List<Ranking>();
        }

        public int ID { get; set; }
        [Key]
        [Required(ErrorMessage = "Introduzca un nombre de usuario valido.")]
        public string Nickname { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Ranking> Rankings { get; set; }
    }
}
