using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class InventoryDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
