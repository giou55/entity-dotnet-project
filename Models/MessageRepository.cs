using entity_dotnet_project.Data;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Message> Messages => _context.Messages;

        public void Add(Message m)
        {
            _context.Add(m);
            _context.SaveChanges();
        }

        public async Task AddAsync(Message m)
        {
            _context.Add(m);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Message m)
        {
            _context.Remove(m);
            await _context.SaveChangesAsync();
        }

        public void Save(Message m)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Message m)
        {
            throw new NotImplementedException();
        }

        public async Task<int> MessagesNumber() {
            return await _context.Messages.CountAsync();
        } 
    }
}