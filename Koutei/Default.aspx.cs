using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Koutei
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (DBUtilitycs.Server == "")
                {
                    DBUtilitycs.get_connetion_ifo();
                }
                // ログインメインページへ移動する
                Response.Redirect("WebFront/K1_Main.aspx");
            }
        }
    }
}