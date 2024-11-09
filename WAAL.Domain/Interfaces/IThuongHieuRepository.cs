using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IThuongHieuRepository
    {
        Task<IEnumerable<ThuongHieu>> GetAllAsync(string? search);
        Task<ThuongHieu> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ThuongHieu thuongHieu);
        Task<bool> UpdateAsync(Guid id, ThuongHieu thuongHieu);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
