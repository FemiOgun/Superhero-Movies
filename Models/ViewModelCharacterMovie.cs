using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SHC.Models
{
    public class ViewModelCharacterMovie
    {
        public Character Character { get; set; }
        public List<Movies> Movies { get; set; }
    }
}