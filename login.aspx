<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="~/Includes/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Login</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 136px;
        }
        .style2
        {
            width: 85px;
        }
        .style3
        {
            width: 171px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <div class="header">
                        <div class="header-bottom">
                            <h2 style="color: white;">
                                RAINFALL</h2>
                        </div>
                        <div class="content">
                            <div class="content-left">
                                <div class="row1">
                                    <h1 class="title">
                                        <span>Login</span></h1>
                                    <table class="style1">
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td class="style3">
                                                &nbsp;
                                                <asp:Label ID="lblShow" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp; Username:
                                            </td>
                                            <td class="style3">
                                                &nbsp;
                                                <asp:TextBox ID="txtUsername" runat="server" Height="24px" Width="149px"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                                    ErrorMessage="Username Required"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp; Password:
                                            </td>
                                            <td class="style3">
                                                &nbsp;
                                                <asp:TextBox ID="txtPassword" runat="server" Height="24px" Width="149px" TextMode="Password"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                    ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td class="style3">
                                                &nbsp;
                                                <asp:Button ID="btnLogin" runat="server" Height="25px" Text="Login" Width="80px"
                                                    OnClick="btnLogin_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div>
                            <uc1:footer ID="footer" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
