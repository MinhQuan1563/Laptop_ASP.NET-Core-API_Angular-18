using Microsoft.AspNetCore.Identity;

namespace WAAL.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string? HinhAnh { get; set; }
        public string? DiaChi { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<PhieuNhap>? PhieuNhaps { get; set; }
        public ICollection<PhieuDoiTra>? PhieuDoiTras { get; set; }
        public ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public ICollection<ThongTinNhanHang>? ThongTinNhanHangs { get; set; }
        public ICollection<DanhGia>? DanhGias { get; set; }
        public ICollection<GioHang>? GioHangs { get; set; }
    }
}
