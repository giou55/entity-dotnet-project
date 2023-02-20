using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.ViewComponents
{
    public class MessageIcon : ViewComponent
    {
        private readonly IMessageRepository _messageRepo;
        public MessageIcon(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int messagesNumber = await _messageRepo.MessagesNumber();
            return View(messagesNumber);
        }
    }
}
