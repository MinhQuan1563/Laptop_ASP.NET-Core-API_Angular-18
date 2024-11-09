using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietSanPhamRepository
    {
        Task<IEnumerable<ChiTietSanPham>> GetAllAsync(string? search);
        Task<ChiTietSanPham> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChiTietSanPham chiTietSanPham);
        Task<bool> UpdateAsync(Guid id, ChiTietSanPham chiTietSanPham);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
