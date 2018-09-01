using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapacitacionMVC.Web.Models
{
    public class GenreToMovieViewModel
    {
        public Guid movieID { get; set; }

        public string movieName { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> genreList { get; set; }

    }
}