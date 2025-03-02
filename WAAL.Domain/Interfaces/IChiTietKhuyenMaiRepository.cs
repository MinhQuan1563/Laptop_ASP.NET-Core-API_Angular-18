using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietKhuyenMaiRepository
    {
        Task<IEnumerable<ChiTietKhuyenMai>> GetAllAsync();
        Task<bool> CreateAsync(ChiTietKhuyenMai chiTietKhuyenMai);
        Task<ChiTietKhuyenMai?> FindAsync(Guid maHd, Guid maKm);
        Task<bool> UpdateAsync(Guid maHd, Guid maKm, ChiTietKhuyenMai chiTietKhuyenMai);
        Task<bool> DeleteAsync(Guid maHd, Guid maKm);
        Task<bool> SaveAsync();
    }
}
