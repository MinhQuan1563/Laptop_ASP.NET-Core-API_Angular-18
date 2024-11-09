namespace WAAL.Application.DTOs
{
    public class PhieuDoiTraDTO
    {
        public Guid Id { get; set; }
        public DateTime NgayTra { get; set; }
        public int TongSoLuong { get; set; }
        public decimal TongTienTra { get; set; }
        public bool TrangThai { get; set; }
    }
}
