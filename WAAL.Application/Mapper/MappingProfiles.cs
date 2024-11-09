using AutoMapper;
using WAAL.Application.DTOs;
using WAAL.Domain.Entities;

namespace WAAL.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CardDoHoa, CardDoHoaDTO>().ReverseMap();
            CreateMap<MauSac, MauSacDTO>().ReverseMap();
            CreateMap<ChipXuLy, ChipXuLyDTO>().ReverseMap();
            CreateMap<ChiTietCongKetNoi, ChiTietCongKetNoiDTO>().ReverseMap();
            CreateMap<ChiTietHoaDon, ChiTietHoaDonDTO>().ReverseMap();
            CreateMap<ChiTietKhuyenMai, ChiTietKhuyenMaiDTO>().ReverseMap();
            CreateMap<ChiTietPhieuBaoHanh, ChiTietPhieuBaoHanhDTO>().ReverseMap();
            CreateMap<ChiTietPhieuDoiTra, ChiTietPhieuDoiTraDTO>().ReverseMap();
            CreateMap<ChiTietPhieuNhap, ChiTietPhieuNhapDTO>().ReverseMap();
            CreateMap<ChiTietSanPham, ChiTietSanPhamDTO>().ReverseMap();
            CreateMap<CongKetNoi, CongKetNoiDTO>().ReverseMap();
            CreateMap<DanhGia, DanhGiaDTO>().ReverseMap();
            CreateMap<GioHang, GioHangDTO>().ReverseMap();
            CreateMap<HeDieuHanh, HeDieuHanhDTO>().ReverseMap();
            CreateMap<HoaDon, HoaDonDTO>().ReverseMap();
            CreateMap<Imei, ImeiDTO>().ReverseMap();
            CreateMap<KhuyenMai, KhuyenMaiDTO>().ReverseMap();
            CreateMap<NhaCungCap, NhaCungCapDTO>().ReverseMap();
            CreateMap<PhieuBaoHanh, PhieuBaoHanhDTO>().ReverseMap();
            CreateMap<PhieuDoiTra, PhieuDoiTraDTO>().ReverseMap();
            CreateMap<PhieuNhap, PhieuNhapDTO>().ReverseMap();
            CreateMap<SanPham, SanPhamDTO>().ReverseMap();
            CreateMap<TheLoai, TheLoaiDTO>().ReverseMap();
            CreateMap<ThongBao, ThongBaoDTO>().ReverseMap();
            CreateMap<ThongTinNhanHang, ThongTinNhanHangDTO>().ReverseMap();
            CreateMap<ThuongHieu, ThuongHieuDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
        }
    }
}
