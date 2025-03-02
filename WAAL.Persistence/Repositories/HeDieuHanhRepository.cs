using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Persistence;

namespace WAAL.Domain.Interfaces
{
    public class HeDieuHanhRepository : IHeDieuHanhRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HeDieuHanhRepository> _logger;

        public HeDieuHanhRepository(ApplicationDbContext context, ILogger<HeDieuHanhRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(HeDieuHanh heDieuHanh)
        {
            try
            {
                await _context.HeDieuHanhs.AddAsync(heDieuHanh);
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
            var heDieuHanh = await _context.HeDieuHanhs.FindAsync(id);
            if (heDieuHanh != null)
            {
                heDieuHanh.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("HeDieuHanh");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing HeDieuHanh with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<HeDieuHanh>> GetAllAsync(string? search)
        {
            IQueryable<HeDieuHanh> query = _context.HeDieuHanhs
                .AsNoTracking().Where(q => q.TrangThai == true);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenHdh.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<HeDieuHanh> GetByIdAsync(Guid id)
        {
            return await _context.HeDieuHanhs.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new HeDieuHanh();
        }

        public async Task<bool> UpdateAsync(Guid id, HeDieuHanh heDieuHanh)
        {
            var affectedRows = await _context.HeDieuHanhs
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenHdh, heDieuHanh.TenHdh));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("HeDieuHanh");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing HeDieuHanh with ID {Id}.", id);
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
