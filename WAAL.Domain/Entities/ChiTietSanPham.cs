namespace WAAL.Domain.Entities
{
    public class ChiTietSanPham
    {
        public int MaCtsp { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public decimal GiaNhap { get; set; }
        public float ChietKhau { get; set; }
        public decimal GiaTien { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public SanPham SanPham { get; set; }
        public MauSac MauSac { get; set; }
        public CardDoHoa CardDoHoa { get; set; }
        public ChipXuLy ChipXuLy { get; set; }
        public ICollection<Imei> Imeis { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
        public ICollection<ChiTietCongKetNoi> ChiTietCongKetNois { get; set; }
    }
}
