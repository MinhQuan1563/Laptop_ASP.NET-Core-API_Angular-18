using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HoaDonRepository> _logger;

        public HoaDonRepository(ApplicationDbContext context, ILogger<HoaDonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<HoaDon>> GetAllAsync()
        {
            return await _context.HoaDons
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.ThongTinNhanHang)
                .Where(q => q.TrangThai)
                .ToListAsync();
        }

        public async Task<bool> CreateAsync(HoaDon hoaDon)
        {
            try
            {
                _context.Entry(hoaDon.User).State = EntityState.Unchanged;
                _context.Entry(hoaDon.ThongTinNhanHang).State = EntityState.Unchanged;

                await _context.HoaDons.AddAsync(hoaDon);
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
            var hoaDon = await GetByIdAsync(id);
            if (hoaDon != null)
            {
                hoaDon.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("HoaDon");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing HoaDon with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<HoaDon> Data, int TotalCount)> GetAllPaginationAsync(string? tinhTrang, string? search, int skip, int take)
        {
            IQueryable<HoaDon> query = _context.HoaDons
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.ThongTinNhanHang)
                .Where(q => q.TrangThai);

            if(!string.IsNullOrEmpty(tinhTrang))
            {
                query = query.Where(c => c.TinhTrang.ToString().Contains(tinhTrang));
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.NgayLap.ToString().Contains(search)
                                         || c.TongTien.ToString().Contains(search)
                                         || c.TongTienSauKhuyenMai.ToString().Contains(search)
                                         || c.PhuongThucThanhToan.ToString().Contains(search)
                                         || c.GhiChu.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<(IEnumerable<HoaDon> Data, int TotalCount)> GetAllByUserPaginationAsync(Guid userId, string? tinhTrang, string? search, int skip, int take)
        {
            IQueryable<HoaDon> query = _context.HoaDons
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.ThongTinNhanHang)
                .Where(q => q.TrangThai && q.User.Id == userId);

            if (!string.IsNullOrEmpty(tinhTrang))
            {
                query = query.Where(c => c.TinhTrang.ToString().Contains(tinhTrang));
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.NgayLap.ToString().Contains(search)
                                         || c.TongTien.ToString().Contains(search)
                                         || c.TongTienSauKhuyenMai.ToString().Contains(search)
                                         || c.PhuongThucThanhToan.ToString().Contains(search)
                                         || c.GhiChu.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<HoaDon> GetByIdAsync(Guid id)
        {
            return await _context.HoaDons.AsNoTrackingWithIdentityResolution()
                .Include(s => s.User)
                .Include(s => s.ThongTinNhanHang)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new HoaDon();
        }

        public async Task<bool> UpdateTinhTrangAsync(Guid id, string? tinhTrang)
        {
            var hoaDon = await GetByIdAsync(id);
            if(hoaDon == null)
            {
                var notFoundException = new EntityNotFoundException("HoaDon");
                _logger.LogWarning(notFoundException, "HoaDon not found with ID {Id}.", id);
                throw notFoundException;
            }

            if(!string.IsNullOrEmpty(tinhTrang))
            {
                hoaDon.TinhTrang = tinhTrang;
                return await SaveAsync();
            }

            return false;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
