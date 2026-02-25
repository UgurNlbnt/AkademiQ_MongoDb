using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
