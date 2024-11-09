using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NhaCungCapRepository> _logger;

        public NhaCungCapRepository(ApplicationDbContext context, ILogger<NhaCungCapRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(NhaCungCap nhaCungCap)
        {
            try
            {
                await _context.AddAsync(nhaCungCap);
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
            var nhaCungCap = await _context.NhaCungCaps.FindAsync(id);
            if (nhaCungCap != null)
            {
                nhaCungCap.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("NhaCungCap");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing NhaCungCap with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<NhaCungCap> Data, int TotalCount)> GetAllAsync(string? search, int skip, int take)
        {
            IQueryable<NhaCungCap> query = _context.NhaCungCaps.AsNoTracking().Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenNcc.Contains(search)
                                         || c.DiaChi.Contains(search)
                                         || c.SoDienThoai.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<NhaCungCap> GetByIdAsync(Guid id)
        {
            return await _context.NhaCungCaps.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new NhaCungCap();
        }

        public async Task<bool> UpdateAsync(Guid id, NhaCungCap nhaCungCap)
        {
            var affectedRows = await _context.NhaCungCaps
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenNcc, nhaCungCap.TenNcc)
                    .SetProperty(p => p.DiaChi, nhaCungCap.DiaChi)
                    .SetProperty(p => p.SoDienThoai, nhaCungCap.SoDienThoai));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("NhaCungCap");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing NhaCungCap with ID {Id}.", id);
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
