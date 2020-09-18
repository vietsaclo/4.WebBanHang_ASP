<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="viewAllProduct.aspx.cs" Inherits="Do_An_Web_Final.viewAllProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <div class="container">

        <!-- sản phẩm theo query String start -->
        <div class="mt-5 text-white bg-info p-3 row">
            <div class="text-left col-12 col-sm-12 col-md-12 col-lg-12">
                <h3 class="text-uppercase font-weight-bold"><asp:Label ID="lb_sanPhamQuery" runat="server"></asp:Label></h3>
            </div>
        </div>
        <div class="mb-5 border row">
            <asp:Repeater ID="rpt_showSanPhamTheoQuery" runat="server" OnItemCommand="rpt_showSanPhamTheoQuery_ItemCommand">
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
        </div>
        <!-- sản phẩm theo query String end-->

    </div>
</asp:Content>
