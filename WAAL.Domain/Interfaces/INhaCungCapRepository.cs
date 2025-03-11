using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface INhaCungCapRepository
    {
        Task<(IEnumerable<NhaCungCap> Data, int TotalCount)> GetAllAsync(string? search, int skip, int take);
        Task<IEnumerable<NhaCungCap>> GetAllNoPagAsync();
        Task<NhaCungCap> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NhaCungCap nhaCungCap);
        Task<bool> UpdateAsync(Guid id, NhaCungCap nhaCungCap);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
