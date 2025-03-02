using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ChiTietKhuyenMaiRepository : IChiTietKhuyenMaiRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChiTietKhuyenMaiRepository> _logger;

        public ChiTietKhuyenMaiRepository(ApplicationDbContext context, ILogger<ChiTietKhuyenMaiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            try
            {
                _context.Attach(chiTietKhuyenMai.KhuyenMai);
                _context.Attach(chiTietKhuyenMai.HoaDon);

                await _context.ChiTietKhuyenMais.AddAsync(chiTietKhuyenMai);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating item.");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid maHd, Guid maKm)
        {
            var chiTietKhuyenMai = await FindAsync(maHd, maKm);
            if (chiTietKhuyenMai != null)
            {
                _context.ChiTietKhuyenMais.Remove(chiTietKhuyenMai);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChiTietKhuyenMai");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChiTietKhuyenMai with maHd {maHd}.", maHd);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ChiTietKhuyenMai>> GetAllAsync()
        {
            return await _context.ChiTietKhuyenMais
                .AsNoTracking()
                .Include(c => c.KhuyenMai)
                .Include(c => c.KhuyenMai)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Guid maHd, Guid maKm, ChiTietKhuyenMai chiTietKhuyenMai)
        {
            try
            {
                var existingChiTietKhuyenMai = await FindAsync(maHd, maKm);
                if (existingChiTietKhuyenMai == null)
                {
                    var notFoundException = new EntityNotFoundException("ChiTietKhuyenMai");
                    _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChiTietKhuyenMai");
                    throw notFoundException;
                }

                existingChiTietKhuyenMai.GiaTienGIam = chiTietKhuyenMai.GiaTienGIam;

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating ChiTietKhuyenMai.");
                throw;
            }
        }

        public async Task<ChiTietKhuyenMai?> FindAsync(Guid maHd, Guid maKm)
        {
            return await _context.ChiTietKhuyenMais
                .Include(c => c.KhuyenMai)
                .Include(c => c.KhuyenMai)
                .FirstOrDefaultAsync(cthd => cthd.MaHd == maHd &&
                                            cthd.MaKm == maKm);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
