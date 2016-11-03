<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imglist.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.imgchange.imglist" %>


<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <meta name="sourcefiles" content="~/grid/grid_iframe_window.aspx" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />

        <div class="imgContainer">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/banner/back1.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/banner/back2.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/banner/back3.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/banner/back4.jpg" Width="198" Height="68" /></td>
                </tr>
                <tr>
                    <td>序号1</td>
                    <td>序号2</td>
                    <td>序号3</td>
                    <td>序号4</td>
                </tr>
            </table>
            <div>
                <asp:Label ID="Label2" runat="server" Text="(*如果无法查看预览效果，请点击刷新！)" ForeColor="Red"></asp:Label>
            </div>
        </div>

        <f:Button ID="Button1" runat="server" EnablePostBack="false" Text="修改首页大图">
        </f:Button>


        <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" WindowPosition="Center"
            EnableMaximize="true" EnableResize="true"  Target="Self"
            IsModal="True" Width="850px" Height="450px"
            >
        </f:Window>
    </form>
</body>
</html>
