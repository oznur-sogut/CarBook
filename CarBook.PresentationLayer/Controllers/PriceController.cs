using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        public IActionResult PriceIndex()
        {
            var value = _priceService.TGetListAll();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddPrice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPrice(Price price)
        {
            _priceService.TInsert(price);
            return RedirectToAction("PriceIndex");
        }
        public IActionResult DeletePrice(int id)
        {
            var value= _priceService.TGetByID(id);
            _priceService.TDelete(value);
            return RedirectToAction("PriceIndex");
        }
    }
}
