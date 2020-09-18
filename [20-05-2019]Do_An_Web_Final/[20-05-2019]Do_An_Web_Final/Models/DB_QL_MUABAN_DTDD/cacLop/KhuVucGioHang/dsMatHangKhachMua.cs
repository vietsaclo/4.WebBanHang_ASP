using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang
{
    public class dsMatHangKhachMua
    {
        public List<matHang> dsMatHang;

        public double tongTien;

        public dsMatHangKhachMua()
        {
            dsMatHang = new List<matHang>();
            tongTien = 0;
        }

        public String getToString()
        {
            String str = "";
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                str += dsMatHang[i].getInfoMatHang() + "<br/>";
            }
            return str;
        }

        public void Add(matHang mh)
        {
            if (mh != null)
            {
                dsMatHang.Add(mh);
                tongTien += mh.sPham.gia;
            }
        }

        public bool isExits(int maSanPham)
        {
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].sPham.maSanPham == maSanPham)
                    return true;
            }

            return false;
        }

        public DataTable ConvertTo_DataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("maSanPham",typeof(int)); dt.Columns.Add("tenSanPham",typeof(String)); dt.Columns.Add("gia",typeof(double)); dt.Columns.Add("hinhAnh",typeof(String)); dt.Columns.Add("soLuong",typeof(int));
            DataRow dr;
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                dr = dt.NewRow();
                dr["maSanPham"] = dsMatHang[i].sPham.maSanPham;
                dr["tenSanPham"] = dsMatHang[i].sPham.tenSanPham;
                dr["gia"] = dsMatHang[i].sPham.gia;
                dr["hinhAnh"] = dsMatHang[i].sPham.hinhAnh;
                dt.Rows.Add(dr);

                dt.Rows[i]["soLuong"] = dsMatHang[i].sLuong;
            }

            return dt;
        }

        public void tangSoLuongMatHang(int maSanPham)
        {
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                int masp = dsMatHang[i].sPham.maSanPham;
                if (masp == maSanPham)
                {
                    dsMatHang[i].sLuong += 1;
                    tongTien += dsMatHang[i].sPham.gia;
                    break;
                }
            }
        }

        public void giamSoLuongMatHang(int maSanPham)
        {
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                int masp = dsMatHang[i].sPham.maSanPham,
                    sl = dsMatHang[i].sLuong;
                if (masp == maSanPham && sl > 1)
                {
                    dsMatHang[i].sLuong -= 1;
                    tongTien -= dsMatHang[i].sPham.gia;
                    break;
                }
            }
        }

        public void xoaMotMatHang(int maSanPham)
        {
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].sPham.maSanPham == maSanPham)
                {
                    matHang mh = dsMatHang[i];
                    double gia = mh.sPham.gia;
                    int sl = mh.sLuong;
                    gia = gia * sl;
                    tongTien -= gia;
                    dsMatHang.RemoveAt(i);
                    break;
                }
            }
        }
    }
}