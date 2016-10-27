using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FineUI;
using whut.xljk.BLL;
using whut.xljk.MODEL;

namespace EmptyProjectNet20
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }




        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUserName.Text.Trim();
            string pwd = tbxPassword.Text.Trim();


            infoadminBLL bll = new infoadminBLL();
            T_InfoAdmin model = new T_InfoAdmin();
            model=  bll.GetInfoAdmin(username);
            if (model.InfoAdminName == null)
            {
                Alert.ShowInTop("该用户不存在！", MessageBoxIcon.Error);
            }
            else if (model.InfoAdminPwd == pwd)
            {
                Session["admin_name"] = model.InfoAdminName;
                Session["admin_category"] = model.InfoAdminCategory;

                Alert.ShowInTop("成功登录！");
                PageContext.Redirect("default.aspx");
            }
            else
            {
                Alert.ShowInTop("用户名或密码错误！", MessageBoxIcon.Error);
            }
        }

    }
}
