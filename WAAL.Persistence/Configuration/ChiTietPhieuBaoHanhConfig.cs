using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietPhieuBaoHanhConfig : IEntityTypeConfiguration<ChiTietPhieuBaoHanh>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuBaoHanh> builder)
        {
            builder.HasKey(ct => new { ct.MaPbh, ct.MaImei });

            builder.HasOne(pc => pc.PhieuBaoHanh)
                .WithMany(p => p.ChiTietPhieuBaoHanhs)
                .HasForeignKey(pc => pc.MaPbh);

            builder.HasOne(pc => pc.Imei)
                .WithMany(c => c.ChiTietPhieuBaoHanhs)
                .HasForeignKey(pc => pc.MaImei);
        }
    }
}
