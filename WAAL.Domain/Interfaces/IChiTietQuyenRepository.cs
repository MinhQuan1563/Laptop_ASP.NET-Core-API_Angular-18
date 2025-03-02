using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IChiTietQuyenRepository
    {
        Task<IEnumerable<ChiTietQuyen>> GetAllAsync();
        Task<IEnumerable<ChiTietQuyen>> GetAllChiTietQuyenByRoleAsync(Guid roleId);
        Task<bool> CreateAsync(ChiTietQuyen chiTietQuyen);
        Task<ChiTietQuyen?> FindAsync(Guid roleId, Guid maChucNang, string hanhDong);
        Task<bool> UpdateAsync(ChiTietQuyen chiTietQuyen);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<string>> CheckQuyenAsync(ChiTietQuyen chiTietQuyen);
        Task<bool> SaveAsync();
    }
}
