using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ChucNangRepository : IChucNangRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChucNangRepository> _logger;

        public ChucNangRepository(ApplicationDbContext context, ILogger<ChucNangRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChucNang chucNang)
        {
            try
            {
                await _context.ChucNangs.AddAsync(chucNang);
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
            var chucNang = await _context.ChucNangs.FindAsync(id);
            if (chucNang != null)
            {
                chucNang.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChucNang");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChucNang with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ChucNang>> GetAllAsync()
        {
            IQueryable<ChucNang> query = _context.ChucNangs
                .AsNoTracking()
                .Where(c => c.TrangThai == true);

            return await query.ToListAsync();
        }

        public async Task<ChucNang> GetByIdAsync(Guid id)
        {
            return await _context.ChucNangs.AsNoTrackingWithIdentityResolution()
                .Where(c=> c.TrangThai == true)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ChucNang();
        }

        public async Task<bool> UpdateAsync(Guid id, ChucNang chucNang)
        {
            var affectedRows = await _context.ChucNangs
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenChucNang, chucNang.TenChucNang));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ChucNang");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChucNang with ID {Id}.", id);
                throw notFoundException;
            }

            return affectedRows > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<ChucNang> GetNameAsync(string tenChucNang)
        {
            var result = await _context.ChucNangs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TenChucNang == tenChucNang && x.TrangThai == true);

            return result;
        }
    }
}
