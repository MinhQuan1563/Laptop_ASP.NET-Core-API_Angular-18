using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class PhieuDoiTraConfig : IEntityTypeConfiguration<PhieuDoiTra>
    {
        public void Configure(EntityTypeBuilder<PhieuDoiTra> builder)
        {
            builder.Property(ct => ct.TongTienTra)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.NhanVien)
                .WithMany(p => p.PhieuDoiTras)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.HoaDon)
                .WithMany(p => p.PhieuDoiTras)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
