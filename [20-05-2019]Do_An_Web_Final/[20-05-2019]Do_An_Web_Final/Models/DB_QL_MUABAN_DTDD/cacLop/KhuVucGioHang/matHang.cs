using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang
{
    public class matHang
    {
        public sanPham sPham;
        public int sLuong;

        public matHang()
        {
            sPham = new sanPham();
            sLuong = 1;
        }

        public matHang(int maSanPham)
        {
            sPham = new thuVien_QL_MUABAN_DTDD().getSanPhamTheoPrimaryKey(maSanPham);
            sLuong = 1;
        }

        public matHang(sanPham sp, int sl)
        {
            sPham = sp;
            sLuong = sl;
        }

        public matHang(matHang mh)
        {
            sPham = mh.sPham;
            sLuong = mh.sLuong;
        }

        public String getInfoMatHang()
        {
            return sPham.tenSanPham + " | " + sLuong;
        }
    }
}