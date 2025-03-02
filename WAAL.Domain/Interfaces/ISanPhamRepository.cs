using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<(IEnumerable<SanPham> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take);
        Task<SanPham> GetByIdAsync(Guid id);
        Task<SanPham> GetSanPhamByMaCtsp(Guid mactsp);
        Task<bool> CreateAsync(SanPham sanPham);
        Task<bool> UpdateAsync(Guid id, SanPham sanPham);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
