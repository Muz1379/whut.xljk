using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using whut.xljk.MODEL;
using whut.xljk.BLL;

namespace EmptyProjectNet45_FineUI.admin.message
{
    public partial class messageReplied : System.Web.UI.Page
    {
        MessageBLL messageBLL = new MessageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        #region DataBind Grid绑定数据

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

        private void BindGrid()
        {
            

            DataTable dt = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);


            Grid1.DataSource = dt;

            Grid1.RecordCount = GetTotalCount();

            Grid1.DataKeyNames = new string[] { "ID" };
            Grid1.DataBind();
        }

        private void BindGrid2()
        {
            Grid1.RecordCount = GetTotalCount();

            DataTable dt = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }


        #endregion

        #region events

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            AutoBindGrid();
        }

        // 删除按钮事件
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == "delete")
            {
                int id = int.Parse(Grid1.DataKeys[e.RowIndex].GetValue(0).ToString());
                int deleteResult = messageBLL.Delete(id);

                if(deleteResult > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "删除成功";
                    alert.Target = Target.Top;
                    alert.Show();
                }
                else
                {
                    Alert alert = new Alert();
                    alert.Message = "出现问题，请稍后再试";
                    alert.Target = Target.Top;
                    alert.Show();
                }

                BindGrid();
            }

        }

        #endregion


        private int GetTotalCount()
        {
            return messageBLL.GetAllMessageRepliedByTeacher(Session["admin_name"].ToString().Trim()).Rows.Count;
        }

        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = messageBLL.GetAllMessageRepliedByTeacher(Session["admin_name"].ToString().Trim());

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
    }
}