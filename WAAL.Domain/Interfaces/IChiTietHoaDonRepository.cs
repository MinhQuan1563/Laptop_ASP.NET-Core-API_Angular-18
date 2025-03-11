using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietHoaDonRepository
    {
        Task<IEnumerable<ChiTietHoaDon>> GetAllAsync();
        Task<(IEnumerable<ChiTietHoaDon> Data, int TotalCount)> GetAllByHoaDonAsync(Guid maHd, string? search, int skip, int take);
        Task<bool> CreateAsync(ChiTietHoaDon chiTietHoaDon);
        Task<ChiTietHoaDon?> FindAsync(Guid maHd, Guid maImei);
        Task<bool> UpdateAsync(Guid maHd, Guid maImei, ChiTietHoaDon chiTietHoaDon);
        Task<bool> DeleteAsync(Guid maHd, Guid maImei);
        Task<bool> SaveAsync();
    }
}
