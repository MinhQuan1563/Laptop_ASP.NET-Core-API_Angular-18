using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.HasOne(d => d.NhomQuyen)
                .WithMany(p => p.TaiKhoans)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
