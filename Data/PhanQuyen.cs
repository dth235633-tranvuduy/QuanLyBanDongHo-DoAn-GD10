using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LTQL_QLBHDongHo.Data
{
    // Đổi 'internal' thành 'public' để các file khác nhìn thấy
    public class PhanQuyen
    {
        public int ID { get; set; }

        // Thêm ? để cho phép null hoặc dùng string.Empty
        public string TenQuyen { get; set; } = string.Empty;

        // Quan hệ 1 - Nhiều: 1 quyền có nhiều nhân viên
        public virtual ObservableCollectionListSource<NhanVien> NhanVien { get; } = new();
    }
}