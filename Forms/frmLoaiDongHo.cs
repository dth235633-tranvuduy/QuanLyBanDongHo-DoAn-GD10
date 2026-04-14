using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmLoaiDongHo : Form
    {
        private class LoaiDongHoViewModel
        {
            public int ID { get; set; }
            public string TenLoai { get; set; } = string.Empty;
        }

        private readonly QLBHDbContext context = new QLBHDbContext();
        private readonly BindingSource bindingSource = new BindingSource();
        private readonly VaiTroNguoiDung _vaiTro;

        private bool xuLyThem = false;
        private int idDangSua = 0;

        public frmLoaiDongHo(VaiTroNguoiDung? vaiTro = null)
        {
            InitializeComponent();
            _vaiTro = vaiTro ?? AppSession.VaiTro;

            Load += frmLoaiDongHo_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;

            dgvLoaiDongHo.SelectionChanged += dgvLoaiDongHo_SelectionChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void frmLoaiDongHo_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            BatTatChucNang(false);
            LoadData();

            if (_vaiTro == VaiTroNguoiDung.NhanVienBanHang)
            {
                btnXoa.Enabled = false;
                btnXoa.Text = "Xóa (Không quyền)";
            }
            else
            {
                btnXoa.Text = "Xóa (YC mật khẩu Admin)";
            }
        }

        private void CauHinhLuoi()
        {
            dgvLoaiDongHo.AutoGenerateColumns = false;
            dgvLoaiDongHo.MultiSelect = false;
            dgvLoaiDongHo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiDongHo.ReadOnly = true;
            dgvLoaiDongHo.DataSource = bindingSource;

            // Ẩn/bỏ cột số lượng sản phẩm theo yêu cầu hiển thị.
            if (dgvLoaiDongHo.Columns.Contains("colSoLuongSanPham"))
            {
                dgvLoaiDongHo.Columns.Remove("colSoLuongSanPham");
            }
        }

        private void BatTatChucNang(bool dangNhapLieu)
        {
            btnLuu.Enabled = dangNhapLieu;
            btnHuy.Enabled = dangNhapLieu;

            txtTenLoai.Enabled = dangNhapLieu;

            // ID tự sinh từ database nên không cho nhập tay để tránh lệch dữ liệu
            txtMaLoai.Enabled = false;

            btnThem.Enabled = !dangNhapLieu;
            btnSua.Enabled = !dangNhapLieu;
            btnXoa.Enabled = !dangNhapLieu && _vaiTro != VaiTroNguoiDung.NhanVienBanHang;
            btnLamMoi.Enabled = !dangNhapLieu;
            btnTimKiem.Enabled = !dangNhapLieu;
            txtTimKiem.Enabled = !dangNhapLieu;
            dgvLoaiDongHo.Enabled = !dangNhapLieu;
        }

        private void LoadData(string tuKhoa = "")
        {
            try
            {
                var query = context.LoaiDongHo
                    .AsNoTracking()
                    .Select(loai => new LoaiDongHoViewModel
                    {
                        ID = loai.ID,
                        TenLoai = loai.TenLoai
                    });

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    var q = tuKhoa.Trim();
                    query = query.Where(x =>
                        EF.Functions.Like(x.TenLoai, $"%{q}%") ||
                        x.ID.ToString().Contains(q));
                }

                var list = query
                    .OrderBy(x => x.ID)
                    .ToList();

                bindingSource.DataSource = list;
                bindingSource.ResetBindings(false);

                HienThiDongDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu loại đồng hồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDongDangChon()
        {
            if (bindingSource.Current is not LoaiDongHoViewModel loaiDangChon)
            {
                txtMaLoai.Text = string.Empty;
                txtTenLoai.Text = string.Empty;
                return;
            }

            txtMaLoai.Text = loaiDangChon.ID.ToString();
            txtTenLoai.Text = loaiDangChon.TenLoai;
        }

        private void dgvLoaiDongHo_SelectionChanged(object sender, EventArgs e)
        {
            if (btnLuu.Enabled) return;
            HienThiDongDangChon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            idDangSua = 0;

            BatTatChucNang(true);
            txtMaLoai.Text = "(Tự sinh)";
            txtTenLoai.Text = string.Empty;
            txtTenLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not LoaiDongHoViewModel loaiDangChon)
            {
                MessageBox.Show("Vui lòng chọn loại đồng hồ cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            xuLyThem = false;
            idDangSua = loaiDangChon.ID;

            BatTatChucNang(true);
            txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_vaiTro == VaiTroNguoiDung.NhanVienBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng không có quyền xóa loại đồng hồ.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!AppSession.YeuCauXacNhanMatKhauAdmin(this))
            {
                MessageBox.Show("Mật khẩu Admin không đúng hoặc bạn đã hủy xác nhận. Không thể xóa loại đồng hồ.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bindingSource.Current is not LoaiDongHoViewModel loaiDangChon)
            {
                MessageBox.Show("Vui lòng chọn loại đồng hồ cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = loaiDangChon.ID;
            var tenLoai = loaiDangChon.TenLoai;

            var xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa loại đồng hồ '{tenLoai}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                var soSanPhamDangDung = context.SanPham.Count(x => x.LoaiDongHo != null && x.LoaiDongHo.ID == id);
                if (soSanPhamDangDung > 0)
                {
                    MessageBox.Show("Không thể xóa vì vẫn còn sản phẩm đang thuộc loại này.", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var loai = context.LoaiDongHo.Find(id);
                if (loai == null)
                {
                    MessageBox.Show("Loại đồng hồ không tồn tại hoặc đã bị xóa trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtTimKiem.Text);
                    return;
                }

                context.LoaiDongHo.Remove(loai);
                context.SaveChanges();

                MessageBox.Show("Đã xóa loại đồng hồ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại đồng hồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var tenLoai = txtTenLoai.Text.Trim();
            if (!KiemTraTenLoaiHopLe(tenLoai))
            {
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    if (DaTonTaiTenLoai(tenLoai))
                    {
                        MessageBox.Show("Tên loại đồng hồ đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenLoai.Focus();
                        return;
                    }

                    ThemLoaiDongHo(tenLoai);
                    MessageBox.Show("Thêm loại đồng hồ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!CapNhatLoaiDongHo(idDangSua, tenLoai))
                    {
                        return;
                    }

                    MessageBox.Show("Cập nhật loại đồng hồ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                KetThucNhapLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu loại đồng hồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KetThucNhapLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (btnLuu.Enabled) return;
            LoadData(txtTimKiem.Text);
        }

        private bool KiemTraTenLoaiHopLe(string tenLoai)
        {
            if (!string.IsNullOrWhiteSpace(tenLoai))
            {
                return true;
            }

            MessageBox.Show("Vui lòng nhập tên loại đồng hồ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtTenLoai.Focus();
            return false;
        }

        private bool DaTonTaiTenLoai(string tenLoai, int? boQuaId = null)
        {
            var tenLoaiChuan = tenLoai.Trim().ToLower();
            var query = context.LoaiDongHo.AsNoTracking();

            if (boQuaId.HasValue)
            {
                query = query.Where(x => x.ID != boQuaId.Value);
            }

            return query.Any(x => x.TenLoai.ToLower() == tenLoaiChuan);
        }

        private void ThemLoaiDongHo(string tenLoai)
        {
            var loaiMoi = new LoaiDongHo
            {
                TenLoai = tenLoai
            };

            context.LoaiDongHo.Add(loaiMoi);
            context.SaveChanges();
        }

        private bool CapNhatLoaiDongHo(int id, string tenLoai)
        {
            var loai = context.LoaiDongHo.Find(id);
            if (loai == null)
            {
                MessageBox.Show("Không tìm thấy loại đồng hồ để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (DaTonTaiTenLoai(tenLoai, id))
            {
                MessageBox.Show("Tên loại đồng hồ đã tồn tại ở bản ghi khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoai.Focus();
                return false;
            }

            loai.TenLoai = tenLoai;
            context.SaveChanges();
            return true;
        }

        private void KetThucNhapLieu()
        {
            xuLyThem = false;
            idDangSua = 0;
            BatTatChucNang(false);
            LoadData(txtTimKiem.Text);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
