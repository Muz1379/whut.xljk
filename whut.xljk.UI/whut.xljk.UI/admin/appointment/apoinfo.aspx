<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apoinfo.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.appointment.apoinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="预约信息"  EnableCollapse="true" PageSize="5" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" EnableCheckBoxSelect="True" Width="800px" Height="350px"
        DataKeyNames="C_stuname,C_stuphone" OnPageIndexChange="Grid1_PageIndexChange" IsDatabasePaging="true">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnPopupWindow" Text="增加" runat="server">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnDelete" Text="删除选中行" runat="server" onclick="btnDelete_Click" >
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="序号"/>
                <f:BoundField Width="100px" DataField="C_stuname" HeaderText="姓名" />
                <f:BoundField Width="80px" DataField="C_gender" HeaderText="性别" />
                <f:BoundField Width="80px" DataField="C_stuphone"  HeaderText="电话" />
                <f:BoundField Width="80px" DataField="C_teaname" HeaderText="预约老师" />
                <f:BoundField Width="100px" DataField="C_apotime"  HeaderText="预约日期" />
                <f:TemplateField ColumnID="expander" RenderAsRowExpander="true">
                    <ItemTemplate>
                        <div class="expander">
                            <p>
                                <strong>预约备注：</strong><%# Eval("C_remarks") %>
                            </p>
                        </div>
                    </ItemTemplate>
                </f:TemplateField>
        </Columns>
         <PageItems>
            <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
            </f:ToolbarSeparator>
            <f:ToolbarText runat="server" Text="每页记录数：">
            </f:ToolbarText>
            <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true"
                OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <f:ListItem Text="5" Value="5" />
                <f:ListItem Text="10" Value="10" />
                <f:ListItem Text="15" Value="15" />
                <f:ListItem Text="20" Value="20" />
            </f:DropDownList>
        </PageItems>
        </f:Grid>
        <f:Window ID="Window1" Title="增加" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="850px" Height="550px">
        </f:Window>
    </form>
</body>
</html>



