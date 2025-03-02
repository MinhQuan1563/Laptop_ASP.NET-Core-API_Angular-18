using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class DanhGiaRepository : IDanhGiaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DanhGiaRepository> _logger;

        public DanhGiaRepository(ApplicationDbContext context, ILogger<DanhGiaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<DanhGia>> GetAllAsync()
        {
            return await _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .Where(d => d.TrangThai)
                .ToListAsync();
        }

        public async Task<IEnumerable<DanhGia>> GetAllBySanPhamAsync(Guid maSp)
        {
            return await _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .Where(d => d.TrangThai && d.SanPham.Id == maSp)
                .ToListAsync();
        }
        
        public async Task<(IEnumerable<DanhGia> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take)
        {
            IQueryable<DanhGia> query = _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .Where(d => d.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.NoiDung.Contains(search)
                                         || d.SanPham.TenSp.Contains(search));
            }

            int totalCount = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();

            return (result, totalCount);
        }

        public async Task<(IEnumerable<DanhGia> Data, int TotalCount)> GetAllPaginationBySanPhamAsync(Guid maSp, string? search, int skip, int take)
        {
            IQueryable<DanhGia> query = _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .Where(d => d.TrangThai && d.MaSp == maSp);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.NoiDung.Contains(search)
                                         || d.SanPham.TenSp.Contains(search));
            }

            int totalCount = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();

            return (result, totalCount);
        }

        public async Task<DanhGia> GetByIdAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia)
        {
            return await _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.MaSp == maSp && d.UserId == userId && d.ThoiGianDanhGia == thoiGianDanhGia) ?? new DanhGia();
        }

        public async Task<bool> CreateAsync(DanhGia danhGia)
        {
            try
            {
                _context.Attach(danhGia.SanPham);
                _context.Attach(danhGia.User);

                await _context.DanhGias.AddAsync(danhGia);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating review.");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia, DanhGia danhGia)
        {
            var existingDanhGia = await _context.DanhGias
                .FirstOrDefaultAsync(d => d.MaSp == maSp && d.UserId == userId && d.ThoiGianDanhGia == thoiGianDanhGia);

            if (existingDanhGia == null)
            {
                var notFoundException = new EntityNotFoundException("DanhGia");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing DanhGia with MaSp {MaSp} and UserId {UserId}.", maSp, userId);
                throw notFoundException;
            }

            existingDanhGia.Rating = danhGia.Rating;
            existingDanhGia.NoiDung = danhGia.NoiDung;
            existingDanhGia.ThoiGianDanhGia = danhGia.ThoiGianDanhGia;
            existingDanhGia.TrangThai = danhGia.TrangThai;

            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Guid maSp, Guid userId, DateTime thoiGianDanhGia)
        {
            var danhGia = await _context.DanhGias.FirstOrDefaultAsync(d => d.MaSp == maSp && d.UserId == userId && d.ThoiGianDanhGia == thoiGianDanhGia);
            if (danhGia != null)
            {
                danhGia.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("DanhGia");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing DanhGia with MaSp {MaSp} and UserId {UserId}.", maSp, userId);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<DanhGia>> GetByRatingAsync(float rating)
        {
            return await _context.DanhGias
                .AsNoTracking()
                .Include(d => d.SanPham)
                .Include(d => d.User)
                .Where(d => d.Rating == rating && d.TrangThai)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
