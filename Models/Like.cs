using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_dotnet_project.Models
{
    public class Like
    {
        public User SourceUser { get; set; }
        public int SourceUserId { get; set; }

        // target user is being liked by the source user
        public User TargetUser { get; set; }
        public int TargetUserId { get; set; }
    }
}