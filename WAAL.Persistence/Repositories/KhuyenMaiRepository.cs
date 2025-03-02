using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class KhuyenMaiRepository : IKhuyenMaiRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<KhuyenMaiRepository> _logger;

        public KhuyenMaiRepository(ApplicationDbContext context, ILogger<KhuyenMaiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(KhuyenMai khuyenMai)
        {
            try
            {
                await _context.KhuyenMais.AddAsync(khuyenMai);
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
            var khuyenMai = await _context.KhuyenMais.FindAsync(id);
            if (khuyenMai != null)
            {
                khuyenMai.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("KhuyenMai");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing KhuyenMai with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<KhuyenMai> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take)
        {
            IQueryable<KhuyenMai> query = _context.KhuyenMais.AsNoTracking().Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenKhuyenMai.Contains(search)
                                         || c.MucKhuyenMai.ToString().Contains(search)
                                         || c.DieuKien.Contains(search)
                                         || c.TinhTrang.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public Task<IEnumerable<KhuyenMai>> GetAllAsync(string? search)
        {
            IQueryable<KhuyenMai> result = _context.KhuyenMais.AsNoTracking().Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(c => c.TenKhuyenMai.Contains(search)
                                         || c.MucKhuyenMai.ToString().Contains(search)
                                         || c.DieuKien.Contains(search)
                                         || c.TinhTrang.Contains(search));
            }

            return Task.FromResult<IEnumerable<KhuyenMai>>(result);
        }

        public async Task<KhuyenMai> GetByIdAsync(Guid id)
        {
            return await _context.KhuyenMais.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new KhuyenMai();
        }

        public async Task<bool> UpdateAsync(Guid id, KhuyenMai khuyenMai)
        {
            var affectedRows = await _context.KhuyenMais
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenKhuyenMai, khuyenMai.TenKhuyenMai)
                    .SetProperty(p => p.MucKhuyenMai, khuyenMai.MucKhuyenMai)
                    .SetProperty(p => p.DieuKien, khuyenMai.DieuKien)
                    .SetProperty(p => p.TinhTrang, khuyenMai.TinhTrang)
                    .SetProperty(p => p.ThoiGianBatDau, khuyenMai.ThoiGianBatDau)
                    .SetProperty(p => p.ThoiGianKetThuc, khuyenMai.ThoiGianKetThuc));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("KhuyenMai");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing KhuyenMai with ID {Id}.", id);
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
