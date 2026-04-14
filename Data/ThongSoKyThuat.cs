using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTQL_QLBHDongHo.Data
{
    public class ThongSoKyThuat
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SanPhamID { get; set; }

        [StringLength(200)]
        public string LoaiKinh { get; set; } = string.Empty;

        [StringLength(200)]
        public string DoChiuNuoc { get; set; } = string.Empty;

        [StringLength(200)]
        public string LoaiDay { get; set; } = string.Empty;

        [StringLength(200)]
        public string KichThuocMat { get; set; } = string.Empty;

        [StringLength(200)]
        public string TenThuongHieu { get; set; } = string.Empty;

        public int? LoaiDongHoID { get; set; }

        [ForeignKey(nameof(SanPhamID))]
        public virtual SanPham SanPham { get; set; } = null!;

        [ForeignKey(nameof(LoaiDongHoID))]
        public virtual LoaiDongHo? LoaiDongHo { get; set; }
    }
}