namespace entity_dotnet_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        // these are the users that like AppUser
        public List<Like>? LikedByUsers { get; set; }

        // these are the users that the AppUser likes
        public List<Like>? LikedUsers { get; set; }

        public List<Message>? MessagesSent { get; set; }
        public List<Message>? MessagesReceived { get; set; }
    }
}