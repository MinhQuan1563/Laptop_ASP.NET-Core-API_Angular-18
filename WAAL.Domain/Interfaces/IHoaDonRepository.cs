using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IHoaDonRepository
    {
        Task<IEnumerable<HoaDon>> GetAllAsync();
        Task<(IEnumerable<HoaDon> Data, int TotalCount)> GetAllPaginationAsync(string? tinhTrang, string? search, int skip, int take);
        Task<(IEnumerable<HoaDon> Data, int TotalCount)> GetAllByUserPaginationAsync(Guid userId, string? tinhTrang, string? search, int skip, int take);
        Task<HoaDon> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(HoaDon hoaDon);
        Task<bool> UpdateTinhTrangAsync(Guid id, string? tinhTrang);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
