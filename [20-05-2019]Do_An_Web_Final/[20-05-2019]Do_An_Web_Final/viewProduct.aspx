<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="viewProduct.aspx.cs" Inherits="Do_An_Web_Final.viewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <div class="container">
        <div class="mb-5 mt-5 p-3 border row">
            <div class="border-right col-12 col-sm-12 col-md-4 col-lg-6">
                <div class="mb-1 text-danger card-header text-uppercase font-weight-bold p-3 text-center bg-warning">
                    <asp:Label ID="lb_showTenSanPham" runat="server" Text="Ten SanPham"></asp:Label></div>
                <div class="card-img text-center">
                    <asp:Image ID="img_viewProduct" runat="server" CssClass="img_viewProduct" />
                </div>
                <div class="font-weight-bold mb-2 mt-2 p-2 text-white border bg-info card-footer text-center">
                    <asp:Label ID="lb_showGia_product" runat="server" Text="gia"></asp:Label></div>
                <div class="form-inline">
                    <div><asp:LinkButton ID="link_btn_addToCart" runat="server" CssClass="btn-primary btn" CommandName="addToCart" Text="Add To Cart >>" OnClick="link_btn_addToCartClicked" ></asp:LinkButton></div>
                </div>
            </div>

            <div class="col-12 col-sm-12 col-md-4 col-lg-6">
                <asp:Literal ID="literal_moTaProduct" runat="server"></asp:Literal>
            </div>
        </div>


        <!-- sản phẩm Liên Quan start -->
        <div class="text-white bg-info p-3 row">
            <div class="text-left col-6 col-sm-6 col-md-6 col-lg-6">
                <h3 class="text-uppercase font-weight-bold">Liên Quan</h3>
            </div>
            <div class="text-right col-6 col-sm-6 col-md-6 col-lg-6"><asp:LinkButton ID="link_btn_seeAllproduct_spLienQuan" runat="server" Text="See All Product" OnClick="link_btn_seeAllproduct_spLienQuan_clicked" CssClass="font-weight-bold text-uppercase text-white btn-link"></asp:LinkButton></div>
        </div>
        <div class="mb-5 border row">
            <asp:Repeater ID="rpt_showSanPhamLienQuan" runat="server" OnItemCommand="rpt_showSanPhamLienQuan_ItemCommand">
                <ItemTemplate>
                    <div class="overflow-hidden p-3 card col-12 col-sm-12 col-md-6 col-lg-3">
                        <div class="mb-1 text-danger card-header h-25 text-uppercase font-weight-bold p-2 text-center bg-warning"><%#Eval("tenSanPham") %></div>
                        <div class="card-img text-center">
                            <img src="images_up/sanPham/<%#Eval("hinhAnh") %>" style="width: 240px; height: 240px;" />
                        </div>
                        <div class="font-weight-bold mb-2 mt-2 p-2 text-white border bg-info card-footer text-center"><%#String.Format("{0:N0}",Eval("gia"))%></div>
                        <div class="form-inline">
                            <div><a href="viewProduct.aspx?maSanPham=<%#Eval("maSanPham") %>" role="button" class="mr-4 btn-outline-success btn">View &raquo;</a></div>
                            <div><asp:LinkButton ID="link_btn_addToCart" runat="server" CssClass="btn-primary btn" CommandName="addToCart" Text="Add To Cart >>" CommandArgument='<%#Eval("maSanPham") %>' ></asp:LinkButton></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hiddF_maHangSX" runat="server" />
        </div>
        <!-- sản phẩm Liên Quan end-->























        <!-- data list start-->
        <asp:SqlDataSource ID="sqlDataS_layTop4SanPhamMoiNhat" runat="server"
            ConnectionString="<%$ConnectionStrings:strConn_shop_banHang %>"
            SelectCommand="SELECT TOP 4 * FROM SANPHAM ORDER BY NGAYDANG DESC"></asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlDataS_layTop4SanPhamHotNhat" runat="server"
            ConnectionString="<%$ConnectionStrings:strConn_shop_banHang %>"
            SelectCommand="SELECT TOP 4 * FROM SANPHAM ORDER BY GIA DESC"></asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlDataS_layTop4SanPhamLienQuan" runat="server"
            ConnectionString="<%$ConnectionStrings:strConn_shop_banHang %>"
            SelectCommand="SELECT TOP 4 * FROM SANPHAM"></asp:SqlDataSource>
        <!-- data list end-->
    </div>
</asp:Content>
