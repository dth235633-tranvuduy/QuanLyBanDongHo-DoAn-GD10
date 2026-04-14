using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTQL_QLBHDongHo.Data
{
    public class HoaDonChiTiet
    {
        [Key]
        public int ID { get; set; }

        public int HoaDonID { get; set; }
        public int? SanPhamID { get; set; }

        [StringLength(200)]
        public string TenSanPhamSnapshot { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng bán phải lớn hơn 0")]
        public int SoLuongBan { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Đơn giá bán không hợp lệ")]
        public int DonGiaBan { get; set; } // Giá chốt lúc bán

        [NotMapped]
        public long ThanhTien => (long)SoLuongBan * DonGiaBan; // Tránh tràn số khi nhân tiền

        [ForeignKey(nameof(HoaDonID))]
        public virtual HoaDon HoaDon { get; set; } = null!;

        [ForeignKey(nameof(SanPhamID))]
        public virtual SanPham? SanPham { get; set; }
    }
}