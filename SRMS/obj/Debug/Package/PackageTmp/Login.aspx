<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="SRMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="Resources/IT-Theory.png" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Resources/css/util.css">
    <link rel="stylesheet" type="text/css" href="Resources/css/main.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100" style="background-image: url('Resources/images/img-01.jpg');">
                <div class="wrap-login100 p-t-190 p-b-30">
                    <form class="login100-form validate-form">
                        <div class="login100-form-avatar">
                            <img src="Resources/IT-Theory.png" alt="AVATAR" />
                        </div>

                        <span class="login100-form-title p-t-20 p-b-45">Welcome To SRMS
                        </span>
                        <asp:Label ID="lblShowMsg" CssClass="text-danger" BackColor="#ffcc66" Font-Bold="true" runat="server" Text=""></asp:Label>
                        <div class="wrap-input100 validate-input m-b-10" data-validate="Username is required">
                            <asp:TextBox CssClass="input100" ID="txtUserName" placeholder="Username" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-user"></i>
                            </span>
                        </div>

                        <div class="wrap-input100 validate-input m-b-10" data-validate="Password is required">
                            <asp:TextBox CssClass="input100" TextMode="Password" ID="txtPassword" placeholder="Password" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-lock"></i>
                            </span>
                        </div>

                        <div class="container-login100-form-btn p-t-10">
                            <asp:Button CssClass="login100-form-btn" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

                        </div>

                        <div class="text-center w-full p-t-25 p-b-230">
                            <a href="#" class="txt1">Forgot Username / Password?
                            </a>
                        </div>

                        <%--<div class="text-center w-full">
						<a class="txt1" href="#">
							Create new account
							<i class="fa fa-long-arrow-right"></i>						
						</a>
					</div>--%>
                    </form>
                </div>
            </div>
        </div>




        <!--===============================================================================================-->
        <script src="Resources/vendor/jquery/jquery-3.2.1.min.js"></script>
        <!--===============================================================================================-->
        <script src="Resources/vendor/bootstrap/js/popper.js"></script>
        <script src="Resources/vendor/bootstrap/js/bootstrap.min.js"></script>
        <!--===============================================================================================-->
        <script src="Resources/vendor/select2/select2.min.js"></script>
        <!--===============================================================================================-->
        <script src="Resources/js/main.js"></script>
    </form>
</body>
</html>

