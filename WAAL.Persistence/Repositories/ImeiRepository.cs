using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WAAL.Application.Exceptions;
using WAAL.Domain.Entities;
using WAAL.Domain.Interfaces;

namespace WAAL.Persistence.Repositories
{
    public class ImeiRepository : IImeiRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ImeiRepository> _logger;

        public ImeiRepository(ApplicationDbContext context, ILogger<ImeiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateAsync(Imei imei)
        {
            try
            {
                _context.Attach(imei.ChiTietSanPham);

                await _context.Imeis.AddAsync(imei);
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
            var imei = await _context.Imeis.FindAsync(id);
            if (imei != null)
            {
                imei.TrangThai = false;
                return await SaveAsync();
            }
            else
            {
                var notFoundException = new EntityNotFoundException("Imei");
                _logger.LogWarning(notFoundException, "Attempted to delete a non-existing Imei with ID {Id}.", id);
                throw notFoundException;
            }
        }

        public async Task<IEnumerable<Imei>> GetAllAsync()
        {
            return await _context.Imeis
                    .AsNoTracking()
                    .Include(c => c.ChiTietSanPham)
                    .Where(q => q.TrangThai)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Imei>> GetAllByMaCTSPAsync(Guid maCtsp, int soLuong)
        {
            return await _context.Imeis
                    .AsNoTracking()
                    .Include(c => c.ChiTietSanPham)
                    .Where(q => q.TrangThai && q.ChiTietSanPham.Id == maCtsp && q.TinhTrang == "Chưa bán")
                    .Take(soLuong)
                    .ToListAsync();
        }

        public async Task<Imei> GetByIdAsync(Guid id)
        {
            return await _context.Imeis.AsNoTrackingWithIdentityResolution()
                .Include(c => c.ChiTietSanPham)
                .FirstOrDefaultAsync(e => e.Id == id) ?? new Imei();
        }

        public async Task<Imei> GetByMaCtspAsync(Guid maCtsp)
        {
            return await _context.Imeis.AsNoTrackingWithIdentityResolution()
                .Include(c => c.ChiTietSanPham)
                .FirstOrDefaultAsync(e => e.ChiTietSanPham.Id == maCtsp) ?? new Imei();
        }

        public async Task<bool> UpdateAsync(Guid id, Imei imei)
        {
            var existingImei = await _context.Imeis
                .Include(e => e.ChiTietSanPham)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (existingImei == null)
            {
                var notFoundException = new EntityNotFoundException("Imei");
                _logger.LogWarning(notFoundException, "Attempted to update a non-existing Imei with ID {Id}.", id);
                throw notFoundException;
            }

            existingImei.TinhTrang = imei.TinhTrang;

            if (existingImei.ChiTietSanPham.Id != imei.ChiTietSanPham.Id)
            {
                var chitietsanpham = await _context.ChiTietSanPhams
                    .FirstOrDefaultAsync(c => c.Id == imei.ChiTietSanPham.Id);

                if (chitietsanpham != null)
                {
                    existingImei.ChiTietSanPham = chitietsanpham;
                }
            }

            return await SaveAsync();
        }


        //public async Task<bool> UpdateTinhTrangAsync(int soLuongBan, Guid maCtsp)
        //{
        //    List<Imei> imeiList = (await GetAllByMaCTSPAsync(maCtsp))
        //        .Where(i => i.TinhTrang == "Chưa bán")
        //        .ToList();

        //    if(imeiList.Count < soLuongBan)
        //    {
        //        throw new InvalidOperationException("Không đủ số lượng sản phẩm để bán.");
        //    }

        //    Random random = new Random();
        //    List<Imei> imeiRandom = imeiList.OrderBy(i => random.Next()).Take(soLuongBan).ToList();

        //    foreach(Imei imei in imeiRandom)
        //    {
        //        imei.TinhTrang = "Đã bán";
        //    }

        //    _context.Imeis.UpdateRange(imeiRandom);

        //    return await SaveAsync();
        //}

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
