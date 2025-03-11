using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ThongBaoRepository : IThongBaoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ThongBaoRepository> _logger;

        public ThongBaoRepository(ApplicationDbContext context, ILogger<ThongBaoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ThongBao>> GetAllAsync()
        {
            return await _context.ThongBaos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ThongBao>> GetAllByUserAsync(Guid userId)
        {
            return await _context.ThongBaos
                .AsNoTracking()
                .Where(x => x.User.Id == userId)
                .ToListAsync();
        }

        public async Task<bool> CreateAsync(ThongBao thongBao)
        {
            try
            {
                await _context.ThongBaos.AddAsync(thongBao);
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
            var thongBao = await _context.ThongBaos.FindAsync(id);
            if (thongBao != null)
            {
                thongBao.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ThongBao");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ThongBao with ID {Id}.", id);
                throw notFoundException;
            }
        }

        
        public async Task<ThongBao> GetByIdAsync(Guid id)
        {
            return await _context.ThongBaos.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new ThongBao();
        }

        public async Task<bool> UpdateAsync(Guid id, ThongBao thongBao)
        {
            var affectedRows = await _context.ThongBaos
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TieuDe, thongBao.TieuDe)
                    .SetProperty(p => p.NoiDung, thongBao.NoiDung)
                    .SetProperty(p => p.NgayDang, thongBao.NgayDang));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("ThongBao");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ThongBao with ID {Id}.", id);
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
