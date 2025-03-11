using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IThongBaoRepository
    {
        Task<IEnumerable<ThongBao>> GetAllAsync();
        Task<IEnumerable<ThongBao>> GetAllByUserAsync(Guid userId);
        Task<ThongBao> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ThongBao thongBao);
        Task<bool> UpdateAsync(Guid id, ThongBao thongBao);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
