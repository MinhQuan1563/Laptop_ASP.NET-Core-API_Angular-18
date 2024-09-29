using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasOne(d => d.ThuongHieu)
                .WithMany(p => p.SanPhams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.TheLoai)
                .WithMany(p => p.SanPhams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.HeDieuHanh)
                .WithMany(p => p.SanPhams)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
