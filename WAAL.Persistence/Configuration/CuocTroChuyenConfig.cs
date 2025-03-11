using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;
using System.Reflection.Emit;

namespace WAAL.Persistence.Configuration
{
    public class CuocTroChuyenConfig : IEntityTypeConfiguration<CuocTroChuyen>
    {
        public void Configure(EntityTypeBuilder<CuocTroChuyen> builder)
        {
            builder.HasOne(c => c.KhachHang)
                .WithMany()
                .HasForeignKey(c => c.KhachHangId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.NhanVienHoTro)
                .WithMany()
                .HasForeignKey(c => c.NhanVienHoTroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
