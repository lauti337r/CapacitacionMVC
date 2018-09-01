using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacitacionMVC.Data
{
    public class MovieService : IMovieService
    {
        MoviesContext moviesContext = new MoviesContext();

        public IEnumerable<Entities.Movie> GetMovies(Guid? genreIdFilter = null, string nameFilter = null)
        {

            return this.moviesContext.Movies.AsQueryable().Where(m=> m.Name.Contains(nameFilter));
        }

        public void DeleteMovie(Guid id)
        {
            Entities.Movie movie = this.GetMovieById(id);
            this.moviesContext.Movies.Remove(movie);
            this.moviesContext.SaveChanges();
        }


        public IEnumerable<Entities.Movie> MoviesByGenre(Guid id)
        {
            return this.moviesContext.Movies.AsQueryable().Where(m => m.Genres.Select(s => s.Id).Contains(id));
        }

        public Entities.Movie GetMovieById(Guid id)
        {
            return this.moviesContext.Movies.AsQueryable().Where(m => m.Id == id).Single();
        }

        public void AddMovie(Entities.Movie movie)
        {
            this.moviesContext.Movies.Add(movie);
            this.moviesContext.SaveChanges();
        }

        public void Update(Entities.Movie movie)
        {
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movie.Id).Single().Name = movie.Name;
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movie.Id).Single().Plot = movie.Plot;
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movie.Id).Single().ReleaseDate = movie.ReleaseDate;
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movie.Id).Single().Runtime = movie.Runtime;
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movie.Id).Single().CoverLink = movie.CoverLink;
            this.moviesContext.SaveChanges();   
        }

        public IEnumerable<Entities.Genre> getGenres()
        {
            return this.moviesContext.Genres.AsEnumerable();
        }

        public void addGenreToMovie(Guid movieId, string genreId)
        {
            Guid genreId2 = new Guid(genreId);
            Entities.Genre genre = this.moviesContext.Genres.AsQueryable().Where(m => m.Id == genreId2).Single();
            this.moviesContext.Movies.AsQueryable().Where(m => m.Id == movieId).Single().Genres.Add(genre);
            this.moviesContext.SaveChanges();
        }



    }
}
