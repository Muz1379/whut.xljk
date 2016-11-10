<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoadminadd.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.infoadmin.infoadminadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1"  ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Rows>
                <f:FormRow ID="FormRow1">
                    <Items>
                        <f:TextBox ID="name" runat="server" Label="账号姓名">
                        </f:TextBox>
                    </Items>
                    <Items>
                        <f:TextBox ID="reaname" runat="server" Label="真实姓名">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow2">
                    <Items>
                        <f:TextBox ID="useremail" runat="server" Label="账号邮箱">
                        </f:TextBox>
                    </Items>
                    <Items>
                        <f:TextBox ID="phone" runat="server" Label="账号电话">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow3">
                    <Items>
                        <f:TextBox ID="pwd" runat="server" Label="账号密码">
                        </f:TextBox>
                    
                        <f:DropDownList ID="DropDownList1" runat="server" Label="类别">
                            <f:ListItem Value="0" Text="系统管理员"></f:ListItem>
                            <f:ListItem Value="1" Text="超级管理员"></f:ListItem>
                            <f:ListItem Value="2" Text="问答管理员"></f:ListItem>
                            <f:ListItem Value="3" Text="助理"></f:ListItem>
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Button ID="add" Text="提交" OnClick="add_Click"></f:Button>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
