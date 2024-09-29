using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAAL.Domain.Entities;

namespace WAAL.Persistence.Configuration
{
    public class ChiTietSanPhamConfig : IEntityTypeConfiguration<ChiTietSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
        {
            builder.Property(ct => ct.GiaNhap)
                .HasColumnType("decimal(18, 2)");

            builder.Property(ct => ct.GiaTien)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.SanPham)
                .WithMany(p => p.ChiTietSanPhams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ChipXuLy)
                .WithMany(p => p.ChiTietSanPhams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MauSac)
                .WithMany(p => p.ChiTietSanPhams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.CardDoHoa)
                .WithMany(p => p.ChiTietSanPhams)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
