using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmXemThongTinSanPham : Form
    {
        private readonly int _sanPhamId;
        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly string _thuMucAnh = Path.Combine(Application.StartupPath, "Images");

        public frmXemThongTinSanPham(int sanPhamId)
        {
            InitializeComponent();
            _sanPhamId = sanPhamId;
            Load += frmXemThongTinSanPham_Load;
            btnDong.Click += (_, _) => Close();
            picHinhAnh.Resize += (_, _) => CapNhatCheDoHienThiAnh();
        }

        private void frmXemThongTinSanPham_Load(object? sender, EventArgs e)
        {
            if (!Directory.Exists(_thuMucAnh))
            {
                Directory.CreateDirectory(_thuMucAnh);
            }

            var sp = _context.SanPham
                .Include(x => x.ThuongHieu)
                .Include(x => x.LoaiDongHo)
                .FirstOrDefault(x => x.ID == _sanPhamId);

            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var ts = _context.ThongSoKyThuat
                .Include(x => x.LoaiDongHo)
                .AsNoTracking()
                .FirstOrDefault(x => x.SanPhamID == sp.ID);

            txtMaSP.Text = $"SP{sp.ID:D3}";
            txtTenSP.Text = sp.TenSanPham;
            txtGiaBan.Text = sp.DonGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            txtThuongHieu.Text = sp.ThuongHieu?.TenThuongHieu ?? string.Empty;
            txtLoaiDongHo.Text = ts?.LoaiDongHo?.TenLoai ?? sp.LoaiDongHo?.TenLoai ?? "(Chưa cập nhật)";
            txtSoLuong.Text = sp.SoLuong.ToString();

            txtLoaiKinh.Text = ts?.LoaiKinh ?? "(Chưa cập nhật)";
            txtDoChiuNuoc.Text = ts?.DoChiuNuoc ?? "(Chưa cập nhật)";
            txtLoaiDay.Text = ts?.LoaiDay ?? "(Chưa cập nhật)";
            txtKichThuocMat.Text = ts?.KichThuocMat ?? "(Chưa cập nhật)";
            txtTenThuongHieuTS.Text = ts?.TenThuongHieu ?? txtThuongHieu.Text;

            rtbGhiChu.Text = string.IsNullOrWhiteSpace(sp.MoTa)
                ? "(Không có ghi chú)"
                : sp.MoTa;

            var tenAnhDaChuan = DamBaoAnhNamTrongThuMucImages(sp.HinhAnh);
            if (!string.Equals(tenAnhDaChuan, sp.HinhAnh, StringComparison.Ordinal))
            {
                sp.HinhAnh = tenAnhDaChuan;
                try
                {
                    _context.SaveChanges();
                }
                catch
                {
                    // Không chặn màn hình xem nếu việc chuẩn hóa ảnh không lưu được vào DB.
                }
            }

            HienThiAnhTheoTenFile(tenAnhDaChuan);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            _context.Dispose();
            base.OnFormClosed(e);
        }

        private string? DamBaoAnhNamTrongThuMucImages(string? giaTriAnh)
        {
            if (string.IsNullOrWhiteSpace(giaTriAnh))
            {
                return null;
            }

            var duongDanNguon = string.Empty;
            if (Path.IsPathRooted(giaTriAnh))
            {
                if (!File.Exists(giaTriAnh))
                {
                    return null;
                }

                duongDanNguon = giaTriAnh;
            }
            else
            {
                var tenFile = Path.GetFileName(giaTriAnh);
                var duongDanTrongFolderAnh = Path.Combine(_thuMucAnh, tenFile);
                if (File.Exists(duongDanTrongFolderAnh))
                {
                    return tenFile;
                }

                var duongDanTuongDoi = Path.Combine(Application.StartupPath, giaTriAnh);
                if (!File.Exists(duongDanTuongDoi))
                {
                    return null;
                }

                duongDanNguon = duongDanTuongDoi;
            }

            var thuMucNguon = Path.GetFullPath(Path.GetDirectoryName(duongDanNguon) ?? string.Empty)
                .TrimEnd(Path.DirectorySeparatorChar);
            var thuMucDich = Path.GetFullPath(_thuMucAnh).TrimEnd(Path.DirectorySeparatorChar);

            if (string.Equals(thuMucNguon, thuMucDich, StringComparison.OrdinalIgnoreCase))
            {
                return Path.GetFileName(duongDanNguon);
            }

            var extension = Path.GetExtension(duongDanNguon);
            var tenFileMoi = $"{Guid.NewGuid():N}{extension}";
            var duongDanDich = Path.Combine(_thuMucAnh, tenFileMoi);

            File.Copy(duongDanNguon, duongDanDich, true);
            return tenFileMoi;
        }

        private void HienThiAnhTheoTenFile(string? tenFileAnh)
        {
            if (string.IsNullOrWhiteSpace(tenFileAnh))
            {
                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = null;
                }

                return;
            }

            var duongDanDayDu = Path.Combine(_thuMucAnh, tenFileAnh);
            if (!File.Exists(duongDanDayDu))
            {
                return;
            }

            try
            {
                using var fs = new FileStream(duongDanDayDu, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var imgNguon = Image.FromStream(fs);
                var banSaoAnh = new Bitmap(imgNguon);

                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                }

                picHinhAnh.Image = banSaoAnh;
                CapNhatCheDoHienThiAnh();
            }
            catch
            {
                // Bỏ qua lỗi hiển thị ảnh để không ảnh hưởng phần thông tin khác.
            }
        }

        private void CapNhatCheDoHienThiAnh()
        {
            if (picHinhAnh.Image == null)
            {
                picHinhAnh.SizeMode = PictureBoxSizeMode.CenterImage;
                return;
            }

            var img = picHinhAnh.Image;
            if (img.Width <= picHinhAnh.ClientSize.Width && img.Height <= picHinhAnh.ClientSize.Height)
            {
                // Ảnh nhỏ hơn khung: giữ nguyên kích thước gốc để tránh mờ do phóng to.
                picHinhAnh.SizeMode = PictureBoxSizeMode.CenterImage;
                return;
            }

            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
