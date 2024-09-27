namespace WAAL.Domain.Entities
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string TenNv { get; set; }
        public int Tuoi { get; set; }
        public string SoDienThoai { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
        public ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public ICollection<PhieuDoiTra> PhieuDoiTras { get; set; }
        public ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }

    }
}
