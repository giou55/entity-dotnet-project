using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Controllers
{
    public class MessageController : Controller
    {
        public IQueryable<Message> Messages;
        public List<User> Users;
        private readonly IUserRepository _userRepo;
        private IMessageRepository _messageRepo;
        public MessageController(IMessageRepository messageRepo, IUserRepository userRepo)
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

            foreach (var user in Users)
            {
               viewModel.UsersList.Add(new SelectListItem {
                    Text = user.Username, Value = user.Id + "-" + user.Username});
            }
            return View("AddMessage", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> MessageForm(MessageUserViewModel viewModel)
        {
            var SelectedSender = viewModel.SelectedSender; 
            var SelectedRecipient = viewModel.SelectedRecipient; 
            Console.WriteLine("Content: " + viewModel.Message.Content);
            string[] sender = SelectedSender.Split('-');
            string[] recipient = SelectedRecipient.Split('-');
            // Console.WriteLine("Sender Id: " + sender[0]);
            // Console.WriteLine("Sender username: " + sender[1]);
            // Console.WriteLine("Recipient Id: " + recipient[0]);
            // Console.WriteLine("Recipient username: " + recipient[1]);

            var message = new Message 
            {
                SenderId = Int32.Parse(sender[0]),
                SenderUsername = sender[1],
                RecipientId = Int32.Parse(recipient[0]),
                RecipientUsername = recipient[1],
                Content = viewModel.Message.Content
            };
            await _messageRepo.AddAsync(message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            Message? m = await _messageRepo.Messages
                .FirstOrDefaultAsync(m => m.Id == id) ?? new Message();
            if (m != null)
            {
                await _messageRepo.Delete(m);
                return Redirect("~/Message");
            }
            return NotFound();
        }
    }
}