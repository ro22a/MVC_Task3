using Microsoft.AspNetCore.Mvc;

namespace ETicketsSystem.Areas.Admin.Controllers
{
	[Area(SD.AdminArea)]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
