namespace WAAL.Application.DTOs
{
    public class PhieuBaoHanhDTO
    {
        public int Id { get; set; }
        public DateTime NgayBaoHanh { get; set; }
        public DateTime NgayTra { get; set; }
        public string TinhTrang { get; set; }
        public bool TrangThai { get; set; }
    }
}
