namespace WAAL.Application.DTOs
{
    public class HoaDonDTO
    {
        public Guid Id { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal TongTienSauKhuyenMai { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string? GhiChu { get; set; }
        public string TinhTrang { get; set; }
        public Guid UserId { get; set; }
        public Guid ThongTinNhanHangId { get; set; }
    }
}
