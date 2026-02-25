using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
