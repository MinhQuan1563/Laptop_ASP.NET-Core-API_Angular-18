using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class CardDoHoaRepository : ICardDoHoaRepository
    {
        public Task<bool> CreateAsync(CardDoHoa cardDoHoa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CardDoHoa>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CardDoHoa> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, CardDoHoa cardDoHoa)
        {
            throw new NotImplementedException();
        }
    }
}
