
using ETicketsSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Areas.Admin.Controllers
{
	[Area(SD.AdminArea)]
	public class CategoryController : Controller
	{
		ApplicationDbContext _context = new ApplicationDbContext();
		public IActionResult Index(int page = 1)
		{
			var categories = _context.Categories.Include(e => e.Movies).AsQueryable();

			//Pagination
			var TotalNumOfPages = Math.Ceiling(categories.Count() / 10.0);
			ViewBag.TotalNumOfPages = TotalNumOfPages;
			var currentpage = page;
			ViewBag.CurrentPage = currentpage;
			categories = categories.Skip((page - 1) * 10).Take(10);

			return View(categories.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			

			
			_context.Categories.Add(category);
			_context.SaveChanges();

			TempData["success-notification"] = "Add Category Successfully";

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var category = _context.Categories.FirstOrDefault(e => e.Id == id);
			if (category is null)
			{
				return NotFound();
			}
			return View(category);

		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();

			TempData["success-notification"] = "Update Category Successfully";

			return RedirectToAction(nameof(Index));

		}

		public IActionResult Delete(int id)
		{
			var category = _context.Categories.FirstOrDefault(e => e.Id == id);
			if (category is null)
			{
				return NotFound();
			}
			_context.Categories.Remove(category);
			_context.SaveChanges();

			TempData["success-notification"] = "Delete Category Successfully";

			return RedirectToAction(nameof(Index));
		}
	}
}
