using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IMauSacRepository
    {
        Task<IEnumerable<MauSac>> GetAllAsync(string? search);
        Task<MauSac> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(MauSac mauSac);
        Task<bool> UpdateAsync(Guid id, MauSac mauSac);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
