<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/common/SingleGrid.Master" CodeBehind="infoadminlist.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.infoadmin.infoadminlist" %>

<%@ MasterType VirtualPath="~/admin/common/SingleGrid.Master" %>

<asp:content id="Content1" contentplaceholderid="mainCPH" runat="server">
    <f:Form ID="Form6" ShowBorder="false" ShowHeader="false" runat="server">
        <Rows>

<%--            <f:FormRow>
                <Items>
                    <f:TwinTriggerBox runat="server" EmptyText="在用户名中搜索" ShowLabel="false" ID="ttbSearch"
                        ShowTrigger1="false" OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                        Trigger1Icon="Clear" Trigger2Icon="Search">
                    </f:TwinTriggerBox>
                    <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        runat="server">
                        <f:ListItem Text="过滤条件一" Value="filter1" />
                        <f:ListItem Text="过滤条件二" Value="filter2" />
                        <f:ListItem Text="过滤条件三" Value="filter3" />
                    </f:DropDownList>
                </Items>
            </f:FormRow>--%>
        </Rows>
    </f:Form>
    <f:Grid ID="Grid1" EnableCollapse="false" PageSize="5" ShowBorder="true" ShowHeader="false"
        BoxFlex="1"
        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="C_InfoAdminAccount,C_InfoAdminName" IsDatabasePaging="true"
        AllowSorting="true" SortField="C_InfoAdminName" SortDirection="ASC">
        <Columns>
            <f:RowNumberField />
             
            <f:BoundField DataField="C_InfoAdminName" Width="100px" SortField="C_ArticleContent" DataFormatString="{0}"
                HeaderText="真实姓名" />
            
            <f:BoundField DataField="C_InfoAdminAccount" Width="100px" SortField="C_ArticleTitle" DataFormatString="{0}"
                HeaderText="账号名称" />

            <f:BoundField DataField="C_InfoAdminTel" Width="100px" SortField="C_ArticleAnnexAddr" DataFormatString="{0}"
                HeaderText="账户电话" />


            <f:BoundField DataField="C_InfoAdminEmail" Width="100px" SortField="C_ArticleTime" DataFormatString="{0}"
                HeaderText="账号邮箱" />


            <f:BoundField DataField="C_InfoAdminPwd" Width="100px" SortField="C_ArticleTitle" DataFormatString="{0}"
                HeaderText="账号密码" />

            <f:BoundField DataField="C_InfoAdminCategory" Width="100px" SortField="C_ArticlePostStaff" DataFormatString="{0}"
                HeaderText="账号类别" />


        </Columns>
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <f:Button ID="btnExport" EnableAjax="false" DisableControlBeforePostBack="false"
                        runat="server" Text="导出为Excel文件" OnClick="btnExport_Click">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
    </f:Grid>
</asp:content>

<asp:content runat="server" contentplaceholderid="headCPH">
    <meta name="sourcefiles" content="~/Admin/SingleGrid.Master;~/Admin/ISingleGridPage.cs" />
</asp:content>
