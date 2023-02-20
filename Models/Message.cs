using System.ComponentModel.DataAnnotations;

namespace entity_dotnet_project.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderUsername { get; set; }

        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
        public User Recipient{ get; set; }
        public string Content { get; set; }
    }
}