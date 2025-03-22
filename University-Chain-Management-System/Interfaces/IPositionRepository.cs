using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAll();
        Task<Position> GetById(int id);
        bool Add(Position position);
        bool Update(Position position);
        bool Delete(Position position);
        bool Save();
    }
}
