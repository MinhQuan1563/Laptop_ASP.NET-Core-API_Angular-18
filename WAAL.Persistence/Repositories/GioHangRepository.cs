using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GioHangRepository> _logger;

        public GioHangRepository(ApplicationDbContext context, ILogger<GioHangRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<GioHang>> GetAllByUserAsync(Guid userId)
        {
            return await _context.GioHangs
                .AsNoTracking()
                .Include(d => d.ChiTietSanPham)
                .Include(d => d.User)
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }

        public async Task<GioHang> GetByIdAsync(Guid maCtsp, Guid userId)
        {
            return await _context.GioHangs
                .AsNoTracking()
                .Include(d => d.ChiTietSanPham)
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.MaCtsp == maCtsp && d.UserId == userId) ?? new GioHang();
        }

        public async Task<bool> CreateAsync(GioHang gioHang)
        {
            try
            {
                _context.Attach(gioHang.ChiTietSanPham);
                _context.Attach(gioHang.User);

                await _context.GioHangs.AddAsync(gioHang);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating review.");
                throw;
            }
        }

        public async Task<bool> UpdateSoLuongAsync(Guid userId, Guid maCtsp, int newQuantity)
        {
            var gioHangItem = await _context.GioHangs
                .FirstOrDefaultAsync(g => g.UserId == userId && g.MaCtsp == maCtsp);

            if (gioHangItem == null)
            {
                return false;
            }
            gioHangItem.SoLuong = newQuantity;

            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Guid maCtsp, Guid userId)
        {
            var gioHang = await _context.GioHangs.FirstOrDefaultAsync(d => d.MaCtsp == maCtsp && d.UserId == userId);
            if (gioHang != null)
            {
                _context.GioHangs.Remove(gioHang);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("GioHang");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing GioHang with MaCtsp {MaCtsp} and UserId {UserId}.", maCtsp, userId);
                throw notFoundException;
            }
        }

        public async Task<bool> DeleteAllAsync(Guid userId)
        {
            var gioHangLists = await _context.GioHangs.Where(d => d.UserId == userId).ToListAsync();
            if (gioHangLists != null)
            {
                _context.GioHangs.RemoveRange(gioHangLists);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("GioHang");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing GioHang with UserId {UserId}.", userId);
                throw notFoundException;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
