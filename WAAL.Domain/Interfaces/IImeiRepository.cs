using WAAL.Domain.Entities;

namespace WAAL.Domain.Interfaces
{
    public interface IImeiRepository
    {
        Task<IEnumerable<Imei>> GetAllAsync();
        Task<IEnumerable<Imei>> GetAllByMaCTSPAsync(Guid maCtsp, int soLuong);
        Task<Imei> GetByIdAsync(Guid id);
        Task<Imei> GetByMaCtspAsync(Guid maCtsp);
        Task<bool> CreateAsync(Imei imei);
        Task<bool> UpdateAsync(Guid id, Imei imei);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
