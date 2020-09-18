<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Do_An_Web_Final._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <!-- slogant start-->
    <div class="jumbotron">
        <asp:Label ID="lb_slogant_head" runat="server" CssClass="h2 text-capitalize text-danger"></asp:Label><br />
        <asp:Label ID="lb_slogant_body" runat="server" CssClass="h5 text-success"></asp:Label><br />
        <a href="#" role="button" class="mt-4 btn-primary btn">Khám Phá Ngay &raquo;</a>
    </div>
    <!-- slogant end-->

    <div class="container">
        <!-- loai san pham va slider start-->
        <div class="mb-5 row">
            <div class="p-0 border col-12 col-sm-12 col-md-5 col-lg-5" style="min-height: 300px;">
                <div class="font-weight-bold text-center text-uppercase p-2 text-white bg-success">Tất cả hãng sản xuất</div>
                <div class="clear">
                    <asp:Repeater ID="rbt_tatCaHangSanXuat" runat="server">
                        <ItemTemplate>
                            <a href="viewAllProduct.aspx?option=hangSX&id=<%#Eval("maHangSX") %>">
                                <img src="images_up/hangSX/<%#Eval("icon_hangSX") %>" style="width: 30%" class="hover_img mb-3 icon_hangSX" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="border col-12 col-sm-12 col-md-7 col-lg-7" style="height: 300px;">
                <!-- Slider start-->
                <div class="bd-example">
                    <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                            <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <asp:Repeater ID="rpt_slider" runat="server" DataSourceID="sqlDataS_layTop4SanPhamMoiNhat">
                                <ItemTemplate>
                                    <div class="carousel-item <%#Do_An_Web_Final.Models.public_DB.getClassActive(Container.ItemIndex) %>">
                                        <div class="text-center">
                                            <img src="images_up/sanPham/<%#Eval("hinhAnh") %>" alt="..." style="width: 290px; height: 290px;" />
                                        </div>
                                        <div class="carousel-caption">
                                            <h5><span class="op_8 card-img p-2 bg-white"><span class="text-success">sale 25% today</span></span></h5>
                                            <p class="op_8 p-2 bg-danger card-img"><span class="text-white"><%#Eval("tenSanPham") %></span></p>
                                            <a role="button" href="viewProduct.aspx?maSanPham=<%#Eval("maSanPham") %>" class="btn-info btn">View &raquo;</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                    <!-- Slider end-->
                </div>
            </div>
            <!-- loai san pham va slider end-->
        </div>

        <!-- Sản phẩm mới nhất start-->
        <div class="text-white bg-info p-3 row">
            <div class="text-left col-6 col-sm-6 col-md-6 col-lg-6">
                <h3 class="text-uppercase font-weight-bold">new product</h3>
            </div>
            <div class="text-right col-6 col-sm-6 col-md-6 col-lg-6"><a href="viewAllProduct.aspx?option=new_product" class="text-uppercase text-white btn-link">see all product</a></div>
        </div>
        <div class="mb-5 border row">
            <asp:Repeater ID="rbt_sanPhamMoiNhat" runat="server" DataSourceID="sqlDataS_layTop4SanPhamMoiNhat" OnItemCommand="rbt_sanPhamMoiNhat_ItemCommand">
                <ItemTemplate>
                    <div class="overflow-hidden p-3 card col-12 col-sm-12 col-md-6 col-lg-3">
                        <div class="mb-1 text-danger card-header h-25 text-uppercase font-weight-bold p-2 text-center bg-warning"><%#Eval("tenSanPham") %></div>
                        <div class="card-img text-center">
                            <img src="images_up/sanPham/<%#Eval("hinhAnh") %>" style="width: 240px; height: 240px;" />
                        </div>
                        <div class="font-weight-bold mb-2 mt-2 p-2 text-white border bg-info card-footer text-center"><%#String.Format("{0:N0}",Eval("gia"))%></div>
                        <div class="form-inline">
                            <div><a href="viewProduct.aspx?maSanPham=<%#Eval("maSanPham") %>" role="button" class="mr-4 btn-outline-success btn">View &raquo;</a></div>
                            <div><asp:LinkButton ID="link_btn_addToCart" runat="server" CssClass="btn-primary btn" CommandName="addToCart" CommandArgument='<%#Eval("maSanPham") %>' Text="Add To Cart >>" ></asp:LinkButton></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- sản phẩm mới nhất end-->

        <!-- sản phẩm hot nhất start -->
        <div class="text-white bg-info p-3 row">
            <div class="text-left col-6 col-sm-6 col-md-6 col-lg-6">
                <h3 class="text-uppercase font-weight-bold">hot product</h3>
            </div>
            <div class="text-right col-6 col-sm-6 col-md-6 col-lg-6"><a href="viewAllProduct.aspx?option=hot_product" class="text-uppercase text-white btn-link">see all product</a></div>
        </div>
        <div class="mb-5 border row">
            <asp:Repeater ID="rpt_sanPhamHotNhat" runat="server" DataSourceID="sqlDataS_layTop4SanPhamHotNhat" OnItemCommand="rbt_sanPhamMoiNhat_ItemCommand">
                <ItemTemplate>
                    <div class="overflow-hidden p-3 card col-12 col-sm-12 col-md-6 col-lg-3">
                        <div class="mb-1 text-danger card-header h-25 text-uppercase font-weight-bold p-2 text-center bg-warning"><%#Eval("tenSanPham") %></div>
                        <div class="card-img text-center">
                            <img src="images_up/sanPham/<%#Eval("hinhAnh") %>" style="width: 240px; height: 240px;" />
                        </div>
                        <div class="font-weight-bold mb-2 mt-2 p-2 text-white border bg-info card-footer text-center"><%#String.Format("{0:N0}",Eval("gia"))%></div>
                        <div class="form-inline">
                            <div><a href="viewProduct.aspx?maSanPham=<%#Eval("maSanPham") %>" role="button" class="mr-4 btn-outline-success btn">View &raquo;</a></div>
                            <div><asp:LinkButton ID="link_btn_addToCart" runat="server" CssClass="btn-primary btn" CommandName="addToCart" CommandArgument='<%#Eval("maSanPham") %>' Text="Add To Cart >>" ></asp:LinkButton></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- sản phẩm hot nhất end-->
    </div>















    <!-- data list start-->
    <asp:SqlDataSource ID="sqlDataS_layTop4SanPhamMoiNhat" runat="server"
        ConnectionString="<%$ConnectionStrings:strConn_shop_banHang %>"
        SelectCommand="SELECT TOP 4 * FROM SANPHAM ORDER BY NGAYDANG DESC"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlDataS_layTop4SanPhamHotNhat" runat="server"
        ConnectionString="<%$ConnectionStrings:strConn_shop_banHang %>"
        SelectCommand="SELECT TOP 4 * FROM SANPHAM ORDER BY GIA DESC"></asp:SqlDataSource>
    <!-- data list end-->
</asp:Content>
