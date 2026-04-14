using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTQL_QLBHDongHo.Migrations
{
    /// <inheritdoc />
    public partial class themDiaChiNV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DienThoai",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "DienThoai",
                table: "NhanVien");
        }
    }
}
