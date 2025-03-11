using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThongBaoNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_HoaDons_MaHd",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_KhuyenMais_MaKm",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_MaNcc",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_MaPbh",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_MaPdt",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_MaPn",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_SanPhams_MaSp",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaHd",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaKm",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaNcc",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaPbh",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaPdt",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaPn",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_MaSp",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaHd",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaKm",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaNcc",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaPbh",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaPdt",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaPn",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "MaSp",
                table: "ThongBaos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "HoaDonId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KhuyenMaiId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NhaCungCapId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuBaoHanhId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuDoiTraId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuNhapId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SanPhamId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_HoaDonId",
                table: "ThongBaos",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_KhuyenMaiId",
                table: "ThongBaos",
                column: "KhuyenMaiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_NhaCungCapId",
                table: "ThongBaos",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuBaoHanhId",
                table: "ThongBaos",
                column: "PhieuBaoHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuDoiTraId",
                table: "ThongBaos",
                column: "PhieuDoiTraId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuNhapId",
                table: "ThongBaos",
                column: "PhieuNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_SanPhamId",
                table: "ThongBaos",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId",
                table: "ThongBaos",
                column: "HoaDonId",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId",
                table: "ThongBaos",
                column: "KhuyenMaiId",
                principalTable: "KhuyenMais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId",
                table: "ThongBaos",
                column: "NhaCungCapId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId",
                table: "ThongBaos",
                column: "PhieuBaoHanhId",
                principalTable: "PhieuBaoHanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId",
                table: "ThongBaos",
                column: "PhieuDoiTraId",
                principalTable: "PhieuDoiTras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId",
                table: "ThongBaos",
                column: "PhieuNhapId",
                principalTable: "PhieuNhaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId",
                table: "ThongBaos",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_HoaDonId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_KhuyenMaiId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_NhaCungCapId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuBaoHanhId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuDoiTraId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuNhapId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_SanPhamId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "KhuyenMaiId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuBaoHanhId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuDoiTraId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuNhapId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "SanPhamId",
                table: "ThongBaos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MaHd",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaKm",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaNcc",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaPbh",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaPdt",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaPn",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaSp",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaHd",
                table: "ThongBaos",
                column: "MaHd");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaKm",
                table: "ThongBaos",
                column: "MaKm");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaNcc",
                table: "ThongBaos",
                column: "MaNcc");

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
                name: "IX_ThongBaos_MaSp",
                table: "ThongBaos",
                column: "MaSp");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_HoaDons_MaHd",
                table: "ThongBaos",
                column: "MaHd",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_KhuyenMais_MaKm",
                table: "ThongBaos",
                column: "MaKm",
                principalTable: "KhuyenMais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_MaNcc",
                table: "ThongBaos",
                column: "MaNcc",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_MaPbh",
                table: "ThongBaos",
                column: "MaPbh",
                principalTable: "PhieuBaoHanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_MaPdt",
                table: "ThongBaos",
                column: "MaPdt",
                principalTable: "PhieuDoiTras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_MaPn",
                table: "ThongBaos",
                column: "MaPn",
                principalTable: "PhieuNhaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_SanPhams_MaSp",
                table: "ThongBaos",
                column: "MaSp",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
