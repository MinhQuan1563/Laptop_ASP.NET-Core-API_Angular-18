namespace WAAL.Domain.Entities
{
    public class ChiTietQuyen
    {
        public int MaQuyen { get; set; }
        public int MaChucNang { get; set; }
        public string HanhDong { get; set; }
        public NhomQuyen NhomQuyen { get; set; }
        public ChucNang ChucNang { get; set; }
    }
}
