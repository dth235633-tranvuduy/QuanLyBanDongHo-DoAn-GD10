using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTQL_QLBHDongHo.Migrations
{
    /// <inheritdoc />
    public partial class DoiTenHangSanXuatThanhThuongHieu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_HangSanXuat_HangSanXuatID",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "HangSanXuat",
                newName: "ThuongHieu");

            migrationBuilder.RenameColumn(
                name: "TenHangSanXuat",
                table: "ThuongHieu",
                newName: "TenThuongHieu");

            migrationBuilder.RenameColumn(
                name: "HangSanXuatID",
                table: "SanPham",
                newName: "ThuongHieuID");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_HangSanXuatID",
                table: "SanPham",
                newName: "IX_SanPham_ThuongHieuID");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_ThuongHieu_ThuongHieuID",
                table: "SanPham",
                column: "ThuongHieuID",
                principalTable: "ThuongHieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_ThuongHieu_ThuongHieuID",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "ThuongHieuID",
                table: "SanPham",
                newName: "HangSanXuatID");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_ThuongHieuID",
                table: "SanPham",
                newName: "IX_SanPham_HangSanXuatID");

            migrationBuilder.RenameColumn(
                name: "TenThuongHieu",
                table: "ThuongHieu",
                newName: "TenHangSanXuat");

            migrationBuilder.RenameTable(
                name: "ThuongHieu",
                newName: "HangSanXuat");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_HangSanXuat_HangSanXuatID",
                table: "SanPham",
                column: "HangSanXuatID",
                principalTable: "HangSanXuat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
