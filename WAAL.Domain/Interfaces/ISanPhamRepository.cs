using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync(string? search);
        Task<SanPham> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(SanPham sanPham);
        Task<bool> UpdateAsync(Guid id, SanPham sanPham);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
