using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_dotnet_project.Models
{
    public class LikeUserViewModel
    {
        //public IEnumerable<User> Users { get; set; }

        public string SelectedSender {get; set;}
        public string SelectedRecipient {get; set;}
        public List<SelectListItem> UsersList { get; set; }
    }
}