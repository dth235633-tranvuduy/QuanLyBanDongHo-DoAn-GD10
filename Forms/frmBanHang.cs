using System.Data;
using System.Globalization;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmBanHang : Form
    {
        private sealed class SanPhamBanHangVm
        {
            public int ID { get; set; }
            public int STT { get; set; }
            public string TenDongHo { get; set; } = string.Empty;
            public string ThuongHieu { get; set; } = string.Empty;
            public int GiaBan { get; set; }
            public string GiaBanHienThi => GiaBan.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            public Image? AnhDaiDien { get; set; }
            public string KieuDang { get; set; } = string.Empty;
            public string LoaiDay { get; set; } = string.Empty;
            public string KichThuocMat { get; set; } = string.Empty;
            public string LoaiDongHo { get; set; } = string.Empty;
            public string DoChiuNuoc { get; set; } = string.Empty;
            public int SoLuongTon { get; set; }
        }

        private sealed class KhachHangLuaChonVm
        {
            public int? ID { get; set; }
            public string HoVaTen { get; set; } = string.Empty;
            public string? DienThoai { get; set; }
            public bool LaKhachMoi { get; set; }
            public bool LaVangLai { get; set; }

            public string HienThi => HoVaTen;
        }

        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly BindingSource _productsBs = new BindingSource();
        private readonly BindingSource _cartBs = new BindingSource();
        private readonly string _thuMucAnh = Path.Combine(Application.StartupPath, "Images");
        private readonly bool _cheDoChonSanPhamChoHoaDon;

        private int? _nhanVienDangNhapId;
        private long _giamGia;
        private bool _dangDongForm;

        public frmBanHang(bool cheDoChonSanPhamChoHoaDon = false)
        {
            InitializeComponent();
            _cheDoChonSanPhamChoHoaDon = cheDoChonSanPhamChoHoaDon;

            Load += FrmBanHang_Load;
            FormClosing += FrmBanHang_FormClosing;
            FormClosed += FrmBanHang_FormClosed;
            Resize += FrmBanHang_Resize;

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            txtKhachHangPhone.KeyDown += txtKhachHangPhone_KeyDown;
            txtKhachHangPhone.Leave += txtKhachHangPhone_Leave;
            txtKhachHangPhone.TextChanged += txtKhachHangPhone_TextChanged;

            lblGiamGiaValue.DoubleClick += lblGiamGiaValue_DoubleClick;
        }

        private void FrmBanHang_Load(object? sender, EventArgs e)
        {
            CauHinhLuoiSanPham();
            CauHinhLuoiGioHang();

            TaiSanPham();
            HienThiKhachHangVangLai();
            HienThiNhanVienDangNhap();
            XoaTrangThongTinSanPham();

            NapGioHangTuPhienLamHoaDon();
            btnCheckout.Text = _cheDoChonSanPhamChoHoaDon ? "Tiếp tục lập hóa đơn" : "Chuyển sang hóa đơn";

            CapNhatTongTien();
            ApplyResponsiveLayout();
        }

        private void FrmBanHang_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            SuspendLayout();

            // Không ép TopLevel/FormBorderStyle/Dock tại đây.
            // Trường hợp mở trong panel (Trang chủ) đã được form cha cấu hình.
            // Trường hợp mở dialog từ frmHoaDon cần giữ TopLevel=true.

            // Lưới sản phẩm: luôn giãn full groupbox, chừa đáy cho nút thêm
            LayoutProductsPanel();

            // Khung thông tin sản phẩm ở giữa
            LayoutProductInfoPanel();

            // Giỏ hàng bên phải
            LayoutCartPanel();

            ResumeLayout();
        }

        private void LayoutProductsPanel()
        {
            const int padding = 14;
            const int headerOffset = 40;
            const int bottomBarHeight = 44;
            const int spacing = 8;

            var gridWidth = Math.Max(200, grpProducts.ClientSize.Width - (padding * 2));
            var gridHeight = Math.Max(120, grpProducts.ClientSize.Height - headerOffset - bottomBarHeight - spacing - 8);

            dgvProducts.Location = new Point(padding, headerOffset);
            dgvProducts.Size = new Size(gridWidth, gridHeight);
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            var yBottom = dgvProducts.Bottom + spacing;

            btnAdd.Size = new Size(140, 34);
            btnAdd.Location = new Point(grpProducts.ClientSize.Width - padding - btnAdd.Width, yBottom);
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            nudQuantity.Size = new Size(90, 31);
            nudQuantity.Location = new Point(btnAdd.Left - 8 - nudQuantity.Width, yBottom + 1);
            nudQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            lblSoLuong.Location = new Point(nudQuantity.Left - 78, yBottom + 4);
            lblSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void LayoutProductInfoPanel()
        {
            const int padding = 16;
            const int labelWidth = 110;
            const int textHeight = 31;
            const int rowGap = 12;

            var contentWidth = Math.Max(140, groupBox1.ClientSize.Width - (padding * 2));
            var picHeight = Math.Min(230, Math.Max(170, groupBox1.ClientSize.Height / 3));

            picHinhAnh.Location = new Point(padding, 36);
            picHinhAnh.Size = new Size(contentWidth, picHeight);
            picHinhAnh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            var inputX = padding + labelWidth;
            var inputWidth = Math.Max(80, contentWidth - labelWidth);
            var y = picHinhAnh.Bottom + 16;

            lblThuongHieu.Location = new Point(padding, y + 4);
            textBox5.Location = new Point(inputX, y);
            textBox5.Size = new Size(inputWidth, textHeight);

            y += textHeight + rowGap;
            lblLoaiDay.Location = new Point(padding, y + 4);
            textBox2.Location = new Point(inputX, y);
            textBox2.Size = new Size(inputWidth, textHeight);

            y += textHeight + rowGap;
            lblKichThuocMat.Location = new Point(padding, y + 4);
            textBox3.Location = new Point(inputX, y);
            textBox3.Size = new Size(inputWidth, textHeight);

            y += textHeight + rowGap;
            lblLoaiDongHo.Location = new Point(padding, y + 4);
            textBox1.Location = new Point(inputX, y);
            textBox1.Size = new Size(inputWidth, textHeight);

            y += textHeight + rowGap;
            lblDoChiuNuoc.Location = new Point(padding, y + 4);
            textBox4.Location = new Point(inputX, y);
            textBox4.Size = new Size(inputWidth, textHeight);

            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void LayoutCartPanel()
        {
            const int padding = 14;
            const int headerOffset = 37;
            const int spacing = 8;
            const int removeHeight = 34;
            const int summaryHeight = 132;
            const int checkoutHeight = 36;

            var width = Math.Max(180, grpCart.ClientSize.Width - (padding * 2));

            btnCheckout.Size = new Size(width, checkoutHeight);
            btnCheckout.Location = new Point(padding, grpCart.ClientSize.Height - padding - checkoutHeight);

            pnlSummary.Size = new Size(width, summaryHeight);
            pnlSummary.Location = new Point(padding, btnCheckout.Top - spacing - summaryHeight);

            btnRemove.Size = new Size(width, removeHeight);
            btnRemove.Location = new Point(padding, pnlSummary.Top - spacing - removeHeight);

            var gridHeight = Math.Max(100, btnRemove.Top - spacing - headerOffset);
            dgvCart.Location = new Point(padding, headerOffset);
            dgvCart.Size = new Size(width, gridHeight);

            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FrmBanHang_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _dangDongForm = true;
            _context.Dispose();
        }

        private void FrmBanHang_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _dangDongForm = true;
        }

        private void CauHinhLuoiSanPham()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStt",
                HeaderText = "STT",
                DataPropertyName = nameof(SanPhamBanHangVm.STT),
                FillWeight = 50
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTen",
                HeaderText = "Tên đồng hồ",
                DataPropertyName = nameof(SanPhamBanHangVm.TenDongHo),
                FillWeight = 180
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThuongHieu",
                HeaderText = "Thương hiệu",
                DataPropertyName = nameof(SanPhamBanHangVm.ThuongHieu),
                FillWeight = 120
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGia",
                HeaderText = "Giá bán",
                DataPropertyName = nameof(SanPhamBanHangVm.GiaBanHienThi),
                FillWeight = 110
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKieuDang",
                HeaderText = "Kiểu dáng",
                DataPropertyName = nameof(SanPhamBanHangVm.KieuDang),
                FillWeight = 100
            });

            dgvProducts.DataSource = _productsBs;
        }

        private void CauHinhLuoiGioHang()
        {
            var table = new DataTable();
            table.Columns.Add("SanPhamID", typeof(int));
            table.Columns.Add("TenSanPham", typeof(string));
            table.Columns.Add("DonGia", typeof(int));
            table.Columns.Add("SoLuong", typeof(int));
            table.Columns.Add("ThanhTien", typeof(long), "DonGia * SoLuong");

            _cartBs.DataSource = table;
            dgvCart.DataSource = _cartBs;

            // Cho phép tick checkbox (Designer đang để ReadOnly=true)
            dgvCart.ReadOnly = false;

            EnsureCheckboxColumn(dgvCart);

            if (dgvCart.Columns.Contains("SanPhamID"))
            {
                dgvCart.Columns["SanPhamID"].Visible = false;
                dgvCart.Columns["SanPhamID"].ReadOnly = true;
            }

            if (dgvCart.Columns.Contains("DonGia"))
            {
                dgvCart.Columns["DonGia"].Visible = false;
                dgvCart.Columns["DonGia"].ReadOnly = true;
            }

            if (dgvCart.Columns.Contains("TenSanPham"))
            {
                dgvCart.Columns["TenSanPham"].HeaderText = "Sản phẩm";
                dgvCart.Columns["TenSanPham"].ReadOnly = true;
            }

            if (dgvCart.Columns.Contains("SoLuong"))
            {
                dgvCart.Columns["SoLuong"].HeaderText = "SL";
                dgvCart.Columns["SoLuong"].ReadOnly = true;
            }

            if (dgvCart.Columns.Contains("ThanhTien"))
            {
                dgvCart.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvCart.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvCart.Columns["ThanhTien"].ReadOnly = true;
            }

            dgvCart.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCart.CurrentCellDirtyStateChanged -= dgvCart_CurrentCellDirtyStateChanged;
            dgvCart.CurrentCellDirtyStateChanged += dgvCart_CurrentCellDirtyStateChanged;
        }

        private void TaiSanPham(string? tuKhoa = null)
        {
            var q = (tuKhoa ?? string.Empty).Trim().ToLower();

            var query = _context.SanPham
                .Include(x => x.ThuongHieu)
                .Include(x => x.LoaiDongHo)
                .Include(x => x.ThongSoKyThuat)
                    .ThenInclude(t => t.LoaiDongHo)
                .AsNoTracking()
                .AsQueryable();

            var entities = query
                .OrderBy(x => x.ID)
                .ToList();

            var ds = entities
                .Select((x, idx) =>
                {
                    var ts = x.ThongSoKyThuat.FirstOrDefault();
                    return new SanPhamBanHangVm
                    {
                        ID = x.ID,
                        STT = idx + 1,
                        TenDongHo = x.TenSanPham,
                        ThuongHieu = x.ThuongHieu.TenThuongHieu,
                        GiaBan = x.DonGia,
                        KieuDang = x.KieuDang,
                        SoLuongTon = x.SoLuong,
                        LoaiDongHo = ts?.LoaiDongHo?.TenLoai ?? x.LoaiDongHo?.TenLoai ?? string.Empty,
                        LoaiDay = ts?.LoaiDay ?? string.Empty,
                        KichThuocMat = ts?.KichThuocMat ?? string.Empty,
                        DoChiuNuoc = ts?.DoChiuNuoc ?? string.Empty,
                        AnhDaiDien = TaiAnhThuNho(x.HinhAnh)
                    };
                })
                .ToList();

            if (!string.IsNullOrWhiteSpace(q))
            {
                ds = ds.Where(x =>
                        x.ID.ToString().Contains(q) ||
                        x.STT.ToString().Contains(q) ||
                        x.TenDongHo.ToLower().Contains(q) ||
                        x.ThuongHieu.ToLower().Contains(q) ||
                        x.GiaBan.ToString().Contains(q) ||
                        x.GiaBanHienThi.ToLower().Contains(q) ||
                        x.KieuDang.ToLower().Contains(q) ||
                        x.LoaiDongHo.ToLower().Contains(q) ||
                        x.LoaiDay.ToLower().Contains(q) ||
                        x.KichThuocMat.ToLower().Contains(q) ||
                        x.DoChiuNuoc.ToLower().Contains(q) ||
                        x.SoLuongTon.ToString().Contains(q))
                    .ToList();
            }

            _productsBs.DataSource = ds;
        }

        private Image? TaiAnhThuNho(string? tenAnh)
        {
            if (string.IsNullOrWhiteSpace(tenAnh)) return null;
            try
            {
                var fullPath = Path.Combine(_thuMucAnh, tenAnh);
                if (!File.Exists(fullPath)) return null;

                using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var src = Image.FromStream(fs);
                return new Bitmap(src, new Size(64, 64));
            }
            catch
            {
                return null;
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            TaiSanPham(txtSearch.Text);
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not SanPhamBanHangVm sp)
            {
                XoaTrangThongTinSanPham();
                return;
            }

            textBox5.Text = sp.ThuongHieu;
            textBox2.Text = sp.LoaiDay;
            textBox3.Text = sp.KichThuocMat;
            textBox1.Text = sp.LoaiDongHo;
            textBox4.Text = sp.DoChiuNuoc;
            picHinhAnh.Image = sp.AnhDaiDien != null ? new Bitmap(sp.AnhDaiDien) : null;
        }

        private void XoaTrangThongTinSanPham()
        {
            textBox5.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
            picHinhAnh.Image = null;
        }

        private void txtKhachHangPhone_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TraCuuKhachHangTheoSoDienThoai();
        }

        private void txtKhachHangPhone_TextChanged(object? sender, EventArgs e)
        {
            GioiHanNhapSoDienThoai(txtKhachHangPhone);
        }

        private static void GioiHanNhapSoDienThoai(TextBox textBox)
        {
            var original = textBox.Text;
            var filtered = new string(original.Where(char.IsDigit).Take(10).ToArray());
            if (original == filtered) return;

            var oldSelectionStart = textBox.SelectionStart;
            textBox.Text = filtered;
            textBox.SelectionStart = Math.Min(oldSelectionStart, textBox.Text.Length);
        }

        private void txtKhachHangPhone_Leave(object? sender, EventArgs e)
        {
            TraCuuKhachHangTheoSoDienThoai();
        }

        private void TraCuuKhachHangTheoSoDienThoai()
        {
            if (_dangDongForm || IsDisposed)
            {
                return;
            }

            var sdt = ChuanHoaDienThoai(txtKhachHangPhone.Text);

            if (string.IsNullOrWhiteSpace(sdt))
            {
                HienThiKhachHangVangLai();
                return;
            }

            var kh = _context.KhachHang
                .AsNoTracking()
                .FirstOrDefault(x => x.DienThoai != null && x.DienThoai.Trim() == sdt);

            if (kh != null)
            {
                HienThiLuaChonKhachHang(new KhachHangLuaChonVm
                {
                    ID = kh.ID,
                    HoVaTen = kh.HoVaTen,
                    DienThoai = kh.DienThoai
                });
                return;
            }

            HienThiLuaChonKhachHang(new KhachHangLuaChonVm
            {
                ID = null,
                HoVaTen = "Khách hàng mới",
                DienThoai = sdt,
                LaKhachMoi = true
            });
        }

        private static string ChuanHoaDienThoai(string? input)
        {
            return new string((input ?? string.Empty).Where(char.IsDigit).ToArray());
        }

        private void HienThiKhachHangVangLai()
        {
            HienThiLuaChonKhachHang(new KhachHangLuaChonVm
            {
                ID = null,
                HoVaTen = "Khách hàng vãng lai",
                LaVangLai = true
            });
        }

        private void HienThiLuaChonKhachHang(KhachHangLuaChonVm luaChon)
        {
            cboKhachHang.DisplayMember = nameof(KhachHangLuaChonVm.HienThi);
            cboKhachHang.ValueMember = nameof(KhachHangLuaChonVm.ID);
            cboKhachHang.DataSource = new List<KhachHangLuaChonVm> { luaChon };
            cboKhachHang.SelectedIndex = 0;
        }

        private KhachHangLuaChonVm LayKhachHangDangChon()
        {
            if (cboKhachHang.SelectedItem is KhachHangLuaChonVm kh)
            {
                return kh;
            }

            return new KhachHangLuaChonVm { HoVaTen = "Khách hàng vãng lai", LaVangLai = true };
        }

        private void HienThiNhanVienDangNhap()
        {
            var tenDangNhap = AppSession.TenDangNhap?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                lblNhanVien.Text = "NV bán: ---";
                _nhanVienDangNhapId = null;
                return;
            }

            var nv = _context.NhanVien
                .AsNoTracking()
                .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

            _nhanVienDangNhapId = nv?.ID;
            lblNhanVien.Text = "NV bán: " + (nv?.HoVaTen ?? tenDangNhap);
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not SanPhamBanHangVm sp)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var soLuongThem = (int)nudQuantity.Value;
            var table = GetCartTable();
            if (table == null)
            {
                MessageBox.Show("Không thể truy cập giỏ hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rowHienTai = table.Select($"SanPhamID = {sp.ID}").FirstOrDefault();
            var soLuongDangCo = rowHienTai != null ? Convert.ToInt32(rowHienTai["SoLuong"]) : 0;

            if (soLuongDangCo + soLuongThem > sp.SoLuongTon)
            {
                MessageBox.Show($"Số lượng tồn không đủ. Tồn kho hiện tại: {sp.SoLuongTon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rowHienTai != null)
            {
                rowHienTai["SoLuong"] = soLuongDangCo + soLuongThem;
            }
            else
            {
                table.Rows.Add(sp.ID, sp.TenDongHo, sp.GiaBan, soLuongThem);
            }

            CapNhatTongTien();
        }

        private void btnRemove_Click(object? sender, EventArgs e)
        {
            var table = GetCartTable();
            if (table == null || table.Rows.Count == 0) return;

            var coDongTick = false;
            for (var i = dgvCart.Rows.Count - 1; i >= 0; i--)
            {
                var isChecked = dgvCart.Rows[i].Cells["colChecked"].Value as bool? == true;
                if (!isChecked) continue;

                coDongTick = true;
                dgvCart.Rows.RemoveAt(i);
            }

            if (!coDongTick && dgvCart.CurrentRow != null)
            {
                dgvCart.Rows.Remove(dgvCart.CurrentRow);
            }

            CapNhatTongTien();
        }

        private void lblGiamGiaValue_DoubleClick(object? sender, EventArgs e)
        {
            var giaTri = HienThiNhapSoTien("Nhập số tiền giảm giá", "Giảm giá", _giamGia);
            if (giaTri == null) return;

            _giamGia = giaTri.Value;
            CapNhatTongTien();
        }

        private static long? HienThiNhapSoTien(string tieuDe, string nhan, long macDinh)
        {
            using var frm = new Form();
            using var lbl = new Label();
            using var txt = new TextBox();
            using var btnOk = new Button();
            using var btnCancel = new Button();

            frm.Text = tieuDe;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.ClientSize = new Size(420, 140);

            lbl.Text = nhan;
            lbl.Location = new Point(20, 20);
            lbl.Size = new Size(380, 24);

            txt.Location = new Point(20, 50);
            txt.Size = new Size(380, 31);
            txt.Text = macDinh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));

            btnOk.Text = "OK";
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(244, 95);

            btnCancel.Text = "Hủy";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(325, 95);

            frm.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            frm.AcceptButton = btnOk;
            frm.CancelButton = btnCancel;

            if (frm.ShowDialog() != DialogResult.OK) return null;

            var so = new string((txt.Text ?? string.Empty).Where(char.IsDigit).ToArray());
            return long.TryParse(so, out var value) ? value : null;
        }

        private void CapNhatTongTien()
        {
            var table = GetCartTable();
            if (table == null)
            {
                lblTamTinhValue.Text = "0 đ";
                lblGiamGiaValue.Text = "0 đ";
                lblTongValue.Text = "0 đ";
                return;
            }

            var tamTinh = table.Rows.Cast<DataRow>()
                .Sum(r => Convert.ToInt64(r["ThanhTien"]));

            if (_giamGia > tamTinh) _giamGia = tamTinh;
            var tong = tamTinh - _giamGia;

            lblTamTinhValue.Text = tamTinh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
            lblGiamGiaValue.Text = _giamGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
            lblTongValue.Text = tong.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }

        private void btnCheckout_Click(object? sender, EventArgs e)
        {
            var table = GetCartTable();
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm đã chọn đang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LuuGioHangVaoPhienLamHoaDon();

            if (_cheDoChonSanPhamChoHoaDon)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            using var frm = new frmHoaDon();
            frm.ShowDialog(this);
        }

        private void NapGioHangTuPhienLamHoaDon()
        {
            var draft = AppSession.HoaDonDangLap;
            if (draft == null)
            {
                return;
            }

            var table = GetCartTable();
            if (table == null)
            {
                return;
            }

            table.Rows.Clear();
            foreach (var item in draft.SanPhamDaChon)
            {
                table.Rows.Add(item.SanPhamID, item.TenSanPham, item.DonGia, item.SoLuong);
            }

            _giamGia = draft.GiamGia;
            txtKhachHangPhone.Text = draft.SoDienThoaiKhachHang;
            TraCuuKhachHangTheoSoDienThoai();
        }

        private void LuuGioHangVaoPhienLamHoaDon()
        {
            var table = GetCartTable();
            if (table == null)
            {
                return;
            }

            var draft = AppSession.HoaDonDangLap ?? new HoaDonDraftSession();
            draft.SanPhamDaChon = table.Rows.Cast<DataRow>()
                .Select(r => new GioHangItemSession
                {
                    SanPhamID = Convert.ToInt32(r["SanPhamID"]),
                    TenSanPham = Convert.ToString(r["TenSanPham"]) ?? string.Empty,
                    DonGia = Convert.ToInt32(r["DonGia"]),
                    SoLuong = Convert.ToInt32(r["SoLuong"])
                })
                .ToList();

            draft.SoDienThoaiKhachHang = ChuanHoaDienThoai(txtKhachHangPhone.Text);
            draft.GiamGia = _giamGia;
            AppSession.HoaDonDangLap = draft;
        }

        private void ResetSauThanhToan()
        {
            _giamGia = 0;

            var tableMoi = ((DataTable)_cartBs.List).Clone();
            _cartBs.DataSource = tableMoi;
            dgvCart.DataSource = _cartBs;
            EnsureCheckboxColumn(dgvCart);

            txtKhachHangPhone.Clear();
            HienThiKhachHangVangLai();
            TaiSanPham(txtSearch.Text);
            CapNhatTongTien();
        }

        private void EnsureCheckboxColumn(DataGridView dgv)
        {
            const string checkboxName = "colChecked";
            if (dgv.Columns.Contains(checkboxName))
            {
                dgv.Columns[checkboxName].ReadOnly = false;
                return;
            }

            var checkboxColumn = new DataGridViewCheckBoxColumn
            {
                Name = checkboxName,
                HeaderText = "✓",
                Width = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = false
            };

            dgv.Columns.Insert(0, checkboxColumn);
        }

        private void dgvCart_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvCart.IsCurrentCellDirty)
            {
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private ComboBox? GetKhachHangCombo()
        {
            return Controls.Find("cboKhachHang", true).FirstOrDefault() as ComboBox;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private DataTable? GetCartTable()
        {
            return _cartBs.DataSource switch
            {
                DataTable dt => dt,
                DataView dv => dv.Table,
                _ => null
            };
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {

        }
    }
}
