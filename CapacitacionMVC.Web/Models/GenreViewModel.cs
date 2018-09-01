using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapacitacionMVC.Web.Models
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<MovieViewModel> Movies { get; set; }

    }
}