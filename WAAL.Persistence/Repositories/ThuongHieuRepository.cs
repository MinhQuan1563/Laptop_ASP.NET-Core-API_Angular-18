using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ThuongHieuRepository : IThuongHieuRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ThuongHieuRepository> _logger;

        public ThuongHieuRepository(ApplicationDbContext context, ILogger<ThuongHieuRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ThuongHieu thuongHieu)
        {
            try
            {
                await _context.ThuongHieus.AddAsync(thuongHieu);
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
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);
            if (thuongHieu != null)
            {
                thuongHieu.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ThuongHieu");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ThuongHieu with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ThuongHieu>> GetAllAsync(string? search)
        {
            IQueryable<ThuongHieu> query = _context.ThuongHieus
                .AsNoTracking().Where(q => q.TrangThai == true);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenThuongHieu.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<ThuongHieu> GetByIdAsync(Guid id)
        {
            return await _context.ThuongHieus.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ThuongHieu();
        }

        public async Task<bool> UpdateAsync(Guid id, ThuongHieu thuongHieu)
        {
            var affectedRows = await _context.ThuongHieus
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenThuongHieu, thuongHieu.TenThuongHieu));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ThuongHieu");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ThuongHieu with ID {Id}.", id);
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
