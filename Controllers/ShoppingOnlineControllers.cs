using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class ShoppingOnlineControllers : Controller
    {
        public IActionResult Index()
        {
            return Content("sono la index della home");
        }
    }
}
