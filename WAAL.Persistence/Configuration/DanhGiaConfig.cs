using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class DanhGiaConfig : IEntityTypeConfiguration<DanhGia>
    {
        public void Configure(EntityTypeBuilder<DanhGia> builder)
        {
            builder.HasKey(ct => new { ct.MaSp, ct.MaKh, ct.ThoiGianDanhGia });

            builder.HasOne(pc => pc.SanPham)
                .WithMany(p => p.DanhGias)
                .HasForeignKey(pc => pc.MaSp);

            builder.HasOne(pc => pc.KhachHang)
                .WithMany(c => c.DanhGias)
                .HasForeignKey(pc => pc.MaKh);
        }
    }
}
