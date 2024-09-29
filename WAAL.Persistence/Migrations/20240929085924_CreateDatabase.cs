using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardDoHoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDoHoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChipXuLys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipXuLys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucNangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CongKetNois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongKetNois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeDieuHanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHdh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeDieuHanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MucKhuyenMai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DieuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNcc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinNhanHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiMacDinh = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinNhanHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinNhanHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    NhaCungCapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhaCungCaps_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuyens",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    MaChucNang = table.Column<int>(type: "int", nullable: false),
                    HanhDong = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuyens", x => new { x.MaQuyen, x.MaChucNang, x.HanhDong });
                    table.ForeignKey(
                        name: "FK_ChiTietQuyens_ChucNangs_MaChucNang",
                        column: x => x.MaChucNang,
                        principalTable: "ChucNangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietQuyens_NhomQuyens_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "NhomQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otp = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_NhomQuyens_NhomQuyenId",
                        column: x => x.NhomQuyenId,
                        principalTable: "NhomQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichCoManHinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BanPhim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrongLuong = table.Column<double>(type: "float", nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XuatXu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ThuongHieuId = table.Column<int>(type: "int", nullable: false),
                    TheLoaiId = table.Column<int>(type: "int", nullable: false),
                    HeDieuHanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_HeDieuHanhs_HeDieuHanhId",
                        column: x => x.HeDieuHanhId,
                        principalTable: "HeDieuHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhams_TheLoais_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "TheLoais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhams_ThuongHieus_ThuongHieuId",
                        column: x => x.ThuongHieuId,
                        principalTable: "ThuongHieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    ThongTinNhanHangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_ThongTinNhanHangs_ThongTinNhanHangId",
                        column: x => x.ThongTinNhanHangId,
                        principalTable: "ThongTinNhanHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChietKhau = table.Column<float>(type: "real", nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    MauSacId = table.Column<int>(type: "int", nullable: false),
                    CardDoHoaId = table.Column<int>(type: "int", nullable: false),
                    ChipXuLyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_CardDoHoas_CardDoHoaId",
                        column: x => x.CardDoHoaId,
                        principalTable: "CardDoHoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_ChipXuLys_ChipXuLyId",
                        column: x => x.ChipXuLyId,
                        principalTable: "ChipXuLys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_MauSacs_MauSacId",
                        column: x => x.MauSacId,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGias",
                columns: table => new
                {
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDanhGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGias", x => new { x.MaSp, x.MaKh, x.ThoiGianDanhGia });
                    table.ForeignKey(
                        name: "FK_DanhGias_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGias_SanPhams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhuyenMais",
                columns: table => new
                {
                    MaKm = table.Column<int>(type: "int", nullable: false),
                    MaHd = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhuyenMais", x => new { x.MaHd, x.MaKm });
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMais_HoaDons_MaHd",
                        column: x => x.MaHd,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMais_KhuyenMais_MaKm",
                        column: x => x.MaKm,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuBaoHanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBaoHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    HoaDonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuBaoHanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuBaoHanhs_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuBaoHanhs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuBaoHanhs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuDoiTras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongSoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTienTra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    HoaDonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDoiTras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuDoiTras_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuDoiTras_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCongKetNois",
                columns: table => new
                {
                    MaCong = table.Column<int>(type: "int", nullable: false),
                    MaCtsp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCongKetNois", x => new { x.MaCtsp, x.MaCong });
                    table.ForeignKey(
                        name: "FK_ChiTietCongKetNois_ChiTietSanPham_MaCtsp",
                        column: x => x.MaCtsp,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietCongKetNois_CongKetNois_MaCong",
                        column: x => x.MaCong,
                        principalTable: "CongKetNois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    MaPn = table.Column<int>(type: "int", nullable: false),
                    MaCtsp = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => new { x.MaPn, x.MaCtsp });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_ChiTietSanPham_MaCtsp",
                        column: x => x.MaCtsp,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhaps_MaPn",
                        column: x => x.MaPn,
                        principalTable: "PhieuNhaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    MaCtsp = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => new { x.MaCtsp, x.MaKh });
                    table.ForeignKey(
                        name: "FK_GioHangs_ChiTietSanPham_MaCtsp",
                        column: x => x.MaCtsp,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imeis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ChiTietSanPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imeis_ChiTietSanPham_ChiTietSanPhamId",
                        column: x => x.ChiTietSanPhamId,
                        principalTable: "ChiTietSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaos",
                columns: table => new
                {
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    MaNv = table.Column<int>(type: "int", nullable: false),
                    MaTk = table.Column<int>(type: "int", nullable: false),
                    MaHd = table.Column<int>(type: "int", nullable: false),
                    MaPn = table.Column<int>(type: "int", nullable: false),
                    MaPdt = table.Column<int>(type: "int", nullable: false),
                    MaPbh = table.Column<int>(type: "int", nullable: false),
                    MaNcc = table.Column<int>(type: "int", nullable: false),
                    MaKm = table.Column<int>(type: "int", nullable: false),
                    MaNq = table.Column<int>(type: "int", nullable: false),
                    MaCn = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaos", x => new { x.MaSp, x.MaKh, x.MaNv, x.MaTk, x.MaHd, x.MaPn, x.MaPbh, x.MaPdt, x.MaNcc, x.MaKm, x.MaNq, x.MaCn });
                    table.ForeignKey(
                        name: "FK_ThongBaos_ChucNangs_MaCn",
                        column: x => x.MaCn,
                        principalTable: "ChucNangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_HoaDons_MaHd",
                        column: x => x.MaHd,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_KhuyenMais_MaKm",
                        column: x => x.MaKm,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_NhaCungCaps_MaNcc",
                        column: x => x.MaNcc,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_NhanViens_MaNv",
                        column: x => x.MaNv,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_NhomQuyens_MaNq",
                        column: x => x.MaNq,
                        principalTable: "NhomQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_PhieuBaoHanhs_MaPbh",
                        column: x => x.MaPbh,
                        principalTable: "PhieuBaoHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_PhieuDoiTras_MaPdt",
                        column: x => x.MaPdt,
                        principalTable: "PhieuDoiTras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_PhieuNhaps_MaPn",
                        column: x => x.MaPn,
                        principalTable: "PhieuNhaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_SanPhams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBaos_TaiKhoans_MaTk",
                        column: x => x.MaTk,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaHd = table.Column<int>(type: "int", nullable: false),
                    MaImei = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaSp = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => new { x.MaHd, x.MaImei });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHd",
                        column: x => x.MaHd,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_Imeis_MaImei",
                        column: x => x.MaImei,
                        principalTable: "Imeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuBaoHanhs",
                columns: table => new
                {
                    MaPbh = table.Column<int>(type: "int", nullable: false),
                    MaImei = table.Column<int>(type: "int", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDungBaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuBaoHanhs", x => new { x.MaPbh, x.MaImei });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuBaoHanhs_Imeis_MaImei",
                        column: x => x.MaImei,
                        principalTable: "Imeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuBaoHanhs_PhieuBaoHanhs_MaPbh",
                        column: x => x.MaPbh,
                        principalTable: "PhieuBaoHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuDoiTras",
                columns: table => new
                {
                    MaPdt = table.Column<int>(type: "int", nullable: false),
                    MaImei = table.Column<int>(type: "int", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaSp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuDoiTras", x => new { x.MaPdt, x.MaImei });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuDoiTras_Imeis_MaImei",
                        column: x => x.MaImei,
                        principalTable: "Imeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuDoiTras_PhieuDoiTras_MaPdt",
                        column: x => x.MaPdt,
                        principalTable: "PhieuDoiTras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCongKetNois_MaCong",
                table: "ChiTietCongKetNois",
                column: "MaCong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaImei",
                table: "ChiTietHoaDons",
                column: "MaImei");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMais_MaKm",
                table: "ChiTietKhuyenMais",
                column: "MaKm");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuBaoHanhs_MaImei",
                table: "ChiTietPhieuBaoHanhs",
                column: "MaImei");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuDoiTras_MaImei",
                table: "ChiTietPhieuDoiTras",
                column: "MaImei");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_MaCtsp",
                table: "ChiTietPhieuNhaps",
                column: "MaCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuyens_MaChucNang",
                table: "ChiTietQuyens",
                column: "MaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_CardDoHoaId",
                table: "ChiTietSanPham",
                column: "CardDoHoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_ChipXuLyId",
                table: "ChiTietSanPham",
                column: "ChipXuLyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_MauSacId",
                table: "ChiTietSanPham",
                column: "MauSacId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPham",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_MaKh",
                table: "DanhGias",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_MaKh",
                table: "GioHangs",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NhanVienId",
                table: "HoaDons",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_ThongTinNhanHangId",
                table: "HoaDons",
                column: "ThongTinNhanHangId");

            migrationBuilder.CreateIndex(
                name: "IX_Imeis_ChiTietSanPhamId",
                table: "Imeis",
                column: "ChiTietSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoHanhs_HoaDonId",
                table: "PhieuBaoHanhs",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoHanhs_KhachHangId",
                table: "PhieuBaoHanhs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBaoHanhs_NhanVienId",
                table: "PhieuBaoHanhs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDoiTras_HoaDonId",
                table: "PhieuDoiTras",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDoiTras_NhanVienId",
                table: "PhieuDoiTras",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhaCungCapId",
                table: "PhieuNhaps",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhanVienId",
                table: "PhieuNhaps",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_HeDieuHanhId",
                table: "SanPhams",
                column: "HeDieuHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_TheLoaiId",
                table: "SanPhams",
                column: "TheLoaiId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_ThuongHieuId",
                table: "SanPhams",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_NhomQuyenId",
                table: "TaiKhoans",
                column: "NhomQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaCn",
                table: "ThongBaos",
                column: "MaCn");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaHd",
                table: "ThongBaos",
                column: "MaHd");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaKh",
                table: "ThongBaos",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaKm",
                table: "ThongBaos",
                column: "MaKm");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaNcc",
                table: "ThongBaos",
                column: "MaNcc");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaNq",
                table: "ThongBaos",
                column: "MaNq");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaNv",
                table: "ThongBaos",
                column: "MaNv");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaPbh",
                table: "ThongBaos",
                column: "MaPbh");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaPdt",
                table: "ThongBaos",
                column: "MaPdt");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaPn",
                table: "ThongBaos",
                column: "MaPn");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaTk",
                table: "ThongBaos",
                column: "MaTk");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNhanHangs_KhachHangId",
                table: "ThongTinNhanHangs",
                column: "KhachHangId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietCongKetNois");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ChiTietKhuyenMais");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuBaoHanhs");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuDoiTras");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "ChiTietQuyens");

            migrationBuilder.DropTable(
                name: "DanhGias");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "ThongBaos");

            migrationBuilder.DropTable(
                name: "CongKetNois");

            migrationBuilder.DropTable(
                name: "Imeis");

            migrationBuilder.DropTable(
                name: "ChucNangs");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "PhieuBaoHanhs");

            migrationBuilder.DropTable(
                name: "PhieuDoiTras");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "ChiTietSanPham");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "NhomQuyens");

            migrationBuilder.DropTable(
                name: "CardDoHoas");

            migrationBuilder.DropTable(
                name: "ChipXuLys");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ThongTinNhanHangs");

            migrationBuilder.DropTable(
                name: "HeDieuHanhs");

            migrationBuilder.DropTable(
                name: "TheLoais");

            migrationBuilder.DropTable(
                name: "ThuongHieus");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
