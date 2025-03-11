using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class CuocTroChuyenRepository : ICuocTroChuyenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CuocTroChuyenRepository> _logger;

        public CuocTroChuyenRepository(ApplicationDbContext context, ILogger<CuocTroChuyenRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(CuocTroChuyen cuocTroChuyen)
        {
            try
            {
                await _context.CuocTroChuyens.AddAsync(cuocTroChuyen);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating item.");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cuocTroChuyen = await _context.CuocTroChuyens.FindAsync(id);
            if (cuocTroChuyen != null)
            {
                _context.CuocTroChuyens.Remove(cuocTroChuyen);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("CuocTroChuyen");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing CuocTroChuyen with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<CuocTroChuyen>> GetAllAsync()
        {
            return await _context.CuocTroChuyens
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<CuocTroChuyen>> GetAllByNhanVienIdAsync(Guid nhanVienId)
        {
            return await _context.CuocTroChuyens
                .AsNoTracking()
                .Where(x => x.NhanVienHoTroId == nhanVienId)
                .ToListAsync();
        }

        public async Task<CuocTroChuyen> GetByIdAsync(Guid id)
        {
            return await _context.CuocTroChuyens.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new CuocTroChuyen();
        }

        public async Task<CuocTroChuyen?> GetByAllIdAsync(Guid khId, Guid nvId)
        {
            return await _context.CuocTroChuyens.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.KhachHangId == khId && e.NhanVienHoTroId == nvId);
        }

        public async Task<bool> UpdateAsync(Guid id, CuocTroChuyen cuocTroChuyen)
        {
            var affectedRows = await _context.CuocTroChuyens
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.LanCapNhatCuoi, cuocTroChuyen.LanCapNhatCuoi)
                    .SetProperty(p => p.TinNhanCuoi, cuocTroChuyen.TinNhanCuoi));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("CuocTroChuyen");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing CuocTroChuyen with ID {Id}.", id);
                throw notFoundException;
            }

            return affectedRows > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
