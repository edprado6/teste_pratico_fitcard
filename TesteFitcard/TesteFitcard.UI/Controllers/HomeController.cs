using Microsoft.AspNetCore.Mvc;

namespace TesteFitcard.UI.Controllers
{
    /// <summary>
    /// Controller default.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Método default.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }        
    }
}
