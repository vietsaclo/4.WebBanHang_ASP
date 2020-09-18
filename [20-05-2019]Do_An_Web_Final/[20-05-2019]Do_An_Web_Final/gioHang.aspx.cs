using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final
{
    public partial class gioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData_TO_REPEATER_gioHang();
            }
        }

        protected void loadData_TO_REPEATER_gioHang()
        {
            if (Session["ss_gioHang"] == null)
            {
                rbt_show_gioHang.DataSource = new DataTable();
                return;
            }
            dsMatHangKhachMua list = (dsMatHangKhachMua)Session["ss_gioHang"];
            rbt_show_gioHang.DataSource = list.ConvertTo_DataTable();
            rbt_show_gioHang.DataBind();
            lb_showTongTienThanhToan.Text = String.Format("{0:N0}",list.tongTien);
        }

        protected void rbt_show_gioHang_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String task = e.CommandName.ToString();
            int maSanPham = int.Parse(e.CommandArgument.ToString());
            dsMatHangKhachMua list = (dsMatHangKhachMua)Session["ss_gioHang"];
            if (list == null) return;
            if (task.Equals("xoaMotSanPham"))
            {
                list.xoaMotMatHang(maSanPham);
                Session["ss_gioHang"] = list;
            }
            else
            {
                if (task.Equals("tangSoLuongSanPham"))
                {
                    list.tangSoLuongMatHang(maSanPham);
                    Session["ss_gioHang"] = list;
                }
                else
                {
                    list.giamSoLuongMatHang(maSanPham);
                    Session["ss_gioHang"] = list;
                }
            }

            Response.Redirect(Request.Url.ToString());
        }

        protected void link_btn_xoaTatCaSanPham_clicked(object sen, EventArgs e)
        {
            Session["ss_gioHang"] = null;
            Response.Redirect(Request.Url.ToString());
        }

        protected void delete_confirm_clicked(object sen, EventArgs e)
        {
            ((LinkButton)sen).Attributes["onClick"] = "return confirm('[ Cẩn Thận ] Bạn chắc muốn xóa chứ?')"; 
        }
    }
}