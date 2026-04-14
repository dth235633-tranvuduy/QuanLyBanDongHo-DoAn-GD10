using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TenThuongHieu { get; set; } = string.Empty;

        public virtual ObservableCollectionListSource<SanPham> SanPham { get; } = new();
    }
}
