using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IMauSacRepository
    {
        Task<IEnumerable<MauSac>> GetAllAsync(string? search);
        Task<MauSac> GetByIdAsync(int id);
        Task<bool> CreateAsync(MauSac mauSac);
        Task<bool> UpdateAsync(int id, MauSac mauSac);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
