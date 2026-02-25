using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
