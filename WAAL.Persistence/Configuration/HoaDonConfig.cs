    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.Property(ct => ct.TongTien)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.ThongTinNhanHang)
                .WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.User)
                .WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
