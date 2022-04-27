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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetFusenJouhou(DataRow drFusen)
        {
            //工程情報を表示の為
            lblKouteiId.Text = drFusen["koutei_id"].ToString();
            lblKouteiName.Text = drFusen["koutei_name"].ToString();
            lblLabelId.Text = "#"+drFusen["label_id"].ToString();
            lblTitle.Text = drFusen["title"].ToString();
        }
    }
}