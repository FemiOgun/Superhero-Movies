using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.SHC.Models
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterID { get; set; }
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Abilities { get; set; }
        public string Image { get; set; }

        [ForeignKey("MovieID")]
        public virtual Movies Movies { get; set; }
    }
}