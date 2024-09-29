using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietQuyenConfig : IEntityTypeConfiguration<ChiTietQuyen>
    {
        public void Configure(EntityTypeBuilder<ChiTietQuyen> builder)
        {
            builder.HasKey(ct => new { ct.MaQuyen, ct.MaChucNang, ct.HanhDong });

            builder.HasOne(pc => pc.NhomQuyen)
                .WithMany(p => p.ChiTietQuyens)
                .HasForeignKey(pc => pc.MaQuyen);

            builder.HasOne(pc => pc.ChucNang)
                .WithMany(c => c.ChiTietQuyens)
                .HasForeignKey(pc => pc.MaChucNang);
        }
    }
}
