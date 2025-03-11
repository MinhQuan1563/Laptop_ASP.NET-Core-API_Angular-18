namespace WAAL.Domain.Entities
{
    public class TinNhan
    {
        public Guid Id { get; set; }
        public Guid CuocTroChuyenId { get; set; }
        public CuocTroChuyen CuocTroChuyen { get; set; }
        public Guid NguoiGuiId { get; set; }
        public AppUser NguoiGui { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGianGui { get; set; }
        public bool DaDoc { get; set; }
    }
}
