namespace entity_dotnet_project.Models
{
    public interface ILikeRepository
    {
        IQueryable<Like> Likes { get; }
        void Add(Like l);
        Task AddAsync(Like l);
        Task Delete(Like l);
        void Save(Like l);
        Task SaveAsync(Like l);
    }
}