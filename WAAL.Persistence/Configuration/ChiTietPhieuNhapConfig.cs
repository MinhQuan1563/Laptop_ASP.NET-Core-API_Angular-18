using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietPhieuNhapConfig : IEntityTypeConfiguration<ChiTietPhieuNhap>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuNhap> builder)
        {
            builder.HasKey(ct => new { ct.MaPn, ct.MaCtsp });

            builder.HasOne(pc => pc.PhieuNhap)
                .WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(pc => pc.MaPn);

            builder.HasOne(pc => pc.ChiTietSanPham)
                .WithMany(c => c.ChiTietPhieuNhaps)
                .HasForeignKey(pc => pc.MaCtsp);

            builder.Property(ct => ct.ThanhTien)
                .HasColumnType("decimal(18, 2)");

            builder.Property(ct => ct.GiaTien)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
