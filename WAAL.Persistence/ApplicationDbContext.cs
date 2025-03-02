using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;
using WAAL.Persistence.Configuration;

namespace WAAL.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CongKetNoi> CongKetNois { get; set; }
        public DbSet<ChipXuLy> ChipXuLys { get; set; }
        public DbSet<CardDoHoa> CardDoHoas { get; set; }
        public DbSet<HeDieuHanh> HeDieuHanhs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<Imei> Imeis { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public DbSet<PhieuDoiTra> PhieuDoiTras { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<ThongTinNhanHang> ThongTinNhanHangs { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<ChiTietCongKetNoi> ChiTietCongKetNois { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }
        public DbSet<ChiTietPhieuDoiTra> ChiTietPhieuDoiTras { get; set; }
        public DbSet<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public DbSet<ChucNang> ChucNangs { get; set; }
        public DbSet<ChiTietQuyen> ChiTietQuyens { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Lược bỏ chữ AspNet mặc định
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.ApplyConfiguration(new ChiTietCongKetNoiConfig());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonConfig());
            modelBuilder.ApplyConfiguration(new ChiTietPhieuNhapConfig());
            modelBuilder.ApplyConfiguration(new GioHangConfig());
            modelBuilder.ApplyConfiguration(new DanhGiaConfig());
            modelBuilder.ApplyConfiguration(new ChiTietPhieuDoiTraConfig());
            modelBuilder.ApplyConfiguration(new ChiTietPhieuBaoHanhConfig());
            modelBuilder.ApplyConfiguration(new ChiTietKhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new ThongBaoConfig());
            modelBuilder.ApplyConfiguration(new HoaDonConfig());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfig());
            modelBuilder.ApplyConfiguration(new PhieuDoiTraConfig());
            modelBuilder.ApplyConfiguration(new ImeiConfig());
            modelBuilder.ApplyConfiguration(new SanPhamConfig());
            modelBuilder.ApplyConfiguration(new ThongTinNhanHangConfig());
            modelBuilder.ApplyConfiguration(new PhieuNhapConfig());
            modelBuilder.ApplyConfiguration(new PhieuBaoHanhConfig());
            modelBuilder.ApplyConfiguration(new ChiTietSanPhamConfig());
            modelBuilder.ApplyConfiguration(new ChiTietQuyenConfig());

        }
    }
}
