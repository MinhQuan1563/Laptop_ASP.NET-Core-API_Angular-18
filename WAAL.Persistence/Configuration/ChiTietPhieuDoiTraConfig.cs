using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietPhieuDoiTraConfig : IEntityTypeConfiguration<ChiTietPhieuDoiTra>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuDoiTra> builder)
        {
            builder.HasKey(ct => new { ct.MaPdt, ct.MaImei });

            builder.HasOne(pc => pc.PhieuDoiTra)
                .WithMany(p => p.ChiTietPhieuDoiTras)
                .HasForeignKey(pc => pc.MaPdt);

            builder.HasOne(pc => pc.Imei)
                .WithMany(c => c.ChiTietPhieuDoiTras)
                .HasForeignKey(pc => pc.MaImei);

            builder.Property(ct => ct.GiaSp)
                .HasColumnType("decimal(18, 2)");

            builder.Property(ct => ct.ThanhTien)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
