using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IThongTinNhanHangRepository
    {
        Task<IEnumerable<ThongTinNhanHang>> GetAllAsync();
        Task<IEnumerable<ThongTinNhanHang>> GetAllByUserIdAsync(Guid userId);
        Task<ThongTinNhanHang> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ThongTinNhanHang thongTinNhanHang);
        Task<bool> UpdateAsync(Guid id, ThongTinNhanHang thongTinNhanHang);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
