using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Koutei.UserControl
{
    public partial class UC03Main : System.Web.UI.UserControl
    {
        public event EventHandler TaskTsuika;
        public event EventHandler Santou_Changed;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMainLayout()
        {          

            
        }

        protected void btnFusenTsuika_Click(object sender, EventArgs e)
        {
            TaskTsuika(sender, e);
        }

        protected void chk_santo_CheckedChanged(object sender, EventArgs e)
        {
            Santou_Changed(sender, e);
        }
    }
}