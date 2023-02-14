namespace entity_dotnet_project.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void Add(User p);
        Task AddAsync(User p);
        Task Delete(User p);
        void Save(User p);
        Task SaveAsync(User p);
    }
}