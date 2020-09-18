<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hoaDon_control.ascx.cs" Inherits="Do_An_Web_Final.Admin.hoaDon_conntrol" %>
<!-- style start-->
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../myStyle/myCustom.css" rel="stylesheet" />
<!-- style end-->

<!-- quản lý hóa đơn start-->
<div class="container">
    <asp:Repeater ID="rpt_showHoaDon" runat="server">
        <HeaderTemplate>
            <table class="table-hover table-dark table" >
                <thead>
                    <th>Mã hóa đơn</th>
                    <th>Mã tài khoản</th>
                    <th>Ngày lập</th>
                    <th>Tổng tiền</th>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <td><%#Eval("MAHD") %></td>
                <td><%#Eval("MATK") %></td>
                <td><%#Eval("NGAYLAP") %></td>
                <td><%#Eval("TONGTIEN") %></td>
            </tbody>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<!-- quản lý hóa đơn end-->