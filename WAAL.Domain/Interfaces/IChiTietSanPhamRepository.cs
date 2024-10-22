using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietSanPhamRepository
    {
        Task<IEnumerable<ChiTietSanPham>> GetAllAsync(string? search);
        Task<ChiTietSanPham> GetByIdAsync(int id);
        Task<bool> CreateAsync(ChiTietSanPham chiTietSanPham);
        Task<bool> UpdateAsync(int id, ChiTietSanPham chiTietSanPham);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
