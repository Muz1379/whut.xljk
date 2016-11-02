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
    public partial class infoadminadd : System.Web.UI.Page
    {
        public T_InfoAdmin model { get; set; }
        whut.xljk.BLL.infoadminBLL bll = new whut.xljk.BLL.infoadminBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {

            T_InfoAdmin model = new T_InfoAdmin();
            model = bll.getAdminByID(name.Text.Trim());

            //检查账户名是否存在
            if (model.InfoAdminPwd == null)
            {
                model.InfoAdminAccount = name.Text.Trim();
                model.InfoAdminName = reaname.Text.ToString().Trim();
                model.InfoAdminPwd = pwd.Text.ToString().Trim();
                model.InfoAdminTel = phone.Text.ToString().Trim();


                //绑定类别下拉菜单
                model.InfoAdminCategory = DropDownList1.SelectedIndex;
                model.InfoAdminEmail = useremail.Text.ToString().Trim();
                model.InfoAdminSector = "";

                if (bll.Insert(model)==1)
                {
                    Alert.ShowInTop("添加成功~");

                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
            }
            else
            {
                Alert.ShowInTop("用户存在，请重新填写");
            }
        }
    }
}