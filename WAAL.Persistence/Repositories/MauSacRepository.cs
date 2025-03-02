using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class MauSacRepository : IMauSacRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MauSacRepository> _logger;

        public MauSacRepository(ApplicationDbContext context, ILogger<MauSacRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(MauSac mauSac)
        {
            try
            {
                await _context.MauSacs.AddAsync(mauSac);
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
            var mauSac = await _context.MauSacs.FindAsync(id);
            if (mauSac != null)
            {
                mauSac.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("MauSac");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing MauSac with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<MauSac>> GetAllAsync(string? search)
        {
            IQueryable<MauSac> query = _context.MauSacs.AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenMau.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<MauSac> GetByIdAsync(Guid id)
        {
            return await _context.MauSacs.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new MauSac();
        }

        public async Task<bool> UpdateAsync(Guid id, MauSac mauSac)
        {
            var affectedRows = await _context.MauSacs
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenMau, mauSac.TenMau));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("MauSac");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing MauSac with ID {Id}.", id);
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
