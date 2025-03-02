using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietKhuyenMaiConfig : IEntityTypeConfiguration<ChiTietKhuyenMai>
    {
        public void Configure(EntityTypeBuilder<ChiTietKhuyenMai> builder)
        {
            builder.HasKey(ct => new { ct.MaHd, ct.MaKm });

            builder.HasOne(pc => pc.HoaDon)
                .WithMany(p => p.ChiTietKhuyenMais)
                .HasForeignKey(pc => pc.MaHd);

            builder.HasOne(pc => pc.KhuyenMai)
                .WithMany(c => c.ChiTietKhuyenMais)
                .HasForeignKey(pc => pc.MaKm);

            builder.Property(ct => ct.GiaTienGIam)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
