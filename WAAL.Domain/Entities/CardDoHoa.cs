namespace WAAL.Domain.Entities
{
    public class CardDoHoa
    {
        public int Id { get; set; }
        public string TenCard { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
