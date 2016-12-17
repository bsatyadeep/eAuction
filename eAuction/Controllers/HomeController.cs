using System;
using System.Web.Mvc;

namespace eAuction.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3)]
        public ActionResult Index()
        {
            ViewBag.Message = "This page was rendered at :" + DateTime.Now;
            return View();
        }
    }
}