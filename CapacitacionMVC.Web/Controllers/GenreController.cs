using CapacitacionMVC.Data;
using CapacitacionMVC.Entities;
using CapacitacionMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapacitacionMVC.Web.Controllers
{
    public class GenreController : Controller
    {
        GenreService servicio = new GenreService();

        // GET: Genre
        public ActionResult Index()
        {
            IEnumerable<Genre> generos = servicio.GetGenres(string.Empty);

            List<GenreViewModel> listaGeneros = new List<GenreViewModel>();

            foreach (var item in generos)
            {
                GenreViewModel generoViewModel = new GenreViewModel();

                generoViewModel.Id = item.Id;
                generoViewModel.Nombre = item.Name;

                listaGeneros.Add(generoViewModel);

            }

            return View(listaGeneros);
        }

        public ActionResult SearchGenres(string filter)
        {
            var genres = servicio.GetGenres(filter);

            List<GenreViewModel> listaGeneros = new List<GenreViewModel>();

            foreach (var item in genres)
            {
                GenreViewModel generoViewModel = new GenreViewModel();

                generoViewModel.Id = item.Id;
                generoViewModel.Nombre = item.Name;

                listaGeneros.Add(generoViewModel);

            }

            return View("Index", listaGeneros);
        }

        public ActionResult ListMovies(Guid id)
        {
            return RedirectToAction("ByGenre", "Movie", new { id = id });
        }
    }
}