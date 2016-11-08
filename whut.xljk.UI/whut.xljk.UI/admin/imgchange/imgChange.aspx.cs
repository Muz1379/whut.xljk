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
    public partial class imgChange : System.Web.UI.Page
    {
        ImgChangeBLL bll = new ImgChangeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string des = TextBox1.Text;
            string url = TextBox2.Text;
            int chooseImg = int.Parse(DropDownList1.SelectedValue);
            string path = "~/images/banner/back" + chooseImg.ToString() + ".jpg";
            ChangeImagePath(chooseImg, des, url);
            FileUpload1.SaveAs(Request.MapPath(path));
            Response.Write("修改成功，请关闭此窗口~");

            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        public bool ChangeImagePath(int chooseImg, string des, string url)
        {
            JiaoTiChangeImg(chooseImg);
            T_ImgChange model = new T_ImgChange { C_ImgDes = des, C_ImgUrl = url, C_ImgId = chooseImg };
            return JiaoTiChangeInfo(model, chooseImg);
        }
        public void JiaoTiChangeImg(int chooseImg)
        {
            for (int i = 4; i > chooseImg; i--)
            {
                string path = Request.MapPath("~/images/banner/back" + (i - 1).ToString() + ".jpg");

                using (FileStream fs = new FileStream(path, FileMode.Open))//获得路径中的一个图片
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fs);//获得图片副本
                    if (File.Exists(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg"))
                    {
                        File.Delete(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg"); //删除图片
                    }
                    image.Save(Request.MapPath("~/images/banner/back" + i.ToString() + ".jpg"));//保留图片副本，名字更改
                }
            }
        }


        //对数据库进行一定的修改
        public bool JiaoTiChangeInfo(T_ImgChange model, int chooseImg)
        {
            List<T_ImgChange> list = bll.GetList();
            list.RemoveAt(3);
            list.Insert(chooseImg - 1, model);
            return bll.UpdateImageInfo(list);
        }
    }
}