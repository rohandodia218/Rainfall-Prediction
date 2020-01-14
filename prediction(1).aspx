<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prediction.aspx.cs" Inherits="home" %>
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
                        <table cellpadding="20" cellspacing="20" 
                            style="color: #000000; font-weight: bold; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                        <tr>
                            <td><a href="statebasedGraph.aspx"><span>Statewise</span></a></td>
                <td><a href="citybasedGraph.aspx"><span>Citywise</span></a></td>
                <td><a href="yearbasedGraph.aspx"><span>Yearly</span></a></td>
                <td><a href="citymonth.aspx"><span>Monthly</span></a></td>
                        </tr>
                        </table>
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
