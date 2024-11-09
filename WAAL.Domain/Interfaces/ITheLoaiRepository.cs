using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ITheLoaiRepository
    {
        Task<IEnumerable<TheLoai>> GetAllAsync(string? search);
        Task<TheLoai> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(TheLoai theLoai);
        Task<bool> UpdateAsync(Guid id, TheLoai theLoai);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
