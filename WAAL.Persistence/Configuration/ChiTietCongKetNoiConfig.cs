using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietCongKetNoiConfig : IEntityTypeConfiguration<ChiTietCongKetNoi>
    {
        public void Configure(EntityTypeBuilder<ChiTietCongKetNoi> builder)
        {
            builder.HasKey(ct => new { ct.MaCtsp, ct.MaCong });

            builder.HasOne(pc => pc.ChiTietSanPham)
            .WithMany(p => p.ChiTietCongKetNois)
            .HasForeignKey(pc => pc.MaCtsp);

            builder.HasOne(pc => pc.CongKetNoi)
                .WithMany(c => c.ChiTietCongKetNois)
                .HasForeignKey(pc => pc.MaCong);
        }
    }
}
