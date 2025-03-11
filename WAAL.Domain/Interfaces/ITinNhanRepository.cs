using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ITinNhanRepository
    {
        Task<IEnumerable<TinNhan>> GetByConversationIdAsync(Guid cuocTroChuyenId);
        Task<bool> CreateAsync(TinNhan tinNhan);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
