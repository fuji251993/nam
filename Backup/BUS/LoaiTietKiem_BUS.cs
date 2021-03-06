using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public static class LoaiTietKiem_BUS
    {

        public static List<LoaiTietKiem_DTO> DSLoaiTietKiem()
        {
            return LoaiTietKiem_DAO.DSLoaiTietKiem();
        }

        public static LoaiTietKiem_DTO  LayDSLTK(long maloai)
        {
            return LoaiTietKiem_DAO.LayDSLTK(maloai);
        }
        public static long LayMaLoaiTietKiemKoKyHan()
        {
            return LoaiTietKiem_DAO.LayMaLoaiTietKiemKhongKyHan("Không Kỳ Hạn");
        }

        public static string LayTenLoaiTietKiem(long maloaitietkiem)
        {
            return LoaiTietKiem_DAO.LayTenLoaiTietKiem(maloaitietkiem);
        }

        public static float LayLoaiLaiSuat(string tenloaitietkiem)
        {
            return LoaiTietKiem_DAO.LayLoaiLaiSuat(tenloaitietkiem);
        }

        public static float LayLaiSuatBoiMaLoaiTietKiem(long maloaitietkiem)
        {
            return LoaiTietKiem_DAO.LayLaiSuatBoiMaLoaiTietKiem(maloaitietkiem);
        }

        public static int LayChiSo(long maloaitietkiem)
        {
            string chuoiten = LoaiTietKiem_BUS.LayTenLoaiTietKiem(maloaitietkiem);
            int chiso = int.Parse(chuoiten[0].ToString());
            return chiso;
        }

        public static long MaTiepTheo()
        {
            return LoaiTietKiem_DAO.MaLonNhat() + 1;
        }

        public static void ThemLoaiTietKiem(LoaiTietKiem_DTO loaitietkiem)
        {
            LoaiTietKiem_DAO.ThemLoaiTietKiem(loaitietkiem);
        }
      
        public static DataTable LayTenLoaiTietKiem1(string maloaitietkiem)
        {
            return LoaiTietKiem_DAO.LayTenLoaiTietKiem1(maloaitietkiem);
        }
        public static void ThayDoiQuyDinh(long maloaitietkiem, float giatri)
        {
            LoaiTietKiem_DAO.CapNhatLoaiTietKiem(maloaitietkiem, giatri);
        }
        // xoa loai tiet kiem anh huong den so tiet kiem
       /* public static void XoaLoaiTietKiem(long maloaitietkiem)
        {
            LoaiTietKiem_DAO.XoaLoaiTietKiem(maloaitietkiem);
        }*/
        public static DataTable AllLoaiTietKiem()
        {
            return LoaiTietKiem_DAO.AllLoaiTietKiem();
        }

    }
}
