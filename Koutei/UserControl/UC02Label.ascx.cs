using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Koutei.UserControl
{
    public partial class UC02Label : System.Web.UI.UserControl
    {
        public event EventHandler DeleteLabel;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetFusenJouhou(DataRow drFusen)
        {
            //工程情報を表示の為
            lblKouteiId.Text = drFusen["koutei_id"].ToString();//工程コード
            lblKouteiName.Text = drFusen["koutei_name"].ToString();//工程イトル
            lblLabelId.Text = "#"+drFusen["label_id"].ToString();//ラベルコード
            lbId.Text = drFusen["label_id"].ToString();//ラベルコード
            lblTitle.Text = drFusen["title"].ToString();//ラベルタイトル
        }

        protected void Button1_Click(object sender, EventArgs e)
        {           
            DeleteLabel(sender, e);
        }
    }
}