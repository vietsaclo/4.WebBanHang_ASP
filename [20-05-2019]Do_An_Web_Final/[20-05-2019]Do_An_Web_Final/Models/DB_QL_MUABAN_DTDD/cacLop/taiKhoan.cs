using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop
{
    public class taiKhoan
    {
        public int maTk { get; set; }
        public String uName { get; set; }
        public String pass { get; set; }
        public String fName { get; set; }
        public String emailAr { get; set; }
        public int phanQuyen { get; set; }
        public bool active { get; set; }

        public taiKhoan()
        {

        }

        public taiKhoan(int maT,String uNam,String pas,String fNam,String emailA,int phanQuye, bool activ)
        {
            maTk = maT;
            uName = uNam;
            pass = pas;
            fName = fNam;
            emailAr = emailA;
            phanQuyen = phanQuye;
            active = activ;
        }
    }
}