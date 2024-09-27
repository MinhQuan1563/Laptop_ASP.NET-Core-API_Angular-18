namespace WAAL.Domain.Entities
{
    public class SanPham
    {
        public int Id { get; set; }
        public string TenSp { get; set; }
        public string HinhAnh { get; set; }
        public string KichCoManHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public string Pin { get; set; }
        public string BanPhim { get; set; }
        public double TrongLuong { get; set; }
        public string ChatLieu { get; set; }
        public string XuatXu { get; set; }
        public int SoLuongTon { get; set; }
        public bool TrangThai { get; set; }
        public ThuongHieu ThuongHieu { get; set; }
        public TheLoai TheLoai { get; set; }
        public HeDieuHanh HeDieuHanh { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }

    }
}
