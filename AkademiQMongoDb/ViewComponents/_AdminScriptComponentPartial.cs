using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}