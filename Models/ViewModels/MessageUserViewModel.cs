using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_dotnet_project.Models
{
    public class MessageUserViewModel
    {
        //public IEnumerable<User> Users { get; set; }

        public string SelectedSender {get; set;}
        public string SelectedRecipient {get; set;}
        public List<SelectListItem> UsersList { get; set; }

        public List<User> Users { get; set; }
        public Message Message { get; set; }
    }
}