using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAAL.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChiTietSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCongKetNois_ChiTietSanPham_MaCtsp",
                table: "ChiTietCongKetNois");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietSanPham_MaCtsp",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_CardDoHoas_CardDoHoaId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_ChipXuLys_ChipXuLyId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_MauSacs_MauSacId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_SanPhams_SanPhamId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_ChiTietSanPham_MaCtsp",
                table: "GioHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_Imeis_ChiTietSanPham_ChiTietSanPhamId",
                table: "Imeis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietSanPham",
                table: "ChiTietSanPham");

            migrationBuilder.RenameTable(
                name: "ChiTietSanPham",
                newName: "ChiTietSanPhams");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_SanPhamId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_MauSacId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_MauSacId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_ChipXuLyId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_ChipXuLyId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPham_CardDoHoaId",
                table: "ChiTietSanPhams",
                newName: "IX_ChiTietSanPhams_CardDoHoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietSanPhams",
                table: "ChiTietSanPhams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCongKetNois_ChiTietSanPhams_MaCtsp",
                table: "ChiTietCongKetNois",
                column: "MaCtsp",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietSanPhams_MaCtsp",
                table: "ChiTietPhieuNhaps",
                column: "MaCtsp",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_CardDoHoas_CardDoHoaId",
                table: "ChiTietSanPhams",
                column: "CardDoHoaId",
                principalTable: "CardDoHoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_ChipXuLys_ChipXuLyId",
                table: "ChiTietSanPhams",
                column: "ChipXuLyId",
                principalTable: "ChipXuLys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_MauSacs_MauSacId",
                table: "ChiTietSanPhams",
                column: "MauSacId",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPhams_SanPhams_SanPhamId",
                table: "ChiTietSanPhams",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_ChiTietSanPhams_MaCtsp",
                table: "GioHangs",
                column: "MaCtsp",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imeis_ChiTietSanPhams_ChiTietSanPhamId",
                table: "Imeis",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCongKetNois_ChiTietSanPhams_MaCtsp",
                table: "ChiTietCongKetNois");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietSanPhams_MaCtsp",
                table: "ChiTietPhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_CardDoHoas_CardDoHoaId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_ChipXuLys_ChipXuLyId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_MauSacs_MauSacId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPhams_SanPhams_SanPhamId",
                table: "ChiTietSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_ChiTietSanPhams_MaCtsp",
                table: "GioHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_Imeis_ChiTietSanPhams_ChiTietSanPhamId",
                table: "Imeis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietSanPhams",
                table: "ChiTietSanPhams");

            migrationBuilder.RenameTable(
                name: "ChiTietSanPhams",
                newName: "ChiTietSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_SanPhamId",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_SanPhamId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_MauSacId",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_MauSacId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_ChipXuLyId",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_ChipXuLyId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietSanPhams_CardDoHoaId",
                table: "ChiTietSanPham",
                newName: "IX_ChiTietSanPham_CardDoHoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietSanPham",
                table: "ChiTietSanPham",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCongKetNois_ChiTietSanPham_MaCtsp",
                table: "ChiTietCongKetNois",
                column: "MaCtsp",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietPhieuNhaps_ChiTietSanPham_MaCtsp",
                table: "ChiTietPhieuNhaps",
                column: "MaCtsp",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_CardDoHoas_CardDoHoaId",
                table: "ChiTietSanPham",
                column: "CardDoHoaId",
                principalTable: "CardDoHoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_ChipXuLys_ChipXuLyId",
                table: "ChiTietSanPham",
                column: "ChipXuLyId",
                principalTable: "ChipXuLys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_MauSacs_MauSacId",
                table: "ChiTietSanPham",
                column: "MauSacId",
                principalTable: "MauSacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_SanPhams_SanPhamId",
                table: "ChiTietSanPham",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_ChiTietSanPham_MaCtsp",
                table: "GioHangs",
                column: "MaCtsp",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imeis_ChiTietSanPham_ChiTietSanPhamId",
                table: "Imeis",
                column: "ChiTietSanPhamId",
                principalTable: "ChiTietSanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
