using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.Controllers
{
    public class MessageController : Controller
    {
        public IQueryable<Message> Messages;

        private IMessageRepository repository;
        public MessageController(IMessageRepository messageRepo)
        {
            repository = messageRepo;
        }

        public IActionResult Index()
        {
            Messages = repository.Messages;
            return View(Messages);
        }

        public ViewResult AddMessage()
        {
            return View("AddMessage");
        }
    }
}