<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="addinfo.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.appointment.addinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>

                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="stuname" Label="姓名" Required="true" runat="server">
                        </f:TextBox>
                        <f:DropDownList runat="server" ID="sgender" Text="性别">
                            <f:ListItem Text="男" Value="男" Selected="true" />
                            <f:ListItem Text="女" Value="女" Selected="true"/>
                        </f:DropDownList>
                        <f:TextBox ID="sphone" Label="电话" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                         <f:TextBox ID="tname" Label="预约老师" runat="server">
                        </f:TextBox>
                        <f:DatePicker ID="stime" Required="True" ShowRedStar="true" runat="server"
                            SelectedDate="2016-05-09" Label="预约日期" Text="2016-05-09">
                        </f:DatePicker>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea ID="sremarks" Height="80px" Label="预约备注" runat="server" Required="True" ShowRedStar="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow>
                   <Items>
                        <f:Button ID="btnLogin" Text="提交" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                            runat="server" OnClick="btn_Click">
                            </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="回发-关闭-刷新父页面" runat="server" Icon="SystemSave"
                            OnClick="btnSaveRefresh_Click">
                            </f:Button>
                   </Items>
                </f:FormRow>
                
            </Rows>
        </f:Form>
    </form>
</body>
</html>
