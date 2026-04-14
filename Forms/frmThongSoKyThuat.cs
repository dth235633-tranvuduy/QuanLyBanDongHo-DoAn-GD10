using System;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmThongSoKyThuat : Form
    {
        public class ThongSoKyThuatInput
        {
            public string LoaiKinh { get; set; } = string.Empty;
            public string DoChiuNuoc { get; set; } = string.Empty;
            public string LoaiDay { get; set; } = string.Empty;
            public string KichThuocMat { get; set; } = string.Empty;
            public string TenThuongHieu { get; set; } = string.Empty;
            public int? LoaiDongHoID { get; set; }
        }

        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly int _sanPhamId;
        private readonly string _tenThuongHieuNhap;
        private readonly bool _laSanPhamTam;
        private readonly string _maSanPhamHienThi;
        public ThongSoKyThuatInput? KetQuaNhap { get; private set; }

        public frmThongSoKyThuat(int sanPhamId, string? tenThuongHieu = null, ThongSoKyThuatInput? duLieuTam = null, bool laSanPhamTam = false, string? maSanPhamHienThi = null)
        {
            InitializeComponent();
            _sanPhamId = sanPhamId;
            _tenThuongHieuNhap = tenThuongHieu ?? string.Empty;
            _laSanPhamTam = laSanPhamTam;
            _maSanPhamHienThi = maSanPhamHienThi ?? (sanPhamId > 0 ? $"SP{sanPhamId:D3}" : "");
            KetQuaNhap = duLieuTam;
            Load += FrmThongSoKyThuat_Load;
        }

        private void FrmThongSoKyThuat_Load(object? sender, EventArgs e)
        {
            var loaiList = _context.LoaiDongHo.AsNoTracking().ToList();
            cboLoaiDongHo.DisplayMember = "TenLoai";
            cboLoaiDongHo.ValueMember = "ID";
            cboLoaiDongHo.DataSource = loaiList;
            cboLoaiDongHo.SelectedIndex = -1;

            if (_laSanPhamTam)
            {
                txtSanPhamID.Text = string.IsNullOrWhiteSpace(_maSanPhamHienThi) ? "(Tạm)" : _maSanPhamHienThi;
                txtTenThuongHieu.Text = _tenThuongHieuNhap;
            }
            else
            {
                var sanPham = _context.SanPham
                    .Include(x => x.ThuongHieu)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.ID == _sanPhamId);

                if (sanPham == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để nhập thông số kỹ thuật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtSanPhamID.Text = $"SP{sanPham.ID:D3}";
                txtTenThuongHieu.Text = sanPham.ThuongHieu?.TenThuongHieu ?? string.Empty;
            }

            txtSanPhamID.ReadOnly = true;
            txtTenThuongHieu.ReadOnly = true;

            if (!_laSanPhamTam)
            {
                var ts = _context.ThongSoKyThuat.AsNoTracking().FirstOrDefault(x => x.SanPhamID == _sanPhamId);
                if (ts != null)
                {
                    txtLoaiKinh.Text = ts.LoaiKinh;
                    txtDoChiuNuoc.Text = ts.DoChiuNuoc;
                    txtLoaiDay.Text = ts.LoaiDay;
                    txtKichThuocMat.Text = ts.KichThuocMat;
                    if (ts.LoaiDongHoID.HasValue)
                    {
                        cboLoaiDongHo.SelectedValue = ts.LoaiDongHoID.Value;
                    }
                }
            }
            else if (KetQuaNhap != null)
            {
                txtLoaiKinh.Text = KetQuaNhap.LoaiKinh;
                txtDoChiuNuoc.Text = KetQuaNhap.DoChiuNuoc;
                txtLoaiDay.Text = KetQuaNhap.LoaiDay;
                txtKichThuocMat.Text = KetQuaNhap.KichThuocMat;
                txtTenThuongHieu.Text = KetQuaNhap.TenThuongHieu;
                if (KetQuaNhap.LoaiDongHoID.HasValue)
                {
                    cboLoaiDongHo.SelectedValue = KetQuaNhap.LoaiDongHoID.Value;
                }
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoaiKinh.Text) ||
                string.IsNullOrWhiteSpace(txtDoChiuNuoc.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiDay.Text) ||
                string.IsNullOrWhiteSpace(txtKichThuocMat.Text) ||
                cboLoaiDongHo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông số kỹ thuật.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaNhap = new ThongSoKyThuatInput
            {
                LoaiKinh = txtLoaiKinh.Text.Trim(),
                DoChiuNuoc = txtDoChiuNuoc.Text.Trim(),
                LoaiDay = txtLoaiDay.Text.Trim(),
                KichThuocMat = txtKichThuocMat.Text.Trim(),
                TenThuongHieu = txtTenThuongHieu.Text.Trim(),
                LoaiDongHoID = cboLoaiDongHo.SelectedValue is int loaiId ? loaiId : null
            };

            if (!_laSanPhamTam)
            {
                var spTonTai = _context.SanPham.AsNoTracking().Any(x => x.ID == _sanPhamId);
                if (!spTonTai)
                {
                    MessageBox.Show("Sản phẩm chưa tồn tại trong cơ sở dữ liệu. Hãy lưu sản phẩm trước rồi nhập thông số kỹ thuật.", "Lỗi liên kết dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var ts = _context.ThongSoKyThuat.FirstOrDefault(x => x.SanPhamID == _sanPhamId);
                    if (ts == null)
                    {
                        ts = new ThongSoKyThuat { SanPhamID = _sanPhamId };
                        _context.ThongSoKyThuat.Add(ts);
                    }

                    ts.LoaiKinh = KetQuaNhap.LoaiKinh;
                    ts.DoChiuNuoc = KetQuaNhap.DoChiuNuoc;
                    ts.LoaiDay = KetQuaNhap.LoaiDay;
                    ts.KichThuocMat = KetQuaNhap.KichThuocMat;
                    ts.TenThuongHieu = KetQuaNhap.TenThuongHieu;
                    ts.LoaiDongHoID = KetQuaNhap.LoaiDongHoID;

                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Không thể lưu thông số kỹ thuật do lỗi liên kết dữ liệu (FK).\nChi tiết: " + ex.InnerException?.Message, "Lỗi lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtTenThuongHieu_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboLoaiDongHo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
