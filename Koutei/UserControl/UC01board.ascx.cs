using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Koutei.UserControl
{
    public partial class UC01board : System.Web.UI.UserControl
    {
        
        #region "工程ボードに付箋データ設定"

        public void SetPendingFusenBoardData()
        {
            //工程タイトルを表示の為
            pnlFusen.CssClass = "UC02FusenInfoDiv PendingBoardDiv";
            divPendingHeader.Style.Add("display", "block");
            lblPendingHeader.Text = Session["BoardName"].ToString();
            lblPendingHeader_ID.Text = Session["BoardID"].ToString();
            if (Session["TaskCount"].ToString() != "0")
            {
                lblcount.Text = Session["TaskCount"].ToString();
            }
            divFusenList.Style.Add("background-color", "rgb(197,224,245)");
        }

        #endregion

    }
}