using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class CarStatusController : Controller
    {
        private readonly ICarStatusService _carStatusService;

        public CarStatusController(ICarStatusService carStatusService)
        {
            _carStatusService = carStatusService;
        }

        public IActionResult CarStatusIndex()
        {
            var value = _carStatusService.TGetListAll();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddStatus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStatus(CarStatus carStatus)
        {
            _carStatusService.TInsert(carStatus);
            return RedirectToAction("CarStatusIndex");
        }
        public IActionResult DeleteStatus(int id)
        {
            var value =_carStatusService.TGetByID(id);
            _carStatusService.TDelete(value);
            return RedirectToAction("CarStatusIndex");
        }
        [HttpGet]
        public IActionResult UpdateStatus (int id)
        {
            var value = _carStatusService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateStatus (CarStatus carStatus)
        {
            _carStatusService.TUpdate(carStatus);
            return RedirectToAction("CarStatusIndex");
        }
    }
}
