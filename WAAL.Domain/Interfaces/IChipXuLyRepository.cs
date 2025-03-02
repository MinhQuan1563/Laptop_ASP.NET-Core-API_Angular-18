using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChipXuLyRepository
    {
        Task<IEnumerable<ChipXuLy>> GetAllAsync(string? search);
        Task<ChipXuLy> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChipXuLy chipXuLy);
        Task<bool> UpdateAsync(Guid id, ChipXuLy chipXuLy);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
