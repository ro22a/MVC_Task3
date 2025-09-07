using ETicketsSystem.Data;
using ETicketsSystem.Models;
using ETicketsSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Areas.Admin.Controllers
{
	[Area(SD.AdminArea)]
	public class MovieController : Controller
	{
		

		ApplicationDbContext _context=new ApplicationDbContext();
		public IActionResult Index(int page = 1)
		{
			var movies = _context.Movies.Include(e=>e.Category).Include(e=>e.Cinema).AsQueryable();

			//pagination
			
			var TotalNumOfPages = Math.Ceiling(movies.Count() / 10.0);
			ViewBag.TotalNumOfPages = TotalNumOfPages;

			movies = movies.Skip((page - 1) * 10).Take(10);
			var currentpage = page;
			ViewBag.CurrentPage = currentpage;
		

			return View(movies.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			var categories = _context.Categories;
			var cinemas = _context.Cinemas;
			

			return View(new CategoryWithCinemaVM()
			{
				Categories = categories.ToList(),
				Cinemas = cinemas.ToList(),
				
			});
		}

		[HttpPost]

		public IActionResult Create(Movie movie,IFormFile? ImgUrl) 
		{
			

			if(ImgUrl is null)
			{
				return BadRequest();
			}
			if (ImgUrl.Length > 0)
			{
				//Save img in wwwroot
				var fileName =Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
				var filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\movies", fileName);
				
				using (var stream = System.IO.File.Create(filePath))
				{
					ImgUrl.CopyTo(stream);
				}

				//Save img in DB
				movie.ImgUrl = fileName;
			}

			

			_context.Movies.Add(movie);
			_context.SaveChanges();

			TempData["success-notification"] = "Add Movie Successfully";

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]

		public IActionResult Edit(int id)
		{ 
			var movie=_context.Movies.FirstOrDefault(e=>e.Id == id);
			if (movie is null)
			{
				return NotFound();
			}
			var categories=_context.Categories;
			var cinemas=_context.Cinemas;
			return View(new CategoryWithCinemaVM()
			{
				Categories = categories.ToList(),
				Cinemas = cinemas.ToList(),
				Movie=movie

			});
		}

		[HttpPost]
		public IActionResult Edit(Movie movie, IFormFile? ImgUrl)
		{
			var movieInDb = _context.Movies.AsNoTracking().FirstOrDefault(e => e.Id == movie.Id);
			if (movieInDb == null)
			{
				return NotFound();
			}
			if (ImgUrl is not null)
			{
				
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					ImgUrl.CopyTo(stream);
				}

				//Remove old img from wwwroot
				var oldFileName = movieInDb.ImgUrl;
				var oldFilePath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", oldFileName);
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}
				
					//Save img in DB
					movie.ImgUrl = fileName;
			}
			else
			{
				movie.ImgUrl = movieInDb.ImgUrl;
			}

			_context.Movies.Update(movie);
			_context.SaveChanges();

			TempData["success-notification"] = "Update Movie Successfully";

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			var movie = _context.Movies.FirstOrDefault(e => e.Id == id);
			if( movie is null)
			{
				return NotFound();
			}
			_context.Movies.Remove(movie);
			_context.SaveChanges();

			TempData["success-notification"] = "Delete Movie Successfully";

			return RedirectToAction(nameof(Index));
		}

			

		
	}
}
