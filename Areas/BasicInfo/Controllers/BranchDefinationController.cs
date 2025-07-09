using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class BranchDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
