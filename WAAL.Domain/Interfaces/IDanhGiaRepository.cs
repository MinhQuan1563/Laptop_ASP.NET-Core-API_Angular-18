using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IDanhGiaRepository
    {
        Task<IEnumerable<DanhGia>> GetAllAsync();
        Task<(IEnumerable<DanhGia> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take);
        Task<IEnumerable<DanhGia>> GetAllBySanPhamAsync(Guid maSp);
        Task<(IEnumerable<DanhGia> Data, int TotalCount)> GetAllPaginationBySanPhamAsync(Guid maSp, string? search, int skip, int take);
        Task<DanhGia> GetByIdAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia);
        Task<bool> CreateAsync(DanhGia danhGia);
        Task<bool> UpdateAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia, DanhGia danhGia);
        Task<bool> DeleteAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia);
        Task<IEnumerable<DanhGia>> GetByRatingAsync(float rating);
        Task<bool> SaveAsync();
    }
}
