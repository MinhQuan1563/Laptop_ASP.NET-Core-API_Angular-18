using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class CardDoHoaRepository : ICardDoHoaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CardDoHoaRepository> _logger;

        public CardDoHoaRepository(ApplicationDbContext context, ILogger<CardDoHoaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(CardDoHoa cardDoHoa)
        {
            try
            {
                await _context.AddAsync(cardDoHoa);
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
            var cardDoHoa = await _context.CardDoHoas.FindAsync(id);
            if(cardDoHoa != null)
            {
                cardDoHoa.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("CardDoHoa");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing CardDoHoa with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<CardDoHoa>> GetAllAsync(string? search)
        {
            IQueryable<CardDoHoa> query = _context.CardDoHoas.AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.TenCard.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<CardDoHoa> GetByIdAsync(Guid id)
        {
            return await _context.CardDoHoas.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(e => e.Id == id) ?? new CardDoHoa();
        }

        public async Task<bool> UpdateAsync(Guid id, CardDoHoa cardDoHoa)
        {
            var affectedRows = await _context.CardDoHoas
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.TenCard, cardDoHoa.TenCard));

            if (affectedRows == 0)
            {
                var notFoundException = new EntityNotFoundException("CardDoHoa");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing CardDoHoa with ID {Id}.", id);
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
