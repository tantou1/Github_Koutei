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

namespace Koutei.WebFront
{
    public partial class K1_Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PinChange();            K_ClientConnection_Class test = new K_ClientConnection_Class();            DataTable dt = test.GetKoutei();            K3_Label_DataGet_Class label = new K3_Label_DataGet_Class();            DataTable dtLabel = label.Get_Label();            for (int i = 0; i < dt.Rows.Count; i++)            {                //工程ボードを設定する                UC01board ucFusenBoard = (UC01board)LoadControl("~/UserControl/UC01board.ascx");                ucFusenBoard.ID = "ucPending" + dt.Rows[i]["id"].ToString();                Session["BoardName"] = dt.Rows[i]["title"].ToString();                Session["BoardID"] = dt.Rows[i]["id"].ToString();                ucFusenBoard.SetPendingFusenBoardData();                pnlPending.Controls.Add(ucFusenBoard);                DataRow[] drresult = dtLabel.Select("koutei_id = " + dt.Rows[i]["id"].ToString());                DataTable dt_label_koutei = dtLabel.Clone();                if (drresult.Length > 0)                {                    dt_label_koutei = drresult.CopyToDataTable();                }

                //工程ボードの中に付箋を設定する
                Panel pnlFusen = (Panel)ucFusenBoard.FindControl("pnlFusen");                if (dt_label_koutei.Rows.Count > 0)                {                    for (int j = 0; j < dt_label_koutei.Rows.Count; j++)                    {                        UC02Label ucLabelJouhou = (UC02Label)LoadControl("~/UserControl/UC02Label.ascx");                        ucLabelJouhou.ID = "uc" + (j + 1);                        ucLabelJouhou.SetFusenJouhou(dt_label_koutei.Rows[j]);
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
    }
}