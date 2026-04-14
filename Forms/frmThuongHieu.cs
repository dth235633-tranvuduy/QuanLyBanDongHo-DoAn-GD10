using System;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmThuongHieu : Form
    {
        // EF DbContext
        private QLBHDbContext context = new QLBHDbContext();
        private BindingSource binding = new BindingSource();
        private bool xuLyThem = false; // adding?
        private int id; // selected ID for edit/delete
        private readonly VaiTroNguoiDung _vaiTro;

        private bool LaBanHang => _vaiTro == VaiTroNguoiDung.NhanVienBanHang;

        public frmThuongHieu(VaiTroNguoiDung? vaiTro = null)
        {
            InitializeComponent();
            _vaiTro = vaiTro ?? AppSession.VaiTro;

            // setup events
            this.Load += FrmThuongHieu_Load;

            dgvThuongHieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuongHieu.MultiSelect = false;
            dgvThuongHieu.AllowUserToAddRows = false;

            // bind columns if exist - use names from designer (colId, colTen, colQuocGia)
            if (dgvThuongHieu.Columns.Contains("colId")) dgvThuongHieu.Columns["colId"].DataPropertyName = "ID";
            if (dgvThuongHieu.Columns.Contains("colTen")) dgvThuongHieu.Columns["colTen"].DataPropertyName = "TenThuongHieu";
            // colQuocGia has no matching property in model; leave it blank or show an empty value

            dgvThuongHieu.DataSource = binding;

            // wire search button
            btnTim.Click += BtnTim_Click;
        }

        private void FrmThuongHieu_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();

            if (LaBanHang)
            {
                btnXoa.Enabled = false;
                btnXoa.Text = "Xóa (Không quyền)";
            }
            else
            {
                btnXoa.Text = "Xóa (YC mật khẩu Admin)";
            }

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", binding, "TenThuongHieu", false, DataSourceUpdateMode.Never);
        }

        private void LoadData()
        {
            LoadData(null);
        }

        private void LoadData(string q)
        {
            var query = context.ThuongHieu.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(h => h.TenThuongHieu.Contains(q));
            }
            var list = query.ToList();
            binding.DataSource = list;
            binding.ResetBindings(false);
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri; // designer uses btnHuy
            txtTen.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri && !LaBanHang;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTen.DataBindings.Clear();
            txtTen.Text = string.Empty;
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (binding.Current == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            var cur = binding.Current as ThuongHieu;
            if (cur != null) id = cur.ID;

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", binding, "TenThuongHieu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var name = txtTen.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên thương hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return;
            }

            if (xuLyThem)
            {
                var th = new ThuongHieu { TenThuongHieu = name };
                context.ThuongHieu.Add(th);
                context.SaveChanges();
            }
            else
            {
                var th = context.ThuongHieu.Find(id);
                if (th != null)
                {
                    th.TenThuongHieu = name;
                    context.ThuongHieu.Update(th);
                    context.SaveChanges();
                }
            }

            // reload bindings
            LoadData();
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", binding, "TenThuongHieu", false, DataSourceUpdateMode.Never);

            BatTatChucNang(false);
            xuLyThem = false;
            id = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng không có quyền xóa thương hiệu.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!AppSession.YeuCauXacNhanMatKhauAdmin(this))
            {
                MessageBox.Show("Mật khẩu Admin không đúng hoặc bạn đã hủy xác nhận. Không thể xóa thương hiệu.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Lấy đối tượng hiện tại và ép kiểu về ThuongHieu
            var cur = binding.Current as ThuongHieu;
            if (cur == null) return;

            // 2. Hiện thông báo có tên thương hiệu cụ thể để người dùng dễ nhận biết
            string message = $"Bạn có chắc chắn muốn xóa thương hiệu '{cur.TenThuongHieu}' không?";
            if (MessageBox.Show(message, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // 3. Tìm trong database và thực hiện xóa
                var th = context.ThuongHieu.Find(cur.ID);
                if (th != null)
                {
                    context.ThuongHieu.Remove(th);
                    context.SaveChanges();

                    MessageBox.Show("Đã xóa xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Load lại dữ liệu để cập nhật Grid
                    LoadData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa thương hiệu này vì đã có Sản phẩm thuộc về nó!\nHãy xóa sản phẩm trước khi xóa thương hiệu.",
                                "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên thương hiệu để tìm:", "Tìm thương hiệu", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                LoadData(input.Trim());
            }
            else
            {
                LoadData(null);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", binding, "TenThuongHieu", false, DataSourceUpdateMode.Never);
            BatTatChucNang(false);
            xuLyThem = false;
            id = 0;
            LoadData();
        }
    }
}
