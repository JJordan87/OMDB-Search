using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;
using System.Diagnostics;

namespace SearchingOMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesDAL moviesDAL = new MoviesDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
                return View();
        }
        [HttpPost]
        public IActionResult MovieSearch(string Title)
        {
            List<MoviesModel> movie = new List<MoviesModel>();
            MoviesModel result = moviesDAL.GetMovies(Title);
            movie.Add(result);
            return View(movie);
        }
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string Title1, string Title2, string Title3)
        {
            List<MoviesModel> movies = new List<MoviesModel>();
            MoviesModel result1 = moviesDAL.GetMovies(Title1);
            MoviesModel result2 = moviesDAL.GetMovies(Title2);
            MoviesModel result3 = moviesDAL.GetMovies(Title3);
            movies.Add(result1);
            movies.Add(result2);
            movies.Add(result3);
            return View(movies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}