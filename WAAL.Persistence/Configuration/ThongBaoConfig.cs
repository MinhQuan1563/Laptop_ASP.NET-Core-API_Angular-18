using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;
using System.Reflection.Emit;

namespace WAAL.Persistence.Configuration
{
    public class ThongBaoConfig : IEntityTypeConfiguration<ThongBao>
    {
        public void Configure(EntityTypeBuilder<ThongBao> builder)
        {
            builder.HasOne(t => t.SanPham)
                .WithMany()
                .HasForeignKey(t => t.SanPhamId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.HoaDon)
                .WithMany()
                .HasForeignKey(t => t.HoaDonId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.PhieuNhap)
                .WithMany()
                .HasForeignKey(t => t.PhieuNhapId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.PhieuDoiTra)
                .WithMany()
                .HasForeignKey(t => t.PhieuDoiTraId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.PhieuBaoHanh)
                .WithMany()
                .HasForeignKey(t => t.PhieuBaoHanhId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.NhaCungCap)
                .WithMany()
                .HasForeignKey(t => t.NhaCungCapId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.KhuyenMai)
                .WithMany()
                .HasForeignKey(t => t.KhuyenMaiId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
