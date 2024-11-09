using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ICardDoHoaRepository
    {
        Task<IEnumerable<CardDoHoa>> GetAllAsync(string? search);
        Task<CardDoHoa> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CardDoHoa cardDoHoa);
        Task<bool> UpdateAsync(Guid id, CardDoHoa cardDoHoa);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
