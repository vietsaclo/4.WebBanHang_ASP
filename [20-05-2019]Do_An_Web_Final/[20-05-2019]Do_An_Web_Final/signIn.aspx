<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="Do_An_Web_Final.signIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <div class="jumbotron">
        <div class="bg-light p-3 form_signIn">
            <img src="images_up/logoWeb/logoWeb.png" style="width: 200px; height: 150px;" />
            <h5 class="text-info mb-5 text-uppercase font-weight-normal">Làm ơn đăng nhập</h5>
            <asp:TextBox ID="tb_userName" runat="server" placeHolder="Nhập user name" CssClass="mb-3 form-control" TextMode="SingleLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_userName" runat="server" ControlToValidate="tb_userName" Display="Dynamic" ForeColor="Red">#user name khác rỗng</asp:RequiredFieldValidator>
            <asp:TextBox ID="tb_password" runat="server" placeHolder="Nhập password" CssClass="mb-3 form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_password" runat="server" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red">#password khác rỗng</asp:RequiredFieldValidator>
            <asp:CheckBox ID="cbox_rememberMe" runat="server" Text="Remember Me" CssClass="mb-3 form-control" />
            <asp:Button ID="btn_signIn" runat="server" CssClass="btn-success btn" Text="Sign In" OnClick="btn_signIn_Click" />
            <asp:Label ID="lb_showError" runat="server" Text="Sai tên đăng nhập hoặc mật khẩu" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
