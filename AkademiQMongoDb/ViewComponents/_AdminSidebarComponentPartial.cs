using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
