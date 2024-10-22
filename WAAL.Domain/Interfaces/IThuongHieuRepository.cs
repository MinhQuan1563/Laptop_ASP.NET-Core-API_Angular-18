using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IThuongHieuRepository
    {
        Task<IEnumerable<ThuongHieu>> GetAllAsync(string? search);
        Task<ThuongHieu> GetByIdAsync(int id);
        Task<bool> CreateAsync(ThuongHieu thuongHieu);
        Task<bool> UpdateAsync(int id, ThuongHieu thuongHieu);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
