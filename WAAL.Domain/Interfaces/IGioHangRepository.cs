using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IGioHangRepository
    {
        Task<IEnumerable<GioHang>> GetAllByUserAsync(Guid userId);
        Task<GioHang> GetByIdAsync(Guid maSp, Guid userId);
        Task<bool> CreateAsync(GioHang gioHang);
        Task<bool> UpdateSoLuongAsync(Guid maCtsp, Guid userId, int newQuantity);
        Task<bool> DeleteAsync(Guid maSp, Guid userId);
        Task<bool> DeleteAllAsync(Guid userId);
        Task<bool> SaveAsync();
    }
}
