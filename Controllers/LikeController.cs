using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.Controllers
{
    public class LikeController : Controller
    {

        public LikeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddLike()
        {
            return View("AddLike");
        }
    }
}