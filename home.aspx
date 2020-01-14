<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="~/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Includes/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Home</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <uc1:header ID="header" runat="server" />
                    <div class="content">
                        <asp:Image ID="Image1" runat="server" Height="458px" Width="954px"
                            ImageUrl="~/images/Somalia_MAM_Rainfall_ZS.png"  />
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
