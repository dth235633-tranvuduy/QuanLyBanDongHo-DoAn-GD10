using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; } // Tương ứng với "Mã SP" trên giao diện

        [Required]
        [StringLength(200)]
        public string TenSanPham { get; set; } = string.Empty; // "Tên sản phẩm (*)"

        public int DonGia { get; set; } // "Giá bán"

        public int SoLuong { get; set; } // "Số lượng"

        [StringLength(500)]
        public string? HinhAnh { get; set; } // Lưu tên file ảnh

        [StringLength(1000)]
        public string? MoTa { get; set; } // Ghi chú/mô tả sản phẩm

        // --- Cột mới thêm ở đây ---
        [StringLength(50)]
        public string KieuDang { get; set; }  // Mặc định là Nam (Có thể là: Nam, Nữ, Unisex)
        // -----------------------

        [Required]
        public int ThuongHieuID { get; set; } // Liên kết thương hiệu

        [ForeignKey(nameof(ThuongHieuID))]
        public virtual ThuongHieu ThuongHieu { get; set; } = null!;
        public virtual LoaiDongHo? LoaiDongHo { get; set; }

        // Các danh sách liên kết để phục vụ logic nghiệp vụ
        public virtual ObservableCollectionListSource<ThongSoKyThuat> ThongSoKyThuat { get; } = new();
        public virtual ObservableCollectionListSource<HoaDonChiTiet> HoaDonChiTiet { get; } = new();
    }
}