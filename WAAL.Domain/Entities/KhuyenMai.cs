namespace WAAL.Domain.Entities
{
    public class KhuyenMai
    {
        public int Id { get; set; }
        public string TenKhuyenMai { get; set; }
        public decimal MucKhuyenMai { get; set; }
        public string DieuKien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public ICollection<ThongBao> ThongBaos { get; set; }
    }
}
