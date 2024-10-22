using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ITheLoaiRepository
    {
        Task<IEnumerable<TheLoai>> GetAllAsync(string? search);
        Task<TheLoai> GetByIdAsync(int id);
        Task<bool> CreateAsync(TheLoai theLoai);
        Task<bool> UpdateAsync(int id, TheLoai theLoai);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
