using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
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
		[HttpGet]
		public IActionResult AddBrand()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddBrand(Brand brand)
		{

			_brandService.TInsert(brand);
			return RedirectToAction("BrandIndex");
		}
		public IActionResult DeleteBrand(int id)
		{
			var value= _brandService.TGetByID(id);
			_brandService.TDelete(value);
			return RedirectToAction("BrandIndex");
		}
		[HttpGet]
		public IActionResult UpdateBrand(int id)
		{
			var value = _brandService.TGetByID(id);
			_brandService.TUpdate(value);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateBrand(Brand brand)
		{
			_brandService.TUpdate(brand);
			return RedirectToAction("BrandIndex");
		}
	}
}
