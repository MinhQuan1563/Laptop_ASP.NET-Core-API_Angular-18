using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ThongTinNhanHangConfig : IEntityTypeConfiguration<ThongTinNhanHang>
    {
        public void Configure(EntityTypeBuilder<ThongTinNhanHang> builder)
        {
            builder.HasOne(d => d.User)
                .WithMany(p => p.ThongTinNhanHangs)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
