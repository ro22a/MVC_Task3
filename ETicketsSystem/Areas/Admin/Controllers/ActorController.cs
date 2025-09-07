using ETicketsSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Areas.Admin.Controllers
{
	[Area(SD.AdminArea)]
	public class ActorController : Controller
	{
		ApplicationDbContext _context = new ApplicationDbContext();
		public IActionResult Index(int page=1)
		{
			var actors = _context.Actors.Include(e => e.Movies).AsQueryable();

			//Pagination
			var TotalNumOfPages = Math.Ceiling(actors.Count() / 10.0);
			ViewBag.TotalNumOfPages = TotalNumOfPages;
			var currentpage = page;
			ViewBag.CurrentPage = currentpage;
			actors = actors.Skip((page - 1) * 10).Take(10);
			return View(actors.ToList());
		}
		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Actor actor, IFormFile? ProfilePicture)
		{


			if (ProfilePicture is null)
			{
				return BadRequest();
			}
			if (ProfilePicture.Length > 0)
			{
				//Save img in wwwroot
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePicture.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\cast", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					ProfilePicture.CopyTo(stream);
				}

				//Save img in DB
				actor.ProfilePicture = fileName;
			}



			_context.Actors.Add(actor);
			_context.SaveChanges();

			TempData["success-notification"] = "Add Actor Successfully";

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]

		public IActionResult Edit(int id)
		{
			var actor = _context.Actors.FirstOrDefault(e => e.Id == id);
			if (actor is null)
			{
				return NotFound();
			}
			return View(actor);
		}

		[HttpPost]
		public IActionResult Edit(Actor actor, IFormFile?  ProfilePicture)
		{
			var actorInDb = _context.Actors.AsNoTracking().FirstOrDefault(e => e.Id == actor.Id);
			if (actorInDb == null)
			{
				return NotFound();
			}
			if (ProfilePicture is not null)
			{

				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePicture.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\cast", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					ProfilePicture.CopyTo(stream);
				}

				//Remove old img from wwwroot
				var oldFileName = actorInDb.ProfilePicture;
				var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\cast", oldFileName);
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}

				//Save img in DB
				actor.ProfilePicture = fileName;
			}
			else
			{
				actor.ProfilePicture = actorInDb.ProfilePicture;
			}

			_context.Actors.Update(actor);
			_context.SaveChanges();

			TempData["success-notification"] = "Update Actor Successfully";

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			var actor = _context.Actors.FirstOrDefault(e => e.Id == id);
			if (actor is null)
			{
				return NotFound();
			}
			_context.Actors.Remove(actor);
			_context.SaveChanges();

			TempData["success-notification"] = "Delete Actor Successfully";

			return RedirectToAction(nameof(Index));
		}


	}
}
