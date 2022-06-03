using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        List<Movie> ListaMovies = new List<Movie>();

        public void PrendiDati()
        {

            Movie PrimoMovie = new Movie()
            {
                Id = 1,
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989 - 2 - 12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Photo = "/img/fondo-pag-speciali.jpg",
                AlternateText = "Pranaya Rout Photo not available"
            };
            ListaMovies.Add(PrimoMovie);

            Movie SecondoMovie = new Movie()
            {
                Id = 1,
                Title = "Lord of the ring",
                ReleaseDate = DateTime.Parse("1991 - 2 - 12"),
                Genre = "Fantasy",
                Price = 8.99M,
                Photo = "/img/fondo-pag-speciali.jpg",
                AlternateText = "Pranaya Rout Photo not available"
            };
            ListaMovies.Add(SecondoMovie);
        }
        public IActionResult ShowMovie()
        {
            PrendiDati();
            return View(ListaMovies);
        }

        public string ProvaParametri(string Nome, string Cognome)
        {
            string sAppo = "I dati inseriti sono: " + Nome + " " + Cognome;
            string sQueryString = Request.QueryString.ToString();
            return sAppo;
        }
    }
}
