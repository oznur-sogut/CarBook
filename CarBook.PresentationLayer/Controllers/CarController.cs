using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult CarIndex()
        {
            var value= _carService.TGetListAll();
            return View(value);
        }
        public IActionResult CarListWithBrands()
        {
            var value= _carService.TGetAllCarsWithBrands();
            return View(value);
        }
    }
}
