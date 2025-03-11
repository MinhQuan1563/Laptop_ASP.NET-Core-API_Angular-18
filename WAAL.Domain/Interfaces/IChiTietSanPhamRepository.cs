using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietSanPhamRepository
    {
        Task<(IEnumerable<ChiTietSanPham> Data, int TotalCount)> GetAllAsync(string? search, int skip, int take);
        Task<(IEnumerable<ChiTietSanPham> Data, int TotalCount)> GetAllBySanPhamAsync(Guid maSp, string? search, int skip, int take);
        Task<ChiTietSanPham> GetByIdAsync(Guid id);
        Task<ChiTietSanPham> GetByMaImeiAsync(Guid maImei);
        Task<bool> CreateAsync(ChiTietSanPham chiTietSanPham);
        Task<bool> UpdateAsync(Guid id, ChiTietSanPham chiTietSanPham);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
