namespace entity_dotnet_project.Models
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        void Add(Message m);
        Task AddAsync(Message m);
        Task Delete(Message m);
        void Save(Message m);
        Task SaveAsync(Message m);
        Task<int> MessagesNumber();
    }
}