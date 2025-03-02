using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Persistence.Repositories;
using WAAL.Persistence;

namespace WAAL.Domain.Interfaces
{
    public class ChiTietSanPhamRepository : IChiTietSanPhamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChiTietSanPhamRepository> _logger;

        public ChiTietSanPhamRepository(ApplicationDbContext context, ILogger<ChiTietSanPhamRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChiTietSanPham chiTietSanPham)
        {
            try
            {
                _context.Attach(chiTietSanPham.SanPham);
                _context.Attach(chiTietSanPham.MauSac);
                _context.Attach(chiTietSanPham.ChipXuLy);
                _context.Attach(chiTietSanPham.CardDoHoa);

                await _context.ChiTietSanPhams.AddAsync(chiTietSanPham);
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
            var chiTietSanPham = await _context.ChiTietSanPhams.FindAsync(id);
            if (chiTietSanPham != null)
            {
                chiTietSanPham.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChiTietSanPham");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChiTietSanPham with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<ChiTietSanPham> Data, int TotalCount)> GetAllAsync(string? search, int skip, int take)
        {
            IQueryable<ChiTietSanPham> query = _context.ChiTietSanPhams
                .AsNoTracking()
                .Include(q => q.SanPham)
                .Include(q => q.MauSac)
                .Include(q => q.CardDoHoa)
                .Include(q => q.ChipXuLy)
                .Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Ram.Contains(search)
                                         || c.Rom.Contains(search)
                                         || c.GiaNhap.ToString().Contains(search)
                                         || c.ChietKhau.ToString().Contains(search)
                                         || c.GiaTien.ToString().Contains(search)
                                         || c.SoLuong.ToString().Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<(IEnumerable<ChiTietSanPham> Data, int TotalCount)> GetAllBySanPhamAsync(Guid maSp, string? search, int skip, int take)
        {
            IQueryable<ChiTietSanPham> query = _context.ChiTietSanPhams
                .AsNoTracking()
                .Include(q => q.SanPham)
                .Include(q => q.MauSac)
                .Include(q => q.CardDoHoa)
                .Include(q => q.ChipXuLy)
                .Where(q => q.TrangThai && q.SanPham.Id == maSp);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Ram.Contains(search)
                                         || c.Rom.Contains(search)
                                         || c.GiaNhap.ToString().Contains(search)
                                         || c.ChietKhau.ToString().Contains(search)
                                         || c.GiaTien.ToString().Contains(search)
                                         || c.SoLuong.ToString().Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<ChiTietSanPham> GetByIdAsync(Guid id)
        {
            return await _context.ChiTietSanPhams.AsNoTrackingWithIdentityResolution()
                .Include(q => q.SanPham)
                .Include(q => q.MauSac)
                .Include(q => q.CardDoHoa)
                .Include(q => q.ChipXuLy)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ChiTietSanPham();
        }

        public async Task<bool> UpdateAsync(Guid id, ChiTietSanPham chiTietSanPham)
        {
            var affectedRows = await _context.ChiTietSanPhams
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.Ram, chiTietSanPham.Ram)
                    .SetProperty(p => p.Rom, chiTietSanPham.Rom)
                    .SetProperty(p => p.GiaNhap, chiTietSanPham.GiaNhap)
                    .SetProperty(p => p.GiaTien, chiTietSanPham.GiaTien)
                    .SetProperty(p => p.ChietKhau, chiTietSanPham.ChietKhau)
                    .SetProperty(p => p.MauSac, chiTietSanPham.MauSac)
                    .SetProperty(p => p.CardDoHoa, chiTietSanPham.CardDoHoa)
                    .SetProperty(p => p.ChipXuLy, chiTietSanPham.ChipXuLy));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ChiTietSanPham");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChiTietSanPham with ID {Id}.", id);
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
