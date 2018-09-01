using CapacitacionMVC.Data;
using CapacitacionMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapacitacionMVC.Web.Controllers
{
    public class MovieController : Controller
    {
        MovieService servicio = new MovieService();

        // GET: Movie
        public ActionResult Index()
        {
            var movies = this.servicio.GetMovies(null, string.Empty);

            var moviesList = CreateMovieViewModel(movies);

            return View(moviesList);
        }

        public ActionResult ByGenre(Guid id)
        {
            var movies = this.servicio.MoviesByGenre(id);
            var moviesList = this.CreateMovieViewModel(movies);
            return View("Index", moviesList);
        }

        public ActionResult SearchMovies(string filter)
        {
            var movies = servicio.GetMovies(null, filter);

            var moviesList = this.CreateMovieViewModel(movies);

            return View("Index", moviesList);
        }

        private GenreToMovieViewModel CreateGenreToMovieViewModel(Guid id)
        {
            GenreToMovieViewModel genreToMovieVM = new GenreToMovieViewModel();
            IEnumerable<Entities.Genre> genres = this.servicio.getGenres();
            List<SelectListItem> genreList = new List<SelectListItem>();
            foreach(Entities.Genre genre in genres){
                SelectListItem item = new SelectListItem();
                item.Text = genre.Name;
                item.Value = genre.Id.ToString();

                genreList.Add(item);
            }

            genreToMovieVM.movieID = id;
            genreToMovieVM.movieName = this.servicio.GetMovieById(id).Name;
            genreToMovieVM.genreList = genreList;
            
            return genreToMovieVM;
        }

        private List<MovieViewModel> CreateMovieViewModel(IEnumerable<Entities.Movie> movies) 
        {
            var moviesList = new List<MovieViewModel>();

            foreach (var item in movies)
            {
                /*
                var movieViewModel = new MovieViewModel();

                movieViewModel.Id = item.Id;
                movieViewModel.Name = item.Name;
                movieViewModel.Plot = item.Plot;
                movieViewModel.ReleaseDate = item.ReleaseDate;
                movieViewModel.Runtime = item.Runtime;
                movieViewModel.CoverLink = item.CoverLink;
                */
                moviesList.Add(this.CreateMovieViewModel(item));
            }
            return moviesList;
        }

        private MovieViewModel CreateMovieViewModel(Entities.Movie movie)
        {
            var movieViewModel = new MovieViewModel();

            movieViewModel.Id = movie.Id;
            movieViewModel.Name = movie.Name;
            movieViewModel.Plot = movie.Plot;
            movieViewModel.ReleaseDate = movie.ReleaseDate;
            movieViewModel.Runtime = movie.Runtime;
            movieViewModel.CoverLink = movie.CoverLink;
            //movieViewModel.Genres = this.getMovieGenres(movie.Genres);

            return movieViewModel;

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult addMovie(MovieViewModel movie)
        {
            movie.Id = Guid.NewGuid();
            
            Entities.Movie movieToAdd = new Entities.Movie();
            movieToAdd.Id = Guid.NewGuid();
            movieToAdd.Name = movie.Name;
            movieToAdd.ReleaseDate = movie.ReleaseDate;
            movieToAdd.CoverLink = movie.CoverLink;
            movieToAdd.Plot = movie.Plot;
            movieToAdd.Runtime = movie.Runtime;
            this.servicio.AddMovie(movieToAdd);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            this.servicio.DeleteMovie(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            MovieViewModel model = this.CreateMovieViewModel(this.servicio.GetMovieById(id));
            //Entities.Movie model = this.servicio.GetMovieById(id);

            return View("Edit", model);
        }

        public List<string> getMovieGenres(List<Entities.Genre> genres)
        {
            List<string> genresList = new List<string>();
            foreach (var genre in genres)
            {
                genresList.Add(genre.Name);
            }
            return genresList;

        }

        public ActionResult editMovie(MovieViewModel movie)
        {
            Entities.Movie movieToEdit = this.servicio.GetMovieById(movie.Id);

            movieToEdit.Name = movie.Name;
            movieToEdit.ReleaseDate = movie.ReleaseDate;
            movieToEdit.CoverLink = movie.CoverLink;
            movieToEdit.Plot = movie.Plot;
            movieToEdit.Runtime = movie.Runtime;

            this.servicio.Update(movieToEdit);

            return RedirectToAction("Index");
        }

        public ActionResult addGenreToMovie(FormCollection formC)
        {
            Guid movieId = new Guid(formC["movieID"]);
            this.servicio.addGenreToMovie(movieId, formC["genreToAdd"]);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            MovieViewModel movieToShow = this.CreateMovieViewModel(this.servicio.GetMovieById(id));
            
            return View("Details", movieToShow);
        }

        public ActionResult AddGenre(Guid id)
        {
            return View("AddGenre",this.CreateGenreToMovieViewModel(id));
        }
    }
}