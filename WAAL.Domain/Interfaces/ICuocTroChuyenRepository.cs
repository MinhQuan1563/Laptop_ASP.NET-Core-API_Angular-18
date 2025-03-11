using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface ICuocTroChuyenRepository
    {
        Task<CuocTroChuyen> GetByIdAsync(Guid id);
        Task<CuocTroChuyen> GetByAllIdAsync(Guid khId, Guid nvId);
        Task<IEnumerable<CuocTroChuyen>> GetAllAsync();
        Task<IEnumerable<CuocTroChuyen>> GetAllByNhanVienIdAsync(Guid nhanVienId);
        Task<bool> CreateAsync(CuocTroChuyen cuocTroChuyen);
        Task<bool> UpdateAsync(Guid id, CuocTroChuyen cuocTroChuyen);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
