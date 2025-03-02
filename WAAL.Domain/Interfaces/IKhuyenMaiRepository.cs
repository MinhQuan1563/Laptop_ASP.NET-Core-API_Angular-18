using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IKhuyenMaiRepository
    {
        Task<(IEnumerable<KhuyenMai> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take);
        Task<IEnumerable<KhuyenMai>> GetAllAsync(string? search);
        Task<KhuyenMai> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(KhuyenMai khuyenMai);
        Task<bool> UpdateAsync(Guid id, KhuyenMai khuyenMai);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
