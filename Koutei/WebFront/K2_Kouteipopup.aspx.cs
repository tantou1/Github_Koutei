using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Koutei.WebFront
{
    public partial class K2_Kouteipopup : System.Web.UI.Page
    {
        DataTable dt_koutei = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                if (SessionUtility.GetSession("HOME") != null)
                {
                    hdnHome.Value = SessionUtility.GetSession("HOME").ToString();
                    SessionUtility.SetSession("HOME", null);
                }
               
                K_ClientConnection_Class test = new K_ClientConnection_Class();
                DataTable dt = test.GetKoutei();
                //ポップアップにチェックボックスを作成のため
                foreach (DataRow row in dt.Rows)
                {
                    string option = " " + row["title"].ToString();
                    string optionID = row["id"].ToString();

                    CheckBoxList.Items.Add(new ListItem()
                    {
                        Text = option,
                        Value = optionID
                    });

                }
                //Div_Checkbox.Controls.Add(checkList);
            }
        }
        protected void BT_Cancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btn_ClosePopup','" + hdnHome.Value + "');", true);

        }

        protected void BT_Save_Click(object sender, EventArgs e)
        {
            if(TB_taskname.Text!="")
            {
                if (DataSave())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btn_ClosePopup','" + hdnHome.Value + "');", true);

                }
            }
        }

        private bool DataSave()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ckoutei");
                foreach (ListItem item in CheckBoxList.Items)
                {
                    if (item.Selected)
                    {
                        dt.Rows.Add(item.Value);
                    }
                }

            K2_Save_Class data_save = new K2_Save_Class();            if (!data_save.DataSave(dt, TB_taskname.Text))            {                return false;            }
            return true;

        }
        
    }
}