using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final.Admin
{
    public partial class hoaDon_conntrol : System.Web.UI.UserControl
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataFor_rpt_showHoaDon();
            }
        }

        protected void loadDataFor_rpt_showHoaDon()
        {
            rpt_showHoaDon.DataSource = _tv.getListTo_dataTable("SELECT * FROM HOADON");
            rpt_showHoaDon.DataBind();
        }
    }
}