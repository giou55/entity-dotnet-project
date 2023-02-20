using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_dotnet_project.Models
{
    public class MessageUserViewModel
    {

        public string SelectedSender {get; set;}
        public string SelectedRecipient {get; set;}

        [ValidateNever]
        public List<SelectListItem> UsersList { get; set; }

        [Required]
        public string Content { get; set; }
    }
}