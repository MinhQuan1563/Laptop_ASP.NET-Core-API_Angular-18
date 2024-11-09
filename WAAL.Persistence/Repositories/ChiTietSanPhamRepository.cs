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
                await _context.AddAsync(chiTietSanPham);
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

        public async Task<IEnumerable<ChiTietSanPham>> GetAllAsync(string? search)
        {
            IQueryable<ChiTietSanPham> query = _context.ChiTietSanPhams.AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => (c.GiaTien).ToString().Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<ChiTietSanPham> GetByIdAsync(Guid id)
        {
            return await _context.ChiTietSanPhams.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ChiTietSanPham();
        }

        public async Task<bool> UpdateAsync(Guid id, ChiTietSanPham chiTietSanPham)
        {
            var affectedRows = await _context.ChiTietSanPhams
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.GiaTien, chiTietSanPham.GiaTien));

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
