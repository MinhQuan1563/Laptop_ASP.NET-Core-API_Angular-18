using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class PhieuBaoHanhConfig : IEntityTypeConfiguration<PhieuBaoHanh>
    {
        public void Configure(EntityTypeBuilder<PhieuBaoHanh> builder)
        {
            builder.HasOne(d => d.KhachHang)
                .WithMany(p => p.PhieuBaoHanhs)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.NhanVien)
                .WithMany(p => p.PhieuBaoHanhs)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.HoaDon)
                .WithMany(p => p.PhieuBaoHanhs)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
