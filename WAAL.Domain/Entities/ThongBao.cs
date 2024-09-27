namespace WAAL.Domain.Entities
{
    public class ThongBao
    {
        public int MaSp { get; set; }
        public int MaKh { get; set; }
        public int MaNv { get; set; }
        public int MaTk { get; set; }
        public int MaHd { get; set; }
        public int MaPn { get; set; }
        public int MaPdt { get; set; }
        public int MaPbh { get; set; }
        public int MaNcc { get; set; }
        public int MaKm { get; set; }
        public int MaNq { get; set; }
        public int MaCn { get; set; }
        public string NoiDung { get; set; }
        public bool TrangThai { get; set; }
        public SanPham SanPham { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public HoaDon HoaDon { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
        public PhieuDoiTra PhieuDoiTra { get; set; }
        public PhieuBaoHanh PhieuBaoHanh { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public NhomQuyen NhomQuyen { get; set; }
        public ChucNang ChucNang { get; set; }
    }
}
