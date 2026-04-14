using System;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using LTQL_QLBHDongHo.Forms;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DamBaoCapNhatCauTrucDuLieu();
            ActivityLogger.DamBaoBangNhatKyTonTai();

            using var login = new frmDangNhap();
            if (login.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            AppSession.TenDangNhap = login.TenDangNhap;
            AppSession.LaAdmin = login.LaAdmin;
            AppSession.VaiTro = login.VaiTro;

            ActivityLogger.GhiNhatKy("ĐĂNG NHẬP", $"Tài khoản '{AppSession.TenDangNhap}' đăng nhập hệ thống.");

            ChayBackfillSnapshotHoaDonCu();

            Application.Run(new frmTrangChu());
        }

        private static void DamBaoCapNhatCauTrucDuLieu()
        {
            try
            {
                using var context = new QLBHDbContext();
                context.Database.Migrate();
            }
            catch
            {
                // Không chặn mở app nếu migration lỗi, sẽ báo ở luồng nghiệp vụ.
            }
        }

        private static void ChayBackfillSnapshotHoaDonCu()
        {
            try
            {
                using var context = new QLBHDbContext();
                HoaDonSnapshotHelper.BackfillSnapshotChoHoaDonCu(context);
                HoaDonSnapshotHelper.BackfillTenSanPhamSnapshotChoChiTietHoaDonCu(context);
            }
            catch
            {
                // B? qua l?i migration ?? kh�ng ch?n ??ng nh?p ?ng d?ng.
            }
        }
    }
}