using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface INhaCungCapRepository
    {
        Task<(IEnumerable<NhaCungCap> Data, int TotalCount)> GetAllAsync(string? search, int skip, int take);
        Task<NhaCungCap> GetByIdAsync(int id);
        Task<bool> CreateAsync(NhaCungCap nhaCungCap);
        Task<bool> UpdateAsync(int id, NhaCungCap nhaCungCap);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
