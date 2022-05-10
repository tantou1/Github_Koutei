using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        protected void Page_Load(object sender, EventArgs e)
        {            BindBoard();
        }
        private void BindBoard()
        {
            PinChange();

            K_ClientConnection_Class test = new K_ClientConnection_Class();            DataTable dt = test.GetKoutei();            K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();            DataTable dtLabel = label.Get_Label();            for (int i = 0; i < dt.Rows.Count; i++)            {
                //工程ボードを設定する
                UC01board ucBoard = (UC01board)LoadControl("~/UserControl/UC01board.ascx");                ucBoard.ID = "ucPending" + dt.Rows[i]["id"].ToString();                Session["BoardName"] = dt.Rows[i]["title"].ToString();                Session["BoardID"] = dt.Rows[i]["id"].ToString();                ucBoard.SetPendingFusenBoardData();                pnlPending.Controls.Add(ucBoard);                DataRow[] drresult = dtLabel.Select("koutei_id = " + dt.Rows[i]["id"].ToString());                DataTable dt_label_koutei = dtLabel.Clone();                if (drresult.Length > 0)                {                    dt_label_koutei = drresult.CopyToDataTable();                }

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
            pnlFusenMain.Style.Add("display", "none");
            pnlFusenMain.Controls.Clear();
            pnlPending.Controls.Clear();
        }

        protected void btnFusenTsuika_Click(object sender, EventArgs e)
        {
            SessionUtility.SetSession("HOME", "Popup");
            ifShinkiPopup.Src = "K2_Kouteipopup.aspx";
            mpeShinkiPopup.Show();
            updShinkiPopup.Update();
        }

        protected void btn_ClosePopup_Click(object sender, EventArgs e)
        {
            ifShinkiPopup.Src = "";
            mpeShinkiPopup.Hide();
            updShinkiPopup.Update();
        }

        public void HandleDeleteLabel(object sender, EventArgs e)
        {
            Button btnDelete = (sender as Button);
            UC02Label uc02label = (UC02Label)btnDelete.NamingContainer;
            Label lbId = uc02label.FindControl("lbId") as Label;

            UC01board ucBoard = (UC01board)LoadControl("~/UserControl/UC01board.ascx");

            Panel pnlFusen = (Panel)ucBoard.FindControl("pnlFusen");
            pnlFusen.Controls.Remove(uc02label);
            updFusenMain.Update();           

            K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();
            if (label.EndLable(lbId.Text))
            {
                SpVoice spv = new SpVoice();
                spv.Speak("おめでとうございます。");
                spv.Rate = 1;
                BindBoard();

            }
            else
            {
                return;
            }            

        }

    }
}