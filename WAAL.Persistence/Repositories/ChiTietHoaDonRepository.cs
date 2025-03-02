using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ChiTietHoaDonRepository : IChiTietHoaDonRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChiTietHoaDonRepository> _logger;

        public ChiTietHoaDonRepository(ApplicationDbContext context, ILogger<ChiTietHoaDonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                _context.Attach(chiTietHoaDon.HoaDon);
                _context.Attach(chiTietHoaDon.Imei);

                await _context.ChiTietHoaDons.AddAsync(chiTietHoaDon);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating item.");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid maHd, Guid maImei)
        {
            var chiTietHoaDon = await FindAsync(maHd, maImei);
            if (chiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(chiTietHoaDon);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChiTietHoaDon");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChiTietHoaDon with maHd {maHd}.", maHd);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ChiTietHoaDon>> GetAllAsync()
        {
            return await _context.ChiTietHoaDons
                .AsNoTracking()
                .Include(c => c.HoaDon)
                .Include(c => c.Imei)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Guid maHd, Guid maImei, ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                var existingChiTietHoaDon = await FindAsync(maHd, maImei);
                if (existingChiTietHoaDon == null)
                {
                    var notFoundException = new EntityNotFoundException("ChiTietHoaDon");
                    _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChiTietHoaDon");
                    throw notFoundException;
                }

                existingChiTietHoaDon.GiaSp = chiTietHoaDon.GiaSp;
                existingChiTietHoaDon.SoLuong = chiTietHoaDon.SoLuong;

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating ChiTietKhuyenMai.");
                throw;
            }
        }

        public async Task<ChiTietHoaDon?> FindAsync(Guid maHd, Guid maImei)
        {
            return await _context.ChiTietHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.Imei)
                .FirstOrDefaultAsync(cthd => cthd.MaHd == maHd &&
                                            cthd.MaImei == maImei);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
