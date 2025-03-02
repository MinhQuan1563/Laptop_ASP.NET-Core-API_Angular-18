using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IHeDieuHanhRepository
    {
        Task<IEnumerable<HeDieuHanh>> GetAllAsync(string? search);
        Task<HeDieuHanh> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(HeDieuHanh heDieuHanh);
        Task<bool> UpdateAsync(Guid id, HeDieuHanh heDieuHanh);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
