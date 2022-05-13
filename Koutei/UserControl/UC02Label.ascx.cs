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
        public void SetFusenJouhou(DataRow drFusen)
        {
            //工程情報を表示の為
            lblKouteiId.Text = drFusen["koutei_id"].ToString();//工程コード
            lblKouteiName.Text = drFusen["koutei_name"].ToString();//工程イトル
            lblLabelId.Text = drFusen["label_id"].ToString();//ラベルコード
            lbId.Text = drFusen["label_id"].ToString();//ラベルコード
            lblTitle.Text = drFusen["title"].ToString();//ラベルタイトル
            lblAnkenId.Text = "#" + drFusen["anken_id"].ToString();//案件コード

            #region 画像表示            
            if (drFusen["sPATH_SERVER_SOURCE"].ToString() != "")
            {
                string file_path = drFusen["sPATH_SERVER_SOURCE"].ToString();
                if (File.Exists(file_path))
                {
                    FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bt = br.ReadBytes((Int32)fs.Length);
                    br.Close();
                    fs.Close();
                    string base64string = Convert.ToBase64String(bt, 0, bt.Length);

                    string imgurl = "data:image/png;base64," + base64string;

                    Image.ImageUrl = imgurl;

                    divFusenJouhou.Attributes.Add("style", "height:186px");
                    
                }
                else
                {
                    Image.Visible = false;
                }
            }
            else
            {
                Image.Visible = false;
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {           
            DeleteLabel(sender, e);
        }
    }
}