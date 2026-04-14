using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTQL_QLBHDongHo.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatDuLieu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiDongHo_LoaiDongHoID",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "GiaTri",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "TenThongSo",
                table: "ThongSoKyThuat");

            migrationBuilder.AddColumn<string>(
                name: "DoChiuNuoc",
                table: "ThongSoKyThuat",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KichThuocMat",
                table: "ThongSoKyThuat",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoaiDay",
                table: "ThongSoKyThuat",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LoaiDongHoID",
                table: "ThongSoKyThuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiKinh",
                table: "ThongSoKyThuat",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenThuongHieu",
                table: "ThongSoKyThuat",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiDongHoID",
                table: "SanPham",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongBan",
                table: "HoaDonChiTiet",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuat_LoaiDongHoID",
                table: "ThongSoKyThuat",
                column: "LoaiDongHoID");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiDongHo_LoaiDongHoID",
                table: "SanPham",
                column: "LoaiDongHoID",
                principalTable: "LoaiDongHo",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongSoKyThuat_LoaiDongHo_LoaiDongHoID",
                table: "ThongSoKyThuat",
                column: "LoaiDongHoID",
                principalTable: "LoaiDongHo",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiDongHo_LoaiDongHoID",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongSoKyThuat_LoaiDongHo_LoaiDongHoID",
                table: "ThongSoKyThuat");

            migrationBuilder.DropIndex(
                name: "IX_ThongSoKyThuat_LoaiDongHoID",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "DoChiuNuoc",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "KichThuocMat",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "LoaiDay",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "LoaiDongHoID",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "LoaiKinh",
                table: "ThongSoKyThuat");

            migrationBuilder.DropColumn(
                name: "TenThuongHieu",
                table: "ThongSoKyThuat");

            migrationBuilder.AddColumn<string>(
                name: "GiaTri",
                table: "ThongSoKyThuat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenThongSo",
                table: "ThongSoKyThuat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiDongHoID",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "SoLuongBan",
                table: "HoaDonChiTiet",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiDongHo_LoaiDongHoID",
                table: "SanPham",
                column: "LoaiDongHoID",
                principalTable: "LoaiDongHo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
