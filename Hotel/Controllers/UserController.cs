using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SignUp()
        {
            return View(); 
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
