using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.Controllers
{
    public class MessageController : Controller
    {
        public MessageController()
        {
    
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddMessage()
        {
            return View("AddMessage");
        }
    }
}