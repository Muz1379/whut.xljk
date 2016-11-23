using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using whut.xljk.MODEL;
using whut.xljk.BLL;
using System.Text;
using EmptyProjectNet45_FineUI.admin.common;
namespace EmptyProjectNet45_FineUI.admin.appointment
{
    public partial class apoinfo : System.Web.UI.Page
    {
        AppointmentBll ab = new AppointmentBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                ddlPageSize.SelectedValue = Grid1.PageSize.ToString();
                btnPopupWindow.OnClientClick = Window1.GetShowReference("addinfo.aspx") + "return false;";
            }
        }
        private void BindGrid()
        {
            // 1.设置总项数
            Grid1.RecordCount = GetTotalCount();
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        private int GetTotalCount()
        {
            return ab.GetData("").Rows.Count;
        }
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = ab.GetData("");

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            //// 更改每页显示数目时，防止 PageIndex 越界
            //if (Grid1.PageIndex > Grid1.PageCount - 1)
            //{
            //    Grid1.PageIndex = Grid1.PageCount - 1;
            //}

            BindGrid();
        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            AutoBindGrid();
        }
        private void AutoBindGrid()
        {
            if (ViewState["BindGrid1"] != null && Convert.ToBoolean(ViewState["BindGrid1"]))
            {
                BindGrid();
                ViewState["BindGrid1"] = false;
            }
            else
            {
                BindGrid2();
                ViewState["BindGrid1"] = true;
            }
        }
        private void BindGrid2()
        {
            // 1.设置总项数
            Grid1.RecordCount = GetTotalCount();
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Grid1.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条记录！");
                return;
            }
            else
            {
                Alert.ShowInTop("删除选中的 " + Grid1.SelectedRowIndexArray.Length + " 项纪录！");
            }
            int count = 0;//统计删除成功条数
            foreach(int i in Grid1.SelectedRowIndexArray){
                GridRow row = Grid1.Rows[i];
                string name = row.DataKeys[0].ToString().Trim();
                string phone = row.DataKeys[1].ToString().Trim();
                if (DeleteSelectedRows(name, phone)==1)
                {
                    count++;
                }
            }
            if (count >= 1)
            {
                Alert.ShowInTop("删除成功！");
                BindGrid();
            }

        }
        public int DeleteSelectedRows(string name, string phone)
        {
            return ab.delectData(name, phone);
        }

    }
}