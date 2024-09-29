using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ImeiConfig : IEntityTypeConfiguration<Imei>
    {
        public void Configure(EntityTypeBuilder<Imei> builder)
        {
            builder.HasOne(d => d.ChiTietSanPham)
                .WithMany(p => p.Imeis)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
