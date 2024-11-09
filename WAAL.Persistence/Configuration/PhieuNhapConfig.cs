using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class PhieuNhapConfig : IEntityTypeConfiguration<PhieuNhap>
    {
        public void Configure(EntityTypeBuilder<PhieuNhap> builder)
        {
            builder.Property(ct => ct.TongTien)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.User)
                .WithMany(p => p.PhieuNhaps)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.NhaCungCap)
                .WithMany(p => p.PhieuNhaps)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
