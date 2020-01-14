<%@ Page Language="C#" AutoEventWireup="true" CodeFile="File_upload.aspx.cs" Inherits="File_upload" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="~/Includes/Header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="~/Includes/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>File Upload</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 112px;
        }
        .style2
        {
            width: 157px;
        }
        .style3
        {
            width: 246px;
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
                    <uc1:header ID="header" runat="server" />
                    <div class="content">
                        <table class="style1" cellpadding="5" cellspacing="5">
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#009933" 
                                        Text="RainFall"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                       
                            <tr>
                                <td class="style2">
                                    Upload Your Text Document:
                                </td>
                                <td class="style3">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
                                        ErrorMessage="Select File"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    <asp:Button ID="btnApply" runat="server" Height="28px" OnClick="btnApply_Click" Text="Apply"
                                        Width="122px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div>
                            
                                <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Both" 
                                    Width="900px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource1" 
    Width="896px">
                                        <Columns>
                                            <asp:BoundField DataField="islands" HeaderText="Islands" />
                                            <asp:BoundField DataField="place" HeaderText="Place" SortExpression="time" />
                                            <asp:BoundField DataField="year" HeaderText="Year" 
                                            SortExpression="location" />
                                            <asp:BoundField DataField="month" HeaderText="Month" 
                                            SortExpression="operator" />
                                            <asp:BoundField DataField="rain" HeaderText="rain" 
                                            SortExpression="flight#" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:rainfall_228ConnectionString %>" 
                                        SelectCommand="SELECT * FROM [dataset]"></asp:SqlDataSource>
                                </asp:Panel>
                            
                            <br />
                        </div>
                        <div>
                        
                        </div>
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
