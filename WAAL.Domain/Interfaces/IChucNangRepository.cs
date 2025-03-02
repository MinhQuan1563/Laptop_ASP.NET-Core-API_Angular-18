using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChucNangRepository
    {
        Task<IEnumerable<ChucNang>> GetAllAsync();
        Task<ChucNang> GetByIdAsync(Guid id);
        Task<ChucNang> GetNameAsync(string tenChucNang);
        Task<bool> CreateAsync(ChucNang chucNang);
        Task<bool> UpdateAsync(Guid id, ChucNang chucNang);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
