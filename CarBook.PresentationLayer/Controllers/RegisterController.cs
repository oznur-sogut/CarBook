using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //çağrılan metod asenkron olduğundan asenkron olarak oluşturulması gerekiyor. Identity asenkrondur.
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            //yardımcı sınıflar ViewModals olarak adlandırılır
            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName
            };
            //await = asenkron ifadeleri kullanabilmek için kullanılan keywordtür.
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                
                foreach (var item in result.Errors)
                {
                //gelecek olan hataların UI tarafında gösteren kısımdır
                ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
