using entity_dotnet_project.Data;

namespace entity_dotnet_project.Models
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DataContext _context;
        public LikeRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Like> Likes => _context.Likes;

        public void Add(Like l)
        {
            _context.Add(l);
            _context.SaveChanges();
        }

        public async Task AddAsync(Like l)
        {
            _context.Add(l);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Like l)
        {
            _context.Remove(l);
            await _context.SaveChangesAsync();
        }

        public void Save(Like l)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Like l)
        {
            throw new NotImplementedException();
        }
    }
}