using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTQL_QLBHDongHo.Migrations
{
    /// <inheritdoc />
    public partial class HoaDonSnapshot_SetNull_DeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienID",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamID",
                table: "HoaDonChiTiet");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamID",
                table: "HoaDonChiTiet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TenSanPhamSnapshot",
                table: "HoaDonChiTiet",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienID",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangID",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon",
                column: "KhachHangID",
                principalTable: "KhachHang",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienID",
                table: "HoaDon",
                column: "NhanVienID",
                principalTable: "NhanVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamID",
                table: "HoaDonChiTiet",
                column: "SanPhamID",
                principalTable: "SanPham",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienID",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamID",
                table: "HoaDonChiTiet");

            migrationBuilder.DropColumn(
                name: "TenSanPhamSnapshot",
                table: "HoaDonChiTiet");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamID",
                table: "HoaDonChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienID",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangID",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon",
                column: "KhachHangID",
                principalTable: "KhachHang",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienID",
                table: "HoaDon",
                column: "NhanVienID",
                principalTable: "NhanVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiet_SanPham_SanPhamID",
                table: "HoaDonChiTiet",
                column: "SanPhamID",
                principalTable: "SanPham",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
