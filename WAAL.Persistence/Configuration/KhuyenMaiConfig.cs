using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class KhuyenMaiConfig : IEntityTypeConfiguration<KhuyenMai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMai> builder)
        {
            builder.Property(ct => ct.MucKhuyenMai)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
