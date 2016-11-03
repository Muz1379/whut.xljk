using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using FineUI;
using System.Text;
using System.IO;
using AspNet = System.Web.UI.WebControls;
using EmptyProjectNet45_FineUI.admin.common;
using whut.xljk.BLL;
using whut.xljk.MODEL;

namespace EmptyProjectNet45_FineUI.admin.infoadmin
{
    public partial class infoadmindetail : System.Web.UI.Page
    {
        public T_InfoAdmin model { get; set; }
        whut.xljk.BLL.infoadminBLL bll = new whut.xljk.BLL.infoadminBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                model = bll.getAdminByID(id);//直接绑定

                //

                name.Text = model.InfoAdminAccount;
                reaname.Text = model.InfoAdminName;
                pwd.Text = model.InfoAdminPwd;
                phone.Text = model.InfoAdminTel;
                //绑定类别下拉菜单
                DropDownList1.SelectedIndex = model.InfoAdminCategory;

                useremail.Text = model.InfoAdminEmail;
                
                
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {

            T_InfoAdmin model = new T_InfoAdmin();
            model.InfoAdminAccount = name.Text.ToString().Trim();
            model.InfoAdminName = reaname.Text.ToString().Trim();
            model.InfoAdminPwd = pwd.Text.ToString().Trim();
            model.InfoAdminTel = phone.Text.ToString().Trim();
            //绑定类别下拉菜单
            model.InfoAdminCategory = DropDownList1.SelectedIndex;
            model.InfoAdminEmail = useremail.Text.ToString().Trim();
            model.InfoAdminSector = "";




            if (bll.Update(model))
            {
                Alert.ShowInTop("文章内容修改成功，请关闭窗口~");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("文章内容修改失败");
            }

        }

    }
}