using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    public class LoaiDongHo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TenLoai { get; set; } = string.Empty; // VD: Đồng hồ cơ, Đồng hồ Pin, Smartwatch

        public virtual ObservableCollectionListSource<SanPham> SanPham { get; } = new();
    }
}