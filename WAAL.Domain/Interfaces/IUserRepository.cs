using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<(IEnumerable<AppUser> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<AppUser> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(AppUser user);
        Task<bool> UpdateAsync(Guid id, AppUser user);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
