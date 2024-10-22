using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ICardDoHoaRepository
    {
        Task<IEnumerable<CardDoHoa>> GetAllAsync(string? search);
        Task<CardDoHoa> GetByIdAsync(int id);
        Task<bool> CreateAsync(CardDoHoa cardDoHoa);
        Task<bool> UpdateAsync(int id, CardDoHoa cardDoHoa);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
