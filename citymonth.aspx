<%@ Page Language="C#" AutoEventWireup="true" CodeFile="citymonth.aspx.cs"
    Inherits="ResultGraph" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Includes/Footer.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Domain</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-out">
        <div class="page-in">
            <div class="page">
                <div class="main">
                    <uc1:header ID="header" runat="server" />
                    <div class="content">
                        <div>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                Font-Size="XX-Large" ForeColor="#990000" Text="Rain Statistics"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <table cellpadding="10" cellspacing="10">
                                <tr>
                                    <td>
                                        Select State :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddstate" runat="server" AutoPostBack="True" Height="30px" Width="142px"
                                            OnSelectedIndexChanged="ddstate_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Select City :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddcity" runat="server" Height="30px" Width="142px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" Text="submit" onclick="Button2_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <br />
                                <br />
                            </table>
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                Font-Size="XX-Large" ForeColor="#79FFE4" Text="City Rain"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <asp:Chart ID="Chart2" runat="server" Palette="EarthTones" Width="926px">
                                <Series>
                                     <asp:Series Name="Series1" ChartArea="ChartArea1" XValueMember="place" 
                                        YValueMembers="avg" ChartType="StackedColumn" IsXValueIndexed="True">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisX IsLabelAutoFit="False">
                                            <LabelStyle Angle="-90" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                                
                            </asp:Chart>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <%-- <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource5" Width="854px">
                                <Series>
                                    <asp:Series ChartType="Bubble" Name="Series1" XValueMember="Product_Name" YValueMembers="Color_Count"
                                        YValuesPerPoint="2">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Color_tradeforConnectionString %>"
                                SelectCommand="SELECT [Product_Name], [Color_Count] FROM [MFP_Result]"></asp:SqlDataSource>--%>
                            <br />
                            <br />
                        </div>
                    </div>
                    <uc2:footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
