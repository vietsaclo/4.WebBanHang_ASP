<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="Do_An_Web_Final.administrator" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>wellcome Administrator</title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="myStyle/myCustom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header start-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="#">SHOP-INFO</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="default.aspx">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">About</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Contract
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Something else here</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="text-capitalize font-weight-bold text-white nav-link dropdown-toggle" href="#" id="dropDown_quanTriOption" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Quản trị Option
                        </a>
                        <div class="bg-dark dropdown-menu" aria-labelledby="dropDown_quanTriOption">
                            <a class="text-capitalize btn-block btn-outline-info btn" href="administrator.aspx?task=taikhoanoption" role="button">Tài Khoản</a>
                            <div class="dropdown-divider"></div>
                            <a class="text-capitalize btn-block btn-outline-info btn" href="administrator.aspx?task=hangsanxuatoption" role="button">Hãng Sản Xuất</a>
                            <div class="dropdown-divider"></div>
                            <a class="text-capitalize btn-block btn-outline-info btn" href="administrator.aspx?task=sanphamoption" role="button">Sản Phẩm</a>
                            <div class="dropdown-divider"></div>
                            <a class="text-capitalize btn-block btn-outline-info btn" href="administrator.aspx?task=hoadonoption" role="button">Hóa Đơn</a>
                        </div>
                    </li>
                </ul>
                <div class="form-inline">
                    <asp:TextBox ID="tb_search" runat="server" placeHolder="Search" CssClass="mr-1 form-control"></asp:TextBox>
                    <a href="#" role="button" class="mr-1 btn-outline-success btn">Search</a>
                </div>
            </div>
        </nav>
        <!-- Header end-->

        <!-- Thống kê start-->
        <div class="jumbotron">
            <h2 class="text-uppercase text-center text-success">Thống kê số lượng</h2>
            <ul class="list-group">
                <li class="font-weight-bold text-capitalize list-group-item">số lượng tài khoản: <asp:Label ID="lb_showSoLuongTaiKhoan" runat="server" CssClass="text-success font-weight-bold" Text="0"></asp:Label></li>
                <li class="font-weight-bold text-capitalize list-group-item">số lượng hãng sản xuất: <asp:Label ID="lb_showSoLuongHangSX" runat="server" CssClass="text-success font-weight-bold" Text="0"></asp:Label></li>
                <li class="font-weight-bold text-capitalize list-group-item">số lượng sản phẩm: <asp:Label ID="lb_showSoLuongSanPham" runat="server" CssClass="text-success font-weight-bold" Text="0"></asp:Label></li>
                <li class="font-weight-bold text-capitalize list-group-item">số lượng hóa đơn: <asp:Label ID="lb_showSoLuongHoaDon" runat="server" CssClass="text-success font-weight-bold" Text="0"></asp:Label></li>
            </ul>
        </div>
        <!-- Thông kê end-->

        <div>
            <asp:PlaceHolder ID="holder_content_Admin" runat="server"></asp:PlaceHolder>
        </div>

        <!-- footer start-->
        <footer class="mt-5 text-white bg-dark">
            <div class="p-5 text-center container">
                <p class="h5" >&copy;CopyRight by <a href="#" class="text-white">My Team: Viet, Nam, Tho </a>&middot;2019</p>
                <p class="h5"><span><img src="images_up/icon/facebook.png" /></span> Facebook: <a href="#" class="text-white" >My - Team</a></p>
            </div>
        </footer>
        <!-- footer end-->
    </form>

    <!-- script-->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <!-- script-->
</body>
</html>
