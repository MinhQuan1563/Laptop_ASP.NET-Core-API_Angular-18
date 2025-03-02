using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ChipXuLyRepository : IChipXuLyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChipXuLyRepository> _logger;

        public ChipXuLyRepository(ApplicationDbContext context, ILogger<ChipXuLyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChipXuLy chipXuLy)
        {
            try
            {
                await _context.ChipXuLys.AddAsync(chipXuLy);
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
            var chipXuLy = await _context.ChipXuLys.FindAsync(id);
            if (chipXuLy != null)
            {
                chipXuLy.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChipXuLy");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChipXuLy with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ChipXuLy>> GetAllAsync(string? search)
        {
            IQueryable<ChipXuLy> query = _context.ChipXuLys.AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenChip.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<ChipXuLy> GetByIdAsync(Guid id)
        {
            return await _context.ChipXuLys.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ChipXuLy();
        }

        public async Task<bool> UpdateAsync(Guid id, ChipXuLy chipXuLy)
        {
            var affectedRows = await _context.ChipXuLys
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenChip, chipXuLy.TenChip));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ChipXuLy");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChipXuLy with ID {Id}.", id);
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
