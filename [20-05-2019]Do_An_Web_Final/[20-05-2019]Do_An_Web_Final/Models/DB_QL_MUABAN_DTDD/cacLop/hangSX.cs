using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop
{
    public class hangSX
    {
        public int maHangSX { get; set; }
        public String tenHangSX { get; set; }
        public bool active { get; set; }
        public String icon_hangSX { get; set; }

        public hangSX()
        {

        }

        public hangSX(int maHangSX, String tenHangSX, bool active, String icon_hangSX)
        {
            this.maHangSX = maHangSX;
            this.tenHangSX = tenHangSX;
            this.active = active;
            this.icon_hangSX = icon_hangSX;
        }
    }
}