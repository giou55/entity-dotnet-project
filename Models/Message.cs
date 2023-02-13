using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_dotnet_project.Models
{
    public class Message
    {
        public int Id { get; set; }

        // automapper is smart enough to know how to populate the SenderId
        // based on AppUser Sender
        public int SenderId { get; set; }

        // automapper is also smart enough to know how to populate the SenderUsername 
        // based on AppUser Sender
        public string SenderUsername { get; set; }

        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
        public User Recipient{ get; set; }
        public string Content { get; set; }
    }
}