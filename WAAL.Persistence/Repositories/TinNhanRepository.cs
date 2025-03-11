using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class TinNhanRepository : ITinNhanRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TinNhanRepository> _logger;

        public TinNhanRepository(ApplicationDbContext context, ILogger<TinNhanRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(TinNhan tinNhan)
        {
            try
            {
                await _context.TinNhans.AddAsync(tinNhan);
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
            var tinNhan = await _context.TinNhans.FindAsync(id);
            if (tinNhan != null)
            {
                _context.TinNhans.Remove(tinNhan);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("TinNhan");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing TinNhan with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<TinNhan>> GetAllAsync()
        {
            return await _context.TinNhans.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TinNhan>> GetByConversationIdAsync(Guid cuocTroChuyenId)
        {
            return await _context.TinNhans.Where(x => x.CuocTroChuyenId == cuocTroChuyenId).ToListAsync();
        }

        public async Task<TinNhan> GetByIdAsync(Guid id)
        {
            return await _context.TinNhans.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new TinNhan();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
