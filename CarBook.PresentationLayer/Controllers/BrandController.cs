using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public IActionResult BrandIndex()
		{
			var value= _brandService.TGetListAll();
			return View(value);
		}
	}
}
