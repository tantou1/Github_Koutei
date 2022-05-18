using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Koutei.UserControl;
using Service;
using SpeechLib;

namespace Koutei.WebFront
{
    public partial class K1_Main : System.Web.UI.Page
    {

        public static string to, tomail;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                messge_set();
            }
            get_data_DB();
            BindBoard();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

        }
        private void BindBoard()
        {

            PinChange();

            //K_ClientConnection_Class test = new K_ClientConnection_Class();
            //DataTable dt = test.GetKoutei();

            //K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();
            //DataTable dtLabel = label.Get_Label(chk_santo.Checked);

            //UC03Main ucmain = (UC03Main)LoadControl("~/UserControl/UC03Main.ascx");
            //ucmain.ID = "UCMain";
            //ucmain.TaskTsuika += this.HandleTaskTsuika;
            //pnlTask.Controls.Add(ucmain);
            //UpdTaskTsuika.Update();

            DataTable dt = Session["dt"] as DataTable;            DataTable dtLabel = Session["dtLabel"] as DataTable;            int color_i = 0;            for (int i = 0; i < dt.Rows.Count; i++)            {                DataRow[] drresult = dtLabel.Select("koutei_id = " + dt.Rows[i]["id"].ToString());                DataTable dt_label_koutei = dtLabel.Clone();                if (drresult.Length > 0)                {                    dt_label_koutei = drresult.CopyToDataTable();                }

                //工程ボードを設定する
                UC01board ucBoard = (UC01board)LoadControl("~/UserControl/UC01board.ascx");                ucBoard.ID = "ucPending" + dt.Rows[i]["id"].ToString();                Session["BoardName"] = dt.Rows[i]["title"].ToString();                Session["BoardID"] = dt.Rows[i]["id"].ToString();
                //Session["TaskCount"] = label.Get_TaskCount(dt.Rows[i]["id"].ToString());
                if (dt_label_koutei.Rows.Count > 0)
                {
                    Session["TaskCount"] = dt_label_koutei.Rows.Count.ToString();
                }                else
                {
                    Session["TaskCount"] = "";
                }                string color = "";                if (color_i == 0)
                {
                    color = "#7CD0FF";
                    color_i++;
                }                else if (color_i == 1)
                {
                    color = "#F65161";
                    color_i++;
                }                else if (color_i == 2)
                {
                    color = "#FDD853";
                    color_i++;
                }                else if (color_i == 3)
                {
                    color = "#FC78B9";
                    color_i++;
                }
                else if (color_i == 4)
                {
                    color = "#36C398";
                    color_i++;
                }
                else if (color_i == 5)
                {
                    color = "#AEDA49";
                    color_i++;
                }
                else if (color_i == 6)
                {
                    color = "#7D5CC1";
                    color_i++;
                }
                else if (color_i == 7)
                {
                    color = "#FF954A";
                    color_i = 0;
                }                ucBoard.SetPendingFusenBoardData(color);                pnlPending.Controls.Add(ucBoard);

                //工程ボードの中に付箋を設定する
                Panel pnlFusen = (Panel)ucBoard.FindControl("pnlFusen");                if (dt_label_koutei.Rows.Count > 0)                {                    for (int j = 0; j < dt_label_koutei.Rows.Count; j++)                    {                        UC02Label ucLabelJouhou = (UC02Label)LoadControl("~/UserControl/UC02Label.ascx");                        ucLabelJouhou.ID = "uc" + (j + 1);                        ucLabelJouhou.SetFusenJouhou(dt_label_koutei.Rows[j]);
                        ucLabelJouhou.DeleteLabel += this.HandleDeleteLabel;
                        pnlFusen.Controls.Add(ucLabelJouhou);                    }                }            }
            updFusenMain.Update();
        }

        protected void PinChange()
        {
            pnlFusenMain.CssClass = "M02FusenMainDiv";
            pnlPending.CssClass = "M02PendingDiv";
            div_board.Style.Add("display", "none");
            pnlFusenMain.Style.Add("display", "none");
            pnlFusenMain.Controls.Clear();
            pnlPending.Controls.Clear();
        }

        protected void btnFusenTsuika_Click(object sender, EventArgs e)
        {
            //Response.Write("<script language='javascript'>window.alert('確認してください。');</script>");
            //string jscript = "<script>alert('YOUR BUTTON HAS BEEN CLICKED')</script>";
            //System.Type t = this.GetType();
            //ClientScript.RegisterStartupScript(t, "k", jscript);

            SessionUtility.SetSession("HOME", "Popup");
            ifShinkiPopup.Src = "K2_Kouteipopup.aspx";
            mpeShinkiPopup.Show();
            updShinkiPopup.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseLoading", "closeLoadingModal();", true);
        }

        protected void btn_ClosePopup_Click(object sender, EventArgs e)
        {
            ifShinkiPopup.Src = "";
            mpeShinkiPopup.Hide();
            updShinkiPopup.Update();
        }

        protected void chk_santo_CheckedChanged(object sender, EventArgs e)
        {

            //get_data_DB();
            //BindBoard();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseLoading", "closeLoadingModal();", true);
        }

        public void HandleDeleteLabel(object sender, EventArgs e)
        {
            Button btnDelete = (sender as Button);
            UC02Label uc02label = (UC02Label)btnDelete.NamingContainer;
            Label lbId = uc02label.FindControl("lbId") as Label;

            //UC01board ucBoard = (UC01board)LoadControl("~/UserControl/UC01board.ascx");

            //Panel pnlFusen = (Panel)ucBoard.FindControl("pnlFusen");
            //pnlFusen.Controls.Remove(uc02label);
            //updFusenMain.Update();

            K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();
            if (label.EndLable(lbId.Text))
            {
                //SpVoice spv = new SpVoice();
                //spv.Speak("おめでとうございます。");
                //spv.Rate = 1;
                get_data_DB();
                BindBoard();
                mailsend();

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseLoading", "closeLoadingModal();", true);
            }
            else
            {
                return;
            }

        }


        private void get_data_DB()
        {
            K_ClientConnection_Class test = new K_ClientConnection_Class();
            DataTable dt = test.GetKoutei();
            Session.Add("dt", dt);

            K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();
            DataTable dtLabel = label.Get_Label(chk_santo.Checked);
            Session.Add("dtLabel", dtLabel);
        }
        private void mailsend()
        {
            try
            {
                MailMessage message = Session["message"] as MailMessage;
                message.To.Add("comnetyamin93@gmail.com");
                SmtpClient smtp = Session["smtp"] as SmtpClient;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        private void messge_set()
        {

            string from, pass, messageBody = "";
            string receivemail = ConfigurationManager.AppSettings["SMTP_Sender"];
            MailMessage message = new MailMessage();
            //to = "minazou0417@gmail.com";
            to = receivemail;
            from = ConfigurationManager.AppSettings["SMTP_Sender"];
            pass = ConfigurationManager.AppSettings["SMTP_Password"];
            messageBody = "工程完了しました。";
            message.To.Add(to);
            message.From = new MailAddress(from, ConfigurationManager.AppSettings["SMTP_SenderName"]);
            message.Body = messageBody;
            message.Subject = "工程完了";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            smtp.Timeout = int.Parse(ConfigurationManager.AppSettings["SMTP_Timeout"]);
            smtp.EnableSsl = true;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.EnableSsl = true;
            Session.Add("message", message);
            Session.Add("smtp", smtp);
        }

        protected void btn_SaishinJyouhou_Click(object sender, EventArgs e)
        {

        }

        public void HandleTaskTsuika(object sender, EventArgs e)
        {
            SessionUtility.SetSession("HOME", "Popup");
            ifShinkiPopup.Src = "K2_Kouteipopup.aspx";
            mpeShinkiPopup.Show();
            updShinkiPopup.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseLoading", "closeLoadingModal();", true);
        }
    }
}