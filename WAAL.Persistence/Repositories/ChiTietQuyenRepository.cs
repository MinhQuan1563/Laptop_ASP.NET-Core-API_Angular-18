﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ChiTietQuyenRepository : IChiTietQuyenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChiTietQuyenRepository> _logger;

        public ChiTietQuyenRepository(ApplicationDbContext context, ILogger<ChiTietQuyenRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(ChiTietQuyen chiTietQuyen)
        {
            try
            {
                await _context.ChiTietQuyens.AddAsync(chiTietQuyen);
                return await SaveAsync();
            }
            catch (Exception ex)
            {   
                _logger.LogError(ex, "An error occurred while creating item.");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid roleId, Guid maChucNang, string hanhDong)
        {
            var chiTietQuyen = await FindAsync(roleId, maChucNang, hanhDong);
            if (chiTietQuyen != null)
            {
                _context.ChiTietQuyens.Remove(chiTietQuyen);
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("ChiTietQuyen");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing ChiTietQuyen with ID");
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<ChiTietQuyen>> GetAllAsync()
        {
            IQueryable<ChiTietQuyen> query = _context.ChiTietQuyens
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<ChiTietQuyen?> FindAsync(Guid roleId, Guid maChucNang, string hanhDong)
        {
            return await _context.ChiTietQuyens
                .FirstOrDefaultAsync(ctq => ctq.Role.Id == roleId &&
                                            ctq.ChucNang.Id == maChucNang &&
                                            ctq.HanhDong == hanhDong);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync(ChiTietQuyen chiTietQuyen)
        {
            var existingChiTietQuyen = await _context.ChiTietQuyens
                .FirstOrDefaultAsync(ctq => ctq.Role.Id == chiTietQuyen.RoleId 
                                            && ctq.ChucNang.Id == chiTietQuyen.MaChucNang
                                            && ctq.HanhDong == chiTietQuyen.HanhDong);

            if (existingChiTietQuyen == null)
            {
                var notFoundException = new EntityNotFoundException("ChiTietQuyen");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing ChiTietQuyen");
                throw notFoundException;
            }

            return await SaveAsync();
        }

        public async Task<IEnumerable<string>> GetListHanhDongAsync(ChiTietQuyen chiTietQuyen)
        {
            var result = await _context.ChiTietQuyens
                .AsNoTracking()
                .Where(x => x.RoleId == chiTietQuyen.RoleId && x.MaChucNang == chiTietQuyen.MaChucNang)
                .Select(x => x.HanhDong)
                .ToListAsync();

            if (result == null)
            {
                return new List<string>();
            }
            return result;
        }

        public async Task<bool> CheckQuyenAsync(ChiTietQuyen chiTietQuyen)
        {
            var result = await FindAsync(chiTietQuyen.RoleId, chiTietQuyen.MaChucNang, chiTietQuyen.HanhDong);

            return result != null;
        }

        public async Task<IEnumerable<ChiTietQuyen>> GetAllChiTietQuyenByRoleAsync(Guid roleId)
        {
            return await _context.ChiTietQuyens
                .AsNoTracking()
                .Where(ctq => ctq.RoleId == roleId)
                .ToListAsync();
        }
    }
}
