﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(ct => new { ct.MaCtsp, ct.UserId });

            builder.HasOne(pc => pc.ChiTietSanPham)
                .WithMany(p => p.GioHangs)
                .HasForeignKey(pc => pc.MaCtsp);

            builder.HasOne(pc => pc.User)
                .WithMany(c => c.GioHangs)
                .HasForeignKey(pc => pc.UserId);
        }
    }
}
