using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.MODEL;
using whut.xljk.BLL;
namespace EmptyProjectNet45_FineUI.admin.appointment
{
	public partial class addinfo : System.Web.UI.Page
	{
        T_stuinfo ts = new T_stuinfo();
        AppointmentBll ab = new AppointmentBll();
		protected void Page_Load(object sender, EventArgs e)
		{
            stime.Text = DateTime.Now.ToShortDateString();
		}
        protected void btn_Click(object sender, EventArgs e)
        {
            ts.sname = stuname.Text.ToString();
            ts.sgender = sgender.SelectedValue;
            ts.sphone = sphone.Text.ToString();
            ts.tname = tname.Text.ToString();
            ts.apo_time = stime.Text;
            ts.remark = sremarks.Text.ToString();
            int i = ab.insert_apoinfo(ts);
            if (i > 0)
            {
                Alert.ShowInTop("添加成功！");

            }
            else
            {
                Alert.ShowInTop("添加失败！", MessageBoxIcon.Error);
            }
        }
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑



            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

	}
}