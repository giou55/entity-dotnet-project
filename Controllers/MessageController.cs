using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_dotnet_project.Controllers
{
    public class MessageController : Controller
    {
        public IQueryable<Message> Messages;
        public List<User> Users;
        private readonly IUserRepository _userRepo;
        private IMessageRepository _messageRepo;
        public MessageController(
            IMessageRepository messageRepo,
            IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _messageRepo = messageRepo;
        }

        public IActionResult Index()
        {
            Messages = _messageRepo.Messages;
            return View(Messages);
        }

        public ViewResult AddMessage()
        {
            MessageUserViewModel viewModel = new MessageUserViewModel();
            Users = _userRepo.Users.ToList();
            viewModel.UsersList = new List<SelectListItem>();
            Users = _userRepo.Users.ToList();

            foreach (var user in Users)
            {
               viewModel.UsersList.Add(new SelectListItem {
                    Text = user.Username, Value = user.Id + "-" + user.Username});
            }
            return View("AddMessage", viewModel);
        }

        [HttpPost]
        public IActionResult MessageForm(MessageUserViewModel viewModel)
        {
            var SelectedSender = viewModel.SelectedSender; 
            var SelectedRecipient = viewModel.SelectedRecipient; 
            Console.WriteLine("Content: " + viewModel.Message.Content);
            string[] sender = SelectedSender.Split('-');
            string[] recipient = SelectedRecipient.Split('-');
            Console.WriteLine("Sender Id: " + sender[0]);
            Console.WriteLine("Sender username: " + sender[1]);
            Console.WriteLine("Recipient Id: " + recipient[0]);
            Console.WriteLine("Recipient username: " + recipient[1]);
            return RedirectToAction("Index");
        }
    }
}