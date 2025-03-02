using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class TheLoaiRepository : ITheLoaiRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TheLoaiRepository> _logger;

        public TheLoaiRepository(ApplicationDbContext context, ILogger<TheLoaiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(TheLoai theLoai)
        {
            try
            {
                await _context.TheLoais.AddAsync(theLoai);
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
            var theLoai = await _context.TheLoais.FindAsync(id);
            if (theLoai != null)
            {
                theLoai.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("TheLoai");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing TheLoai with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<TheLoai>> GetAllAsync(string? search)
        {
            IQueryable<TheLoai> query = _context.TheLoais
                .AsNoTracking().Where(q => q.TrangThai == true);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenLoai.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<TheLoai> GetByIdAsync(Guid id)
        {
            return await _context.TheLoais.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new TheLoai();
        }

        public async Task<bool> UpdateAsync(Guid id, TheLoai theLoai)
        {
            var affectedRows = await _context.TheLoais
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenLoai, theLoai.TenLoai));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("TheLoai");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing TheLoai with ID {Id}.", id);
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
