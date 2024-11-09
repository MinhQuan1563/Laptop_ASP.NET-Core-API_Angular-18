using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ThongBaoConfig : IEntityTypeConfiguration<ThongBao>
    {
        public void Configure(EntityTypeBuilder<ThongBao> builder)
        {
            builder.HasKey(ct => new { ct.MaSp, ct.UserId, ct.MaHd, ct.MaPn,
                                        ct.MaPbh, ct.MaPdt, ct.MaNcc, ct.MaKm});

            builder.HasOne(pc => pc.SanPham)
                .WithMany(p => p.ThongBaos)
                .HasForeignKey(pc => pc.MaSp);

            builder.HasOne(pc => pc.User)
                .WithMany(c => c.ThongBaos)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

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

        }
    }
}
