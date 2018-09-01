using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapacitacionMVC.Entities;

namespace CapacitacionMVC.Data
{
    public class GenreService : IGenreService
    {
        MoviesContext moviesContext = new MoviesContext();

        public IEnumerable<Genre> GetGenres(string filter = null)
        {
            return this.moviesContext.Genres.AsQueryable().Where(m => m.Name.Contains(filter));
        }

        public IEnumerable<Movie> MoviesByGenre(Guid genreIdFilter)
        {
            return this.moviesContext.Movies.AsQueryable().Where(m => m.Genres.Select(s => s.Id).Contains(genreIdFilter));
        }

        public Genre GetGenreById(Guid id)
        {
            return this.moviesContext.Genres.AsQueryable().Where(m => m.Id == id).Single();
        }
    }
}
