namespace WAAL.Application.DTOs
{
    public class KhuyenMaiDTO
    {
        public Guid Id { get; set; }
        public string TenKhuyenMai { get; set; }
        public decimal MucKhuyenMai { get; set; }
        public string DieuKien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; }
    }
}
