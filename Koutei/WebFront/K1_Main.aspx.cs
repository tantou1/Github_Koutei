﻿using System;
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
            PinChange();

                //工程ボードの中に付箋を設定する
                Panel pnlFusen = (Panel)ucFusenBoard.FindControl("pnlFusen");
                        pnlFusen.Controls.Add(ucLabelJouhou);
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