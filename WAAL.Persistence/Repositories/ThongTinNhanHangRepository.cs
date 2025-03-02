using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ThongTinNhanHangRepository : IThongTinNhanHangRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ThongTinNhanHangRepository> _logger;

        public ThongTinNhanHangRepository(ApplicationDbContext context, ILogger<ThongTinNhanHangRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ThongTinNhanHang thongTinNhanHang)
        {
            try
            {
                _context.Attach(thongTinNhanHang.User);

                await _context.ThongTinNhanHangs.AddAsync(thongTinNhanHang);
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
            var thongTinNhanHang = await _context.ThongTinNhanHangs.FindAsync(id);
            if (thongTinNhanHang != null)
            {
                _context.ThongTinNhanHangs.Remove(thongTinNhanHang);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ThongTinNhanHang");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ThongTinNhanHang with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ThongTinNhanHang>> GetAllAsync()
        {
            return await _context.ThongTinNhanHangs
                .AsNoTracking().Include(c => c.User)
                .Where(q => q.TrangThai == true).ToListAsync();
        }

        public async Task<IEnumerable<ThongTinNhanHang>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.ThongTinNhanHangs
                .AsNoTracking().Include(c => c.User)
                .Where(q => q.TrangThai == true & q.User.Id == userId)
                .ToListAsync();
        }
        public async Task<ThongTinNhanHang> GetByIdAsync(Guid id)
        {
            return await _context.ThongTinNhanHangs
                .AsNoTrackingWithIdentityResolution().Include(c => c.User)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ThongTinNhanHang();
        }

        public async Task<bool> UpdateAsync(Guid id, ThongTinNhanHang thongTinNhanHang)
        {
            var affectedRows = await _context.ThongTinNhanHangs
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.HoTen, thongTinNhanHang.HoTen)
                    .SetProperty(p => p.SoDienThoai, thongTinNhanHang.SoDienThoai)
                    .SetProperty(p => p.DiaChi, thongTinNhanHang.DiaChi)
                    .SetProperty(p => p.DiaChiMacDinh, thongTinNhanHang.DiaChiMacDinh)
                    .SetProperty(p => p.User, thongTinNhanHang.User));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ThongTinNhanHang");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ThongTinNhanHang with ID {Id}.", id);
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
