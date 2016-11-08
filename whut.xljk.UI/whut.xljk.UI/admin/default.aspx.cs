using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using FineUI;


namespace EmptyProjectNet45_FineUI.admin
{
    public partial class _default : System.Web.UI.Page
    {
        string xmlPath = "";
        public string username = "";
        public string admin_category = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_name"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    username = Session["admin_name"].ToString();
                    switch(Convert.ToInt32(Session["admin_category"]))
                    {
                        case 0:
                            admin_category = "系统管理员";
                            break;
                        case 1:
                            admin_category = "超级管理员";
                            break;
                        case 2:
                            admin_category = "问答管理员";
                            break;
                        case 3:
                            admin_category = "助理";
                            break;

                    }
                    
                    int admincategory = Convert.ToInt32(Session["admin_category"]);

                    //绑定不同的权限菜单
                    switch (admincategory)
                    {
                        case 0:
                            xmlPath = Server.MapPath("~/admin/menu0.xml");
                            break;
                        case 1:
                            xmlPath = Server.MapPath("~/admin/menu1.xml");
                            break;
                        case 2:
                            xmlPath = Server.MapPath("~/admin/menu2.xml");
                            break;
                        case 3:
                            xmlPath = Server.MapPath("~/admin/menu3.xml");
                            break;
                    }

                    string xmlContent = String.Empty;
                    using (StreamReader sr = new StreamReader(xmlPath))
                    {
                        xmlContent = sr.ReadToEnd();
                    }

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(xmlContent);
                    leftMenuTree.DataSource = xdoc;
                    leftMenuTree.DataBind();

                }
            }
        }
        

        protected void btnServerClick_Click(object sender, EventArgs e)
        {
            Session.Remove("admin_name");
            Session.Remove("admin_category");
            PageContext.Redirect("login.aspx");
        }
    }
}