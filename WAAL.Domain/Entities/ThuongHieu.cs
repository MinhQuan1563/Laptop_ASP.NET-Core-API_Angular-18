﻿namespace WAAL.Domain.Entities
{
    public class ThuongHieu
    {
        public int Id { get; set; }
        public string TenThuongHieu { get; set; }
        public bool TrangThai { get; set; } = true;
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
