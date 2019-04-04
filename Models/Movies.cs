using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.SHC.Models
{
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MoviesID { get; set; }
        public string Title { get; set; }
        public string PlotSummary { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}