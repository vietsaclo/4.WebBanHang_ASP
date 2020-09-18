using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang;

namespace Do_An_Web_Final
{
    public partial class viewProduct : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();
        sanPham sp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initViewProduct();
                loadDataFror_rptSanPhamLienQuan();
            }
        }

        protected void initViewProduct()
        {
            String getQR = Request.QueryString["maSanPham"];
            if (String.IsNullOrEmpty(getQR))
            {
                Response.Redirect("default.aspx");
                return;
            }
            int pkValue = 0;
            try
            {
                pkValue = int.Parse(getQR);
            }
            catch
            {
                Response.Redirect("default.aspx");
                return;
            }
            sp = _tv.getSanPhamTheoPrimaryKey(pkValue);
            if (sp == null)
            {
                Response.Redirect("default.aspx");
                return;
            }
            lb_showTenSanPham.Text = sp.tenSanPham;
            lb_showGia_product.Text = String.Format("{0:N0}",sp.gia);
            img_viewProduct.ImageUrl = "images_up/sanPham/"+sp.hinhAnh;
            literal_moTaProduct.Text = sp.moTa;
        }

        protected void loadDataFror_rptSanPhamLienQuan()
        {
            if (sp == null) return;
            hiddF_maHangSX.Value = sp.maHangSX.ToString();
            rpt_showSanPhamLienQuan.DataSource = _tv.getListTo_dataTable("SELECT TOP 4 * FROM SANPHAM WHERE MAHANGSX="+sp.maHangSX);
            rpt_showSanPhamLienQuan.DataBind();
        }

        protected void link_btn_seeAllproduct_spLienQuan_clicked(object sen, EventArgs ev)
        {
            Response.Redirect("viewAllProduct.aspx?option=lien_quan&id=" + hiddF_maHangSX.Value.ToString());
        }

        protected void link_btn_addToCartClicked(Object sen, EventArgs ev)
        {
            ACTION_ADD_TO_CART(int.Parse(Request.QueryString["maSanPham"].ToString()));
        }

        protected void rpt_showSanPhamLienQuan_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ACTION_ADD_TO_CART(int.Parse(e.CommandArgument.ToString()));
        }

        public void ACTION_ADD_TO_CART(int maSanPham)
        {
            if (Session["ss_user"] == null)
            {
                Response.Write("<script>alert('Để thực hiện việc mua hàng, Bạn cần đăng nhập trước !')</script>");
                return;
            }
            taiKhoan tk = (taiKhoan)Session["ss_user"];
            if (tk.phanQuyen != 0)
            {
                Response.Write("<script>alert('Bạn không phải quyền user, Bạn không thể mua hàng !')</script>");
                return;
            }

            dsMatHangKhachMua list = null;
            list = (dsMatHangKhachMua)Session["ss_gioHang"];
            if (list == null)
            {
                list = new dsMatHangKhachMua();
                matHang mh = new matHang(maSanPham);
                list.Add(mh);
            }
            else
            {
                list = (dsMatHangKhachMua)Session["ss_gioHang"];
                if (!list.isExits(maSanPham))
                {
                    matHang mh = new matHang(maSanPham);
                    list.Add(mh);
                }
            }
            Session["ss_gioHang"] = list;

            Response.Redirect("~/gioHang.aspx");
        }
    }
}