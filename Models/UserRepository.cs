using entity_dotnet_project.Data;

namespace entity_dotnet_project.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;

        public void Add(User u)
        {
            _context.Add(u);
            _context.SaveChanges();
        }

        public async Task AddAsync(User u)
        {
            _context.Add(u);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User u)
        {
            _context.Remove(u);
            await _context.SaveChangesAsync();
        }

        public void Save(User u)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User u)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User u)
        {
            throw new NotImplementedException();
        }
    }
}