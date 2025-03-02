using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(AppUser user)
        {
            try
            {
                await _context.Users.AddAsync(user);
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
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("User");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing User with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<(IEnumerable<AppUser> Data, int TotalCount)> GetAllPaginationAsync(string? search, int skip, int take)
        {
            IQueryable<AppUser> query = _context.Users.AsNoTracking().Where(q => q.TrangThai);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.HoTen.Contains(search)
                                         || c.DiaChi.Contains(search)
                                         || c.Tuoi.ToString().Contains(search)
                                         || c.PhoneNumber.Contains(search)
                                         || c.Email.Contains(search));
            }

            int totalCount = await query.CountAsync();

            var result = await query.Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return (result, totalCount);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().Where(q => q.TrangThai).ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new AppUser();
        }

        public async Task<bool> UpdateAsync(Guid id, AppUser user)
        {
            var affectedRows = await _context.Users
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.HoTen, user.HoTen)
                    .SetProperty(p => p.DiaChi, user.DiaChi)
                    .SetProperty(p => p.Tuoi.ToString(), user.Tuoi.ToString()));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("User");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing User with ID {Id}.", id);
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
