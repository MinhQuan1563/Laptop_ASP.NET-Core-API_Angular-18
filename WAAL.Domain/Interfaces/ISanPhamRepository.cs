using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync(string? search);
        Task<SanPham> GetByIdAsync(int id);
        Task<bool> CreateAsync(SanPham sanPham);
        Task<bool> UpdateAsync(int id, SanPham sanPham);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
