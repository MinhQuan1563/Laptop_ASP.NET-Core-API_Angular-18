using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ThongBaoConfig : IEntityTypeConfiguration<ThongBao>
    {
        public void Configure(EntityTypeBuilder<ThongBao> builder)
        {
            builder.HasKey(ct => new { ct.MaSp, ct.MaKh, ct.MaNv, ct.MaTk, ct.MaHd, ct.MaPn,
                                        ct.MaPbh, ct.MaPdt, ct.MaNcc, ct.MaKm, ct.MaNq, ct.MaCn});

            builder.HasOne(pc => pc.SanPham)
                .WithMany(p => p.ThongBaos)
                .HasForeignKey(pc => pc.MaSp);

            builder.HasOne(pc => pc.KhachHang)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaKh);

            builder.HasOne(pc => pc.NhanVien)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaNv);

            builder.HasOne(pc => pc.TaiKhoan)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaTk);

            builder.HasOne(pc => pc.HoaDon)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaHd);

            builder.HasOne(pc => pc.PhieuNhap)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaPn);

            builder.HasOne(pc => pc.PhieuBaoHanh)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaPbh);

            builder.HasOne(pc => pc.PhieuDoiTra)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaPdt);

            builder.HasOne(pc => pc.NhaCungCap)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaNcc);

            builder.HasOne(pc => pc.KhuyenMai)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaKm);

            builder.HasOne(pc => pc.NhomQuyen)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaNq);

            builder.HasOne(pc => pc.ChucNang)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.MaCn);
        }
    }
}
