using Microsoft.AspNetCore.Mvc;
using WebApplication7.BL.Helpers;

namespace WebApplication7.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail(string Title,string Message)
        {
            MailHelper.sendMail(Title, Message);

            return RedirectToAction("Index");
        }
        public IActionResult MailBox()
        {
            return View();
        }
    }
}
