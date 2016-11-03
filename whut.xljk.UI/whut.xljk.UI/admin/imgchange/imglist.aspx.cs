using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;
using FineUI;

namespace EmptyProjectNet45_FineUI.admin.imgchange
{
    public partial class imglist : System.Web.UI.Page
    {
        ImgChangeBLL bll = new ImgChangeBLL();
        T_ImgChange model1, model2, model3, model4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.OnClientClick = Window1.GetShowReference("imgChange.aspx", "修改首页大图");
                bindimg();
            }
        }
        public void bindimg()
        {

            List<T_ImgChange> list = bll.GetList();
            model1 = list[0];
            model2 = list[1];
            model3 = list[2];
            model4 = list[3];
            Image1.ToolTip = "描述：" + model1.C_ImgDes.ToString() + "；路径：" + model1.C_ImgUrl.ToString();
            Image2.ToolTip = "描述：" + model2.C_ImgDes.ToString() + "；路径：" + model2.C_ImgUrl.ToString();
            Image3.ToolTip = "描述：" + model3.C_ImgDes.ToString() + "；路径：" + model3.C_ImgUrl.ToString();
            Image4.ToolTip = "描述：" + model4.C_ImgDes.ToString() + "；路径：" + model4.C_ImgUrl.ToString();
        }
    }
}