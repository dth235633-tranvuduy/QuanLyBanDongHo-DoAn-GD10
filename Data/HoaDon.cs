using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    public class HoaDon
    {
        public int ID { get; set; }
        public int? NhanVienID { get; set; }
        public int? KhachHangID { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public string? GhiChuHoaDon { get; set; }

        // --- Thuộc tính thêm mới để quản lý điểm ---

        /// <summary>
        /// Số điểm khách đã chọn sử dụng cho hóa đơn này
        /// </summary>
        public int DiemSuDung { get; set; } = 0;

        /// <summary>
        /// Số tiền thực tế được giảm (Quy đổi từ DiemSuDung)
        /// </summary>
        public decimal SoTienGiamDiem { get; set; } = 0;

        // Liên kết: Một hóa đơn có nhiều dòng chi tiết
        public virtual ObservableCollectionListSource<HoaDonChiTiet> HoaDonChiTiet { get; } = new();

        // Liên kết ngược lại
        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}