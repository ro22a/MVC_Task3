using System.Diagnostics;
using ETicketsSystem.Data;
using ETicketsSystem.Data.Enums;
using ETicketsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Areas.User.Controllers
{
    [Area(SD.UserArea)]
   
    public class HomeController : Controller
    {
        ApplicationDbContext _context=new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? CategoryId,MovieStatus? Status,double? MaxPrice,int page=1)
        {
            var movies = _context.Movies.Include(e => e.Category).AsQueryable();
            
            //Filters
            if(MaxPrice is not null)
            {
                movies = movies.Where(e => e.Price>=MaxPrice);
                ViewBag.MaxPrice = MaxPrice;
            }

            if(CategoryId is not null)
            {
                movies=movies.Where(e=>e.CategoryId==CategoryId);
			    ViewBag.CategoryId = CategoryId;
			}
			ViewBag.Categories = _context.Categories.ToList();

			if (Status is not null)
			{
                movies = movies.Where(e => e.MovieStatus == Status);
                ViewBag.Status = Status;
            }
			ViewBag.Statuses = Enum.GetValues(typeof(MovieStatus)).Cast<MovieStatus>().ToList();

            //Pagination
            var TotalNumOfPages=Math.Ceiling(movies.Count()/6.0);
            ViewBag.TotalNumOfPages = TotalNumOfPages;
            var currentpage = page;
            ViewBag.CurrentPage = currentpage;

            movies = movies.Skip((page - 1) * 6).Take(6);


			return View(movies.ToList());
        }

		public IActionResult Details(int id)
		{
			var movie = _context.Movies.Include(e => e.Category).Include(e=>e.Cinema).Include(m => m.Actors).FirstOrDefault(m => m.Id == id);

			if (movie == null)
				return NotFound();

			return View(movie);
		}


        public IActionResult DetailsActor(int id)
        {
            var actor = _context.Actors.Include(e => e.Movies).ThenInclude(e => e.Category).FirstOrDefault(e => e.Id == id);
            if(actor == null)
            {
                return NotFound();
            }


			return View(actor);
        }
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
