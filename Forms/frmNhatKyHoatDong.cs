using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmNhatKyHoatDong : Form
    {
        private sealed class NhatKyHoatDongVm
        {
            public string ThoiGian { get; set; } = string.Empty;
            public string NhanVien { get; set; } = string.Empty;
            public string VaiTro { get; set; } = string.Empty;
            public string HanhDong { get; set; } = string.Empty;
            public string ChiTiet { get; set; } = string.Empty;
        }

        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _uiBuilt;

        private readonly Panel _panelFilter = new Panel();
        private readonly Label _lblFilter = new Label();
        private readonly DateTimePicker _dtpNgay = new DateTimePicker();
        private readonly ComboBox _cboNhanVien = new ComboBox();
        private readonly Button _btnTruyVan = new Button();

        private readonly Label _lblTitle = new Label();
        private readonly Label _lblTong = new Label();
        private readonly DataGridView _dgv = new DataGridView();

        private static bool IsDesignTimeMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public frmNhatKyHoatDong()
        {
            InitializeComponent();

            Text = "Lịch sử hoạt động hệ thống";
            BackColor = Color.FromArgb(243, 246, 251);

            EnsureUiBuilt();

            Load += FrmNhatKyHoatDong_Load;
            Resize += (_, _) => ApplyResponsiveLayout();
            _btnTruyVan.Click += (_, _) => TaiNhatKyHoatDong();
            _dtpNgay.ValueChanged += (_, _) =>
            {
                if (_dtpNgay.Checked)
                {
                    TaiNhatKyHoatDong();
                }
            };
            _cboNhanVien.SelectedIndexChanged += (_, _) =>
            {
                if (IsHandleCreated)
                {
                    TaiNhatKyHoatDong();
                }
            };
        }

        private void EnsureUiBuilt()
        {
            if (_uiBuilt) return;
            BuildUi();

            if (IsDesignTimeMode)
            {
                CauHinhLuoi();
                _lblTong.Text = "Tổng bản ghi: 1";
                _bindingSource.DataSource = new List<NhatKyHoatDongVm>
                {
                    new NhatKyHoatDongVm
                    {
                        ThoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                        NhanVien = "Nhân viên mẫu",
                        VaiTro = "Admin",
                        HanhDong = "Xem thống kê",
                        ChiTiet = "Dữ liệu minh họa trong Designer"
                    }
                };
            }

            _uiBuilt = true;
        }

        private void FrmNhatKyHoatDong_Load(object? sender, EventArgs e)
        {
            if (IsDesignTimeMode)
            {
                ApplyResponsiveLayout();
                return;
            }

            if (AppSession.VaiTro != VaiTroNguoiDung.Admin)
            {
                MessageBox.Show("Bạn không có quyền xem nhật ký hoạt động.",
                    "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ActivityLogger.DamBaoBangNhatKyTonTai(_context);
            NapBoLocNhanVien();
            CauHinhLuoi();
            TaiNhatKyHoatDong();
            ApplyResponsiveLayout();
        }

        private void BuildUi()
        {
            _lblTitle.Text = "Nhật ký hoạt động tài khoản";
            _lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            _lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            _lblTitle.AutoSize = true;
            _lblTitle.Location = new Point(20, 16);

            _panelFilter.BackColor = Color.White;
            _panelFilter.Height = 74;
            _panelFilter.Padding = new Padding(16, 14, 16, 14);

            _lblFilter.Text = "LỌC THEO:";
            _lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblFilter.AutoSize = true;
            _lblFilter.Location = new Point(18, 24);

            _dtpNgay.Format = DateTimePickerFormat.Custom;
            _dtpNgay.CustomFormat = "dd/MM/yyyy";
            _dtpNgay.ShowCheckBox = true;
            _dtpNgay.Checked = false;
            _dtpNgay.Size = new Size(160, 31);
            _dtpNgay.Location = new Point(120, 20);

            _cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboNhanVien.Size = new Size(250, 33);
            _cboNhanVien.Location = new Point(294, 20);

            _btnTruyVan.Text = "TRUY VẤN";
            _btnTruyVan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _btnTruyVan.BackColor = Color.FromArgb(30, 41, 59);
            _btnTruyVan.ForeColor = Color.White;
            _btnTruyVan.FlatStyle = FlatStyle.Flat;
            _btnTruyVan.FlatAppearance.BorderSize = 0;
            _btnTruyVan.Size = new Size(130, 36);

            _lblTong.AutoSize = true;
            _lblTong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblTong.ForeColor = Color.FromArgb(59, 130, 246);

            _dgv.Dock = DockStyle.Fill;
            _dgv.BackgroundColor = Color.White;
            _dgv.BorderStyle = BorderStyle.None;
            _dgv.AllowUserToAddRows = false;
            _dgv.AllowUserToDeleteRows = false;
            _dgv.AllowUserToResizeRows = false;
            _dgv.MultiSelect = false;
            _dgv.ReadOnly = true;
            _dgv.RowHeadersVisible = false;
            _dgv.AutoGenerateColumns = false;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.EnableHeadersVisualStyles = false;
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            _dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            _dgv.RowTemplate.Height = 34;
            _dgv.DataSource = _bindingSource;
            _dgv.CellFormatting += Dgv_CellFormatting;

            _panelFilter.Controls.Add(_lblFilter);
            _panelFilter.Controls.Add(_dtpNgay);
            _panelFilter.Controls.Add(_cboNhanVien);
            _panelFilter.Controls.Add(_btnTruyVan);

            Controls.Add(_dgv);
            Controls.Add(_lblTong);
            Controls.Add(_panelFilter);
            Controls.Add(_lblTitle);
        }

        private void CauHinhLuoi()
        {
            _dgv.Columns.Clear();

            _dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThoiGian",
                HeaderText = "Thời gian",
                DataPropertyName = nameof(NhatKyHoatDongVm.ThoiGian),
                FillWeight = 18
            });

            _dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNhanVien",
                HeaderText = "Nhân viên",
                DataPropertyName = nameof(NhatKyHoatDongVm.NhanVien),
                FillWeight = 18
            });

            _dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVaiTro",
                HeaderText = "Quyền",
                DataPropertyName = nameof(NhatKyHoatDongVm.VaiTro),
                FillWeight = 18
            });

            _dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHanhDong",
                HeaderText = "Hành động",
                DataPropertyName = nameof(NhatKyHoatDongVm.HanhDong),
                FillWeight = 18
            });

            _dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChiTiet",
                HeaderText = "Chi tiết nội dung",
                DataPropertyName = nameof(NhatKyHoatDongVm.ChiTiet),
                FillWeight = 28
            });
        }

        private void NapBoLocNhanVien()
        {
            var dsNhanVien = _context.NhatKyHoatDong
                .AsNoTracking()
                .Where(x => !string.IsNullOrWhiteSpace(x.TenNhanVien))
                .Select(x => x.TenNhanVien)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var source = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(string.Empty, "Tất cả nhân viên")
            };

            source.AddRange(dsNhanVien.Select(x => new KeyValuePair<string, string>(x, x)));

            _cboNhanVien.DataSource = source;
            _cboNhanVien.DisplayMember = "Value";
            _cboNhanVien.ValueMember = "Key";
        }

        private void TaiNhatKyHoatDong()
        {
            var query = _context.NhatKyHoatDong.AsNoTracking().AsQueryable();

            if (_dtpNgay.Checked)
            {
                var tuNgay = _dtpNgay.Value.Date;
                var denNgay = tuNgay.AddDays(1);
                query = query.Where(x => x.ThoiGian >= tuNgay && x.ThoiGian < denNgay);
            }

            if (_cboNhanVien.SelectedValue is string tenNhanVien && !string.IsNullOrWhiteSpace(tenNhanVien))
            {
                query = query.Where(x => x.TenNhanVien == tenNhanVien);
            }

            var duLieuRaw = query
                .OrderByDescending(x => x.ThoiGian)
                .Take(500)
                .Select(x => new
                {
                    x.ThoiGian,
                    x.TenDangNhap,
                    x.TenNhanVien,
                    x.VaiTro,
                    x.HanhDong,
                    x.ChiTiet
                })
                .ToList();

            var culture = CultureInfo.GetCultureInfo("vi-VN");
            var ds = duLieuRaw
                .Select(x => new NhatKyHoatDongVm
                {
                    ThoiGian = x.ThoiGian.ToString("dd/MM/yyyy HH:mm", culture),
                    NhanVien = string.IsNullOrWhiteSpace(x.TenNhanVien) ? x.TenDangNhap : x.TenNhanVien,
                    VaiTro = string.IsNullOrWhiteSpace(x.VaiTro) ? "Nhân viên" : x.VaiTro,
                    HanhDong = x.HanhDong,
                    ChiTiet = x.ChiTiet
                })
                .ToList();

            _bindingSource.DataSource = ds;
            _lblTong.Text = $"Tổng bản ghi: {ds.Count:N0}";

            if (_cboNhanVien.Items.Count == 0)
            {
                NapBoLocNhanVien();
            }
        }

        private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgv.Columns[e.ColumnIndex].Name != "colHanhDong" || e.Value is not string hanhDong)
            {
                return;
            }

            var h = hanhDong.Trim().ToLowerInvariant();
            if (h.Contains("xóa") || h.Contains("xoa"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (h.Contains("sửa") || h.Contains("sua"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (h.Contains("thanh toán") || h.Contains("thanh toan"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void ApplyResponsiveLayout()
        {
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;

            _lblTitle.Location = new Point(20, 12);

            _panelFilter.SetBounds(20, 48, ClientSize.Width - 40, 74);
            _btnTruyVan.Location = new Point(_panelFilter.ClientSize.Width - _btnTruyVan.Width - 16, 19);

            _lblTong.Location = new Point(20, 132);

            _dgv.Location = new Point(20, 160);
            _dgv.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 174);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
