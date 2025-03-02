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
            CreateMap<ChiTietHoaDon, ChiTietHoaDonDTO>()
                .ForMember(dest => dest.MaHd, opt => opt.MapFrom(src => src.HoaDon.Id))
                .ForMember(dest => dest.MaImei, opt => opt.MapFrom(src => src.Imei.Id))
                .ReverseMap();
            CreateMap<ChiTietKhuyenMai, ChiTietKhuyenMaiDTO>()
                .ForMember(dest => dest.MaHd, opt => opt.MapFrom(src => src.HoaDon.Id))
                .ForMember(dest => dest.MaKm, opt => opt.MapFrom(src => src.KhuyenMai.Id))
                .ReverseMap();
            CreateMap<ChiTietPhieuBaoHanh, ChiTietPhieuBaoHanhDTO>().ReverseMap();
            CreateMap<ChiTietPhieuDoiTra, ChiTietPhieuDoiTraDTO>().ReverseMap();
            CreateMap<ChiTietPhieuNhap, ChiTietPhieuNhapDTO>().ReverseMap();
            CreateMap<ChiTietSanPham, ChiTietSanPhamDTO>()
                .ForMember(dest => dest.SanPhamId, opt => opt.MapFrom(src => src.SanPham.Id))
                .ForMember(dest => dest.MauSacId, opt => opt.MapFrom(src => src.MauSac.Id))
                .ForMember(dest => dest.CardDoHoaId, opt => opt.MapFrom(src => src.CardDoHoa.Id))
                .ForMember(dest => dest.ChipXuLyId, opt => opt.MapFrom(src => src.ChipXuLy.Id))
                .ReverseMap();
            CreateMap<CongKetNoi, CongKetNoiDTO>().ReverseMap();
            CreateMap<DanhGia, DanhGiaDTO>()
                .ForMember(dest => dest.MaSp, opt => opt.MapFrom(src => src.SanPham.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ReverseMap();
            CreateMap<GioHang, GioHangDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.MaCtsp, opt => opt.MapFrom(src => src.ChiTietSanPham.Id))
                .ReverseMap();
            CreateMap<HeDieuHanh, HeDieuHanhDTO>().ReverseMap();
            CreateMap<HoaDon, HoaDonDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.ThongTinNhanHangId, opt => opt.MapFrom(src => src.ThongTinNhanHang.Id))
                .ReverseMap();
            CreateMap<Imei, ImeiDTO>()
                .ForMember(dest => dest.ChiTietSanPhamId, opt => opt.MapFrom(src => src.ChiTietSanPham.Id))
                .ReverseMap();
            CreateMap<KhuyenMai, KhuyenMaiDTO>().ReverseMap();
            CreateMap<NhaCungCap, NhaCungCapDTO>().ReverseMap();
            CreateMap<PhieuBaoHanh, PhieuBaoHanhDTO>().ReverseMap();
            CreateMap<PhieuDoiTra, PhieuDoiTraDTO>().ReverseMap();
            CreateMap<PhieuNhap, PhieuNhapDTO>().ReverseMap();
            CreateMap<SanPham, SanPhamDTO>()
                .ForMember(dest => dest.ThuongHieuId, opt => opt.MapFrom(src => src.ThuongHieu.Id))
                .ForMember(dest => dest.HeDieuHanhId, opt => opt.MapFrom(src => src.HeDieuHanh.Id))
                .ForMember(dest => dest.TheLoaiId, opt => opt.MapFrom(src => src.TheLoai.Id))
                .ReverseMap()
                .ForMember(dest => dest.ThuongHieu, opt => opt.Ignore())  // Ignore để tránh lỗi ánh xạ
                .ForMember(dest => dest.TheLoai, opt => opt.Ignore())
                .ForMember(dest => dest.HeDieuHanh, opt => opt.Ignore());
            CreateMap<SanPham, SanPhamListDTO>()
                .ForMember(dest => dest.HinhAnh, opt => opt.MapFrom(src => src.HinhAnh));
            CreateMap<TheLoai, TheLoaiDTO>().ReverseMap();
            CreateMap<ThongBao, ThongBaoDTO>().ReverseMap();
            CreateMap<ThongTinNhanHang, ThongTinNhanHangDTO>().ReverseMap();
            CreateMap<ThuongHieu, ThuongHieuDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<ChucNang, ChucNangDTO>().ReverseMap();
            CreateMap<ChiTietQuyen, ChiTietQuyenDTO>().ReverseMap();
            CreateMap<ChiTietQuyen, ChiTietChucNangQuyenDTO>()
                .ForMember(dest => dest.TenChucNang, opt => opt.MapFrom(src => src.ChucNang.TenChucNang))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.HanhDong, opt => opt.MapFrom(src => src.HanhDong))
                .ReverseMap();
            CreateMap<AppUser, UserDTO>()
                .ForMember(dest => dest.HinhAnh, opt => opt.MapFrom(src => src.HinhAnh));
            CreateMap<AppUser, UserCreateDTO>()
                .ReverseMap();
        }
    }
}
