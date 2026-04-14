using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;



namespace LTQL_QLBHDongHo.Data // Chỉ giữ lại 1 namespace này thôi
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }

        // Thêm các thuộc tính mới
        public string DienThoai { get; set; } // Số điện thoại nhân viên
        public string DiaChi { get; set; }   // Địa chỉ nhân viên

        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int PhanQuyenID { get; set; }

        // Liên kết đến bảng PhanQuyen
        public virtual PhanQuyen PhanQuyen { get; set; } = null!;

        // Liên kết đến bảng HoaDon
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}