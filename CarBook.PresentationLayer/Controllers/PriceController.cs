using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.PresentationLayer.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        private readonly ICarService _carService;

        public PriceController(IPriceService priceService, ICarService carService)
        {
            _priceService = priceService;
            _carService = carService;
        }

        public IActionResult PriceIndex()
        {
            var value = _priceService.TGetPriceWithCars();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddPrice()
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                          select new SelectListItem
                                          {
                                              Text = x.Brand.BrandName + " " + x.CarModel,
                                              Value = x.CarID.ToString()
                                          }).ToList();
            ViewBag.v=values;
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
        [HttpGet]
        public IActionResult UpdatePrice(int id)
        {

            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.CarModel,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            var value = _priceService.TGetByID(id); 
            return View(value);
        }
        [HttpPost]
        
        public IActionResult UpdatePrice(Price price)
        {
            _priceService.TUpdate(price);
            return RedirectToAction("PriceIndex");
        }
        //Arabanın modelinin adını getirmek için Entity özgü method yazdık bunları Liste şeklinde tüm katmanlarda tanımlayıp içeriğini oluşturduk
    }
}
