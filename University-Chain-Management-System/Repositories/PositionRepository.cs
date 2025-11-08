using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _context;

        public PositionRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Position position)
        {
            _context.Add(position);
            return Save();
        }

        public bool Delete(Position position)
        {
            _context.Remove(position);
            return Save();
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetById(int id)
        {
            return await _context.Positions
                .Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Position position)
        {
            _context.Update(position);
            return Save();
        }
    }
}
