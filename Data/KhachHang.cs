using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    public class KhachHang
    {
        public int ID { get; set; }

        [Required]
        public string HoVaTen { get; set; }

        public string? DienThoai { get; set; }

        public string? DiaChi { get; set; }

        // --- Thuộc tính thêm mới để tích điểm ---

        /// <summary>
        /// Tổng số điểm tích lũy hiện có của khách hàng
        /// </summary>
        public int DiemTichLuy { get; set; } = 0;

        // Liên kết đến bảng HoaDon
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}