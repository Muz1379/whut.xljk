using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using whut.xljk.BLL;
using whut.xljk.MODEL;
using whut.xljk.COMMON;
using System.Net.Mail;
//using System.Web.Mail;

namespace EmptyProjectNet45_FineUI.admin.message
{
    public partial class messageReply : System.Web.UI.Page
    {
        MessageBLL messageBLL = new MessageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }

        }

        private void LoadData()
        {

            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            string id = Request.QueryString["id"].Trim();

            if(id != null)
            {
                int messageID = int.Parse(id);

                List<T_Message> message = messageBLL.GetMessageById(messageID);
                txb_NickName.Text = message[0].NickName;
                txb_Sex.Text = message[0].Sex;
                txb_TeacherName.Text = message[0].TeacherName;
                txb_Email.Text = message[0].Email;
                txb_ReplyEmailAddress.Text = "whutpsyhelp@126.com";
                txb_ReplyEmailPwd.Text = "whutpsyhelp1234";
                txa_BriefQuestion.Text = message[0].BriefQuestion;
                txa_DetailQuestion.Text = message[0].DetailQuestion;

                txb_NickName.Enabled = false;
                txb_Email.Enabled = false;
                txb_Sex.Enabled = false;
                txb_TeacherName.Enabled = false;
            }

            else
            {
                Alert alert = new Alert();
                alert.Message = "出错啦 请稍后再试";
                alert.Target = Target.Top;
                alert.Show();
            }
            


        }


        //protected void btnSaveContinue_Click(object sender, EventArgs e)
        //{
        //    // 1. 这里放置保存窗体中数据的逻辑

            

        //    // 2. 关闭本窗体，然后回发父窗体
        //    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        //}

        private void SendCompletedCallBack(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Alert alert = new Alert();

            if (e.Cancelled)  //邮件发送被取消
            {
                //Console.WriteLine("发送被取消!");
                //Lmsg.Text = "发送被取消!";
                //Response.Write("<script>alert('发送被取消!');</script>");
                alert.Message = ("发送被取消");
            }
            if (e.Error != null)   //邮件发送失败
            {
                //Console.WriteLine("发送失败！");
                //Lmsg.Text = "发送失败!";
                //Response.Write("<script>alert('发送失败！');</script>");
                alert.Message = "发送失败 错误信息：" + e.Error + "\n状态：" ;
            }
            else   //发送成功
            {
                //Console.WriteLine("发送成功！");
                //Lmsg.Text = "发送成功!";
                //Response.Write("<script>alert('发送成功！');</script>");
                alert.Message = "发送成功";
            }
            alert.Target = Target.Top;
            alert.Show();
        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            int messageID = int.Parse(Request.QueryString["id"].Trim());
            List<T_Message> message = messageBLL.GetMessageById(messageID);
            T_Message messageModel = new T_Message();

            try
            {
            

            #region 邮件信息

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(message[0].Email));
            mail.From = new MailAddress(txb_ReplyEmailAddress.Text.Trim(),"武汉理工大学心理健康平台",System.Text.Encoding.UTF8);
            string _body = "";
            string _subject = "回复：" + txa_BriefQuestion.Text.Trim();
            _body = HtmlEditor1.Text + "<br/><br/>******************************************************" + "<br/>" +
                            "这是一封系统自动发送的邮件通知，请不要直接回复，如有疑问，请联系管理员。" + "<br/>" +
                            "<br/>请添加本邮箱为联系人，以便于即时收到邮件通知。祝 学习生活愉快！";
            mail.Body = _body;
            mail.Subject = _subject;
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            
            #endregion

            #region 发送方服务器信息

            SmtpClient smtp = new SmtpClient();
            if (txb_ReplyEmailAddress.Text.Trim().IndexOf("@126.com") >= 0)
            {
                smtp.Host = "smtp.126.com";
            }
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            string mailFromAddress = txb_ReplyEmailAddress.Text.Split(new char[] { '@' })[0];

            smtp.Credentials = new System.Net.NetworkCredential("whutpsyhelp@126.com", txb_ReplyEmailPwd.Text.Trim());
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Port = 25;
            //smtp.Send(mail);  //同步发送程序将被阻塞

            #endregion

           

            #region 异步发送邮件 判断发送状态

            smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
            string userState = "测试";
            smtp.SendAsync(mail, userState);

            #endregion

            }
            catch
            {
                throw;
            }

            #region 保存至数据库

            messageModel.ID = messageID;
            messageModel.NickName = message[0].NickName;
            messageModel.Sex = message[0].Sex;
            messageModel.Email = message[0].Email;
            messageModel.Grade = message[0].Grade;
            messageModel.TeacherName = message[0].TeacherName;
            messageModel.BriefQuestion = txa_BriefQuestion.Text.Trim();
            messageModel.DetailQuestion = txa_DetailQuestion.Text.Trim();
            messageModel.QuestionTime = message[0].QuestionTime;
            messageModel.Reply = HtmlEditor1.Text.Trim();
            messageModel.ReplyTime = DateTime.Now;
            messageModel.Category = 0;
            if (HtmlEditor1.Text.Trim() != "")
            {
                messageModel.Status = 1;
            }

            int result = messageBLL.Update(messageModel);

            if (result > 0)
            {
                Alert alert = new Alert();
                alert.Message = "回复成功";
                alert.Target = Target.Top;
                alert.Show();
            }
            else
            {
                Alert alert = new Alert();
                alert.Message = "出现错误 请稍后再试";
                alert.Target = Target.Top;
                alert.Show();
            }

            #endregion






            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        public bool SendEmail(string _from_address, string _to_address, string _email_title, string _email_content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(_to_address));
            mail.From = new MailAddress(_from_address);
            mail.Subject = _email_title;
            mail.Body = _email_content;

            return true;
        }

        
    }
}