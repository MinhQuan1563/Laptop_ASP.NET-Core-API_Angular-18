namespace WAAL.Domain.Entities
{
    public class CardDoHoa
    {
        public Guid Id { get; set; }
        public string TenCard { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
