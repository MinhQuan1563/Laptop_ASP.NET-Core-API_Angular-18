namespace WAAL.Domain.Entities
{
    public class ChucNang
    {
        public Guid Id { get; set; }
        public string TenChucNang { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<ChiTietQuyen> ChiTietQuyens { get; set; }
    }
}
