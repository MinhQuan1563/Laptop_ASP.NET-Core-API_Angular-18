using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietHoaDonConfig : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.HasKey(ct => new { ct.MaHd, ct.MaImei });

            builder.HasOne(pc => pc.HoaDon)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(pc => pc.MaHd);

            builder.HasOne(pc => pc.Imei)
                    .WithMany(c => c.ChiTietHoaDons)
                    .HasForeignKey(pc => pc.MaImei);

            builder.Property(ct => ct.GiaSp)
                .HasColumnType("decimal(18, 2)");

        }
    }
}
