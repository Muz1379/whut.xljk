<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/common/SingleGrid.Master" CodeBehind="articleList.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.article.articleList" %>

<%@ MasterType VirtualPath="~/admin/common/SingleGrid.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" runat="server">
    <f:Form ID="Form6" ShowBorder="false" ShowHeader="false" runat="server">
        <Rows>

            <f:FormRow>
                <Items>
                    <f:DropDownList ID="dropdownlist1" Label="新闻类别" ShowLabel="true" AutoPostBack="true" OnSelectedIndexChanged="dropdownlist1_SelectedIndexChanged1"
                        runat="server">
                        <f:ListItem Text="中心概况" Value="1" />
                        <f:ListItem Text="中心动态" Value="2" />
                        <f:ListItem Text="心协动态" Value="3" />
                        <f:ListItem Text="咨询师简介" Value="4" />
                        <f:ListItem Text="心灵驿站" Value="5" />
                        <f:ListItem Text="查看全部" Value="6" Selected="true" />
                    </f:DropDownList>
                </Items>
            </f:FormRow>
        </Rows>
    </f:Form>
    <f:Grid ID="Grid1" EnableCollapse="false" PageSize="5" ShowBorder="true" ShowHeader="false"
        BoxFlex="1"
        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="C_ArticleId,C_ArticleTitle" IsDatabasePaging="true"
        AllowSorting="true" SortField="C_ArticleId" SortDirection="ASC"
        OnRowDataBound="Grid1_RowDataBound">
        <Columns>
            <f:RowNumberField />
            <f:BoundField DataField="C_ArticleId" Width="100px" SortField="C_ArticleTitle" DataFormatString="{0}"
                HeaderText="新闻编号" />

            <f:TemplateField Width="100px" HeaderText="新闻类别" TextAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="news_state" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </f:TemplateField>


            <f:BoundField DataField="C_ArticleTitle" Width="100px" SortField="C_ArticleTitle" DataFormatString="{0}"
                HeaderText="新闻名称" />

            <f:BoundField DataField="C_ArticleSector" Width="100px" SortField="C_ArticleSector" DataFormatString="{0}"
                HeaderText="新闻来源" />

            <f:BoundField DataField="C_ArticlePostStaff" Width="100px" SortField="C_ArticlePostStaff" DataFormatString="{0}"
                HeaderText="发布者" />

            <f:BoundField DataField="C_ArticleContent" Width="100px" SortField="C_ArticleContent" DataFormatString="{0}"
                HeaderText="文章内容" />

            <f:BoundField DataField="C_ArticleAnnexAddr" Width="100px" SortField="C_ArticleAnnexAddr" DataFormatString="{0}"
                HeaderText="文章附件" />

            <f:BoundField DataField="C_ArticleTime" Width="100px" SortField="C_ArticleTime" DataFormatString="{0}"
                HeaderText="发布时间" />

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
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="headCPH">
    <meta name="sourcefiles" content="~/Admin/SingleGrid.Master;~/Admin/ISingleGridPage.cs" />
</asp:Content>
