using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThongBao_FK_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HoaDonId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KhuyenMaiId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NhaCungCapId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuBaoHanhId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuDoiTraId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhieuNhapId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SanPhamId1",
                table: "ThongBaos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_AppUserId",
                table: "ThongBaos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_HoaDonId1",
                table: "ThongBaos",
                column: "HoaDonId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_KhuyenMaiId1",
                table: "ThongBaos",
                column: "KhuyenMaiId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_NhaCungCapId1",
                table: "ThongBaos",
                column: "NhaCungCapId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuBaoHanhId1",
                table: "ThongBaos",
                column: "PhieuBaoHanhId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuDoiTraId1",
                table: "ThongBaos",
                column: "PhieuDoiTraId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_PhieuNhapId1",
                table: "ThongBaos",
                column: "PhieuNhapId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_SanPhamId1",
                table: "ThongBaos",
                column: "SanPhamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId",
                table: "ThongBaos",
                column: "HoaDonId",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId1",
                table: "ThongBaos",
                column: "HoaDonId1",
                principalTable: "HoaDons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId",
                table: "ThongBaos",
                column: "KhuyenMaiId",
                principalTable: "KhuyenMais",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId1",
                table: "ThongBaos",
                column: "KhuyenMaiId1",
                principalTable: "KhuyenMais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId",
                table: "ThongBaos",
                column: "NhaCungCapId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId1",
                table: "ThongBaos",
                column: "NhaCungCapId1",
                principalTable: "NhaCungCaps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId",
                table: "ThongBaos",
                column: "PhieuBaoHanhId",
                principalTable: "PhieuBaoHanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId1",
                table: "ThongBaos",
                column: "PhieuBaoHanhId1",
                principalTable: "PhieuBaoHanhs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId",
                table: "ThongBaos",
                column: "PhieuDoiTraId",
                principalTable: "PhieuDoiTras",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId1",
                table: "ThongBaos",
                column: "PhieuDoiTraId1",
                principalTable: "PhieuDoiTras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId",
                table: "ThongBaos",
                column: "PhieuNhapId",
                principalTable: "PhieuNhaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId1",
                table: "ThongBaos",
                column: "PhieuNhapId1",
                principalTable: "PhieuNhaps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId",
                table: "ThongBaos",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId1",
                table: "ThongBaos",
                column: "SanPhamId1",
                principalTable: "SanPhams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_Users_AppUserId",
                table: "ThongBaos",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_HoaDons_HoaDonId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_KhuyenMais_KhuyenMaiId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_NhaCungCaps_NhaCungCapId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuBaoHanhs_PhieuBaoHanhId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuDoiTras_PhieuDoiTraId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_PhieuNhaps_PhieuNhapId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_SanPhams_SanPhamId1",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_Users_AppUserId",
                table: "ThongBaos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBaos_Users_UserId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_AppUserId",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_HoaDonId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_KhuyenMaiId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_NhaCungCapId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuBaoHanhId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuDoiTraId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_PhieuNhapId1",
                table: "ThongBaos");

            migrationBuilder.DropIndex(
                name: "IX_ThongBaos_SanPhamId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "HoaDonId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "KhuyenMaiId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuBaoHanhId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuDoiTraId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "PhieuNhapId1",
                table: "ThongBaos");

            migrationBuilder.DropColumn(
                name: "SanPhamId1",
                table: "ThongBaos");

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
    }
}
