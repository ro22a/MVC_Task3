using ETicketsSystem.Data;
using ETicketsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Areas.Admin.Controllers
{
	[Area(SD.AdminArea)]
	public class CinemaController : Controller
	{
		ApplicationDbContext _context=new ApplicationDbContext();
		public IActionResult Index(int page=1)
		{
			var cinemas = _context.Cinemas.Include(e=>e.Movies).AsQueryable();

			//Pagination
			var TotalNumOfPages = Math.Ceiling(cinemas.Count() / 10.0);
			ViewBag.TotalNumOfPages = TotalNumOfPages;
			var currentpage = page;
			ViewBag.CurrentPage = currentpage;
			cinemas =cinemas.Skip((page - 1) * 10).Take(10);

			return View(cinemas.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Create(Cinema cinema, IFormFile? CinemaLogo)
		{
			if (CinemaLogo != null && CinemaLogo.Length > 0)
			{
				//Save img in wwwroot
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CinemaLogo.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					CinemaLogo.CopyTo(stream);
				}

				//Save img in DB
				cinema.CinemaLogo = fileName;
			}

			_context.Cinemas.Add(cinema);
			_context.SaveChanges();

			TempData["success-notification"] = "Add Cinema Successfully";

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{ 
			var cinema=_context.Cinemas.FirstOrDefault(e=>e.Id==id);
			if(cinema is null)
			{
				return NotFound();
			}
			return View(cinema);

		}

		[HttpPost]
		public IActionResult Edit(Cinema cinema, IFormFile? CinemaLogo)
		{
			var cinemaInDb = _context.Cinemas.AsNoTracking().FirstOrDefault(e => e.Id == cinema.Id);
			if (CinemaLogo is not null)
			{

				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CinemaLogo.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					CinemaLogo.CopyTo(stream);
				}
				if (!string.IsNullOrEmpty(cinemaInDb.CinemaLogo))
				{
					//Remove old img from wwwroot
					var oldFileName = cinemaInDb.CinemaLogo;
					var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", oldFileName);
					if (System.IO.File.Exists(oldFilePath))
					{
						System.IO.File.Delete(oldFilePath);
					}
				}
					
					

				//Save img in DB
				cinema.CinemaLogo = fileName;
			}
			else
			{
				cinema.CinemaLogo = cinemaInDb.CinemaLogo;
			}

			_context.Cinemas.Update(cinema);
			_context.SaveChanges();

			TempData["success-notification"] = "Update Cinema Successfully";

			return RedirectToAction(nameof(Index));

		}

		public IActionResult Delete(int id)
		{
			var cinema=_context.Cinemas.FirstOrDefault(e=>e.Id==id);
			if(cinema is null)
			{
				return NotFound();
			}
			_context.Cinemas.Remove(cinema);
			_context.SaveChanges();

			TempData["success-notification"] = "Delete Cinema Successfully";

			return RedirectToAction(nameof(Index));
		}

	}
}
