using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietQuyenConfig : IEntityTypeConfiguration<ChiTietQuyen>
    {
        public void Configure(EntityTypeBuilder<ChiTietQuyen> builder)
        {
            builder.HasKey(ct => new { ct.MaChucNang, ct.RoleId, ct.HanhDong });

            builder.HasOne(pc => pc.ChucNang)
                .WithMany(p => p.ChiTietQuyens)
                .HasForeignKey(pc => pc.MaChucNang);

            builder.HasOne(pc => pc.Role)
                .WithMany(c => c.ChiTietQuyens)
                .HasForeignKey(pc => pc.RoleId);
        }
    }
}
