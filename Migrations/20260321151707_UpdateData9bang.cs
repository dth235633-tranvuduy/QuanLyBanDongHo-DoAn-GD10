using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTQL_QLBHDongHo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData9bang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangSanXuats",
                columns: table => new
                {
                    MaHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuocGia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSanXuats", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDongHos",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDongHos", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaHang = table.Column<int>(type: "int", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPhams_HangSanXuats_MaHang",
                        column: x => x.MaHang,
                        principalTable: "HangSanXuats",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiDongHos_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiDongHos",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_PhanQuyens_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "PhanQuyens",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuats",
                columns: table => new
                {
                    MaTS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiMay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatLieuDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuats", x => x.MaTS);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuats_SanPhams_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaSP",
                table: "ChiTietHoaDons",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaKH",
                table: "HoaDons",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaNV",
                table: "HoaDons",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaQuyen",
                table: "NhanViens",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaHang",
                table: "SanPhams",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLoai",
                table: "SanPhams",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuats_MaSP",
                table: "ThongSoKyThuats",
                column: "MaSP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuats");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "HangSanXuats");

            migrationBuilder.DropTable(
                name: "LoaiDongHos");

            migrationBuilder.DropTable(
                name: "PhanQuyens");
        }
    }
}
