using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SanPhamRepository> _logger;

        public SanPhamRepository(ApplicationDbContext context, ILogger<SanPhamRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams
                .AsNoTracking()
                .Include(s => s.ThuongHieu)
                .Include(s => s.TheLoai)
                .Include(s => s.HeDieuHanh)
                .Where(q => q.TrangThai)
                .ToListAsync();
        }

        public async Task<bool> CreateAsync(SanPham sanPham)
        {
            try
            {
                _context.Attach(sanPham.ThuongHieu);
                _context.Attach(sanPham.TheLoai);
                _context.Attach(sanPham.HeDieuHanh);

                await _context.SanPhams.AddAsync(sanPham);
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
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                sanPham.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("SanPham");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing SanPham with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<SanPham> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take)
        {
            IQueryable<SanPham> query = _context.SanPhams
                .AsNoTracking()
                .Include(s => s.ThuongHieu)
                .Include(s => s.TheLoai)
                .Include(s => s.HeDieuHanh)
                .Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenSp.Contains(search)
                                         || c.KichCoManHinh.Contains(search)
                                         || c.DoPhanGiai.Contains(search)
                                         || c.Pin.Contains(search)
                                         || c.BanPhim.Contains(search)
                                         || c.TrongLuong.ToString().Contains(search)
                                         || c.ChatLieu.Contains(search)
                                         || c.XuatXu.Contains(search)
                                         || c.SoLuongTon.ToString().Contains(search)
                                         || c.ThuongHieu.TenThuongHieu.Contains(search)
                                         || c.TheLoai.TenLoai.Contains(search)
                                         || c.HeDieuHanh.TenHdh.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<(IEnumerable<SanPham> Data, int TotalCount)> GetAllInCTSPAsync(string? search, int skip, int take)
        {
            IQueryable<SanPham> query = _context.SanPhams
                .AsNoTracking()
                .Include(s => s.ThuongHieu)
                .Include(s => s.TheLoai)
                .Include(s => s.HeDieuHanh)
                .Where(q => q.TrangThai && q.ChiTietSanPhams.Count() > 0);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenSp.Contains(search)
                                         || c.KichCoManHinh.Contains(search)
                                         || c.DoPhanGiai.Contains(search)
                                         || c.Pin.Contains(search)
                                         || c.BanPhim.Contains(search)
                                         || c.TrongLuong.ToString().Contains(search)
                                         || c.ChatLieu.Contains(search)
                                         || c.XuatXu.Contains(search)
                                         || c.SoLuongTon.ToString().Contains(search)
                                         || c.ThuongHieu.TenThuongHieu.Contains(search)
                                         || c.TheLoai.TenLoai.Contains(search)
                                         || c.HeDieuHanh.TenHdh.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<SanPham> GetByIdAsync(Guid id)
        {
            return await _context.SanPhams.AsNoTrackingWithIdentityResolution()
                .Include(s => s.ThuongHieu)
                .Include(s => s.TheLoai)
                .Include(s => s.HeDieuHanh)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new SanPham();
        }

        public async Task<SanPham> GetSanPhamByMaCtsp(Guid maCtsp)
        {
            return await _context.SanPhams.AsNoTrackingWithIdentityResolution()
                .Include(s => s.ThuongHieu)
                .Include(s => s.TheLoai)
                .Include(s => s.HeDieuHanh)
                .FirstOrDefaultAsync(e => e.ChiTietSanPhams.Any(c => c.Id == maCtsp)) ?? new SanPham();
        }

        public async Task<bool> UpdateAsync(Guid id, SanPham sanPham)
        {
            var affectedRows = await _context.SanPhams
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenSp, sanPham.TenSp)
                    .SetProperty(p => p.HinhAnh, sanPham.HinhAnh)
                    .SetProperty(p => p.KichCoManHinh, sanPham.KichCoManHinh)
                    .SetProperty(p => p.DoPhanGiai, sanPham.DoPhanGiai)
                    .SetProperty(p => p.Pin, sanPham.Pin)
                    .SetProperty(p => p.BanPhim, sanPham.BanPhim)
                    .SetProperty(p => p.TrongLuong, sanPham.TrongLuong)
                    .SetProperty(p => p.ChatLieu, sanPham.ChatLieu)
                    .SetProperty(p => p.XuatXu, sanPham.XuatXu));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("SanPham");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing SanPham with ID {Id}.", id);
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
