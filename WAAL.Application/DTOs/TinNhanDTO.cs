namespace WAAL.Application.DTOs
{
    public class TinNhanDTO
    {
        public Guid Id { get; set; }
        public Guid CuocTroChuyenId { get; set; }
        public Guid NguoiGuiId { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGianGui { get; set; }
        public bool DaDoc { get; set; }
    }

}
