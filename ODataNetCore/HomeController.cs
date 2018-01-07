using Microsoft.AspNetCore.Mvc;

namespace ODataNetCore
{
    public class HomeController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
