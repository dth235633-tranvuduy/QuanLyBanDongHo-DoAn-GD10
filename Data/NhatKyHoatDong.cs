using System.ComponentModel.DataAnnotations;

namespace LTQL_QLBHDongHo.Data
{
    public class NhatKyHoatDong
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string TenDangNhap { get; set; } = string.Empty;

        [StringLength(150)]
        public string TenNhanVien { get; set; } = string.Empty;

        [StringLength(100)]
        public string VaiTro { get; set; } = string.Empty;

        [StringLength(120)]
        public string HanhDong { get; set; } = string.Empty;

        [StringLength(1000)]
        public string ChiTiet { get; set; } = string.Empty;

        public DateTime ThoiGian { get; set; } = DateTime.Now;
    }
}
