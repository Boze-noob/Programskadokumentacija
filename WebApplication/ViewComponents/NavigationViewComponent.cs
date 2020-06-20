using Microsoft.AspNetCore.Mvc;

namespace WebApplication.ViewComponents
{/// <summary>
 /// Navigacijski prikaz komponenti
 /// </summary>
    public class NavigationViewComponent : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Controller = RouteData?.Values["controller"];
            return View();
        }
    }
}