using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
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
        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            var value=_carService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            _carService.TUpdate(car);
            return RedirectToAction("CarIndex");
        }
    }
}
