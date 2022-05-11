using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.IO;

namespace Koutei.WebFront
{
    public partial class K2_Kouteipopup : System.Web.UI.Page
    {
        DataTable dt_koutei = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["filepath"] = "";
                if (SessionUtility.GetSession("HOME") != null)
                {
                    hdnHome.Value = SessionUtility.GetSession("HOME").ToString();
                    SessionUtility.SetSession("HOME", null);
                }
                TB_taskname.Focus();
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
            string file_path = "";
            string filename = "";
            if (Session["filepath"] != null)
            {
                file_path = Session["filepath"].ToString();
                file_path = file_path.Replace(@"\", @"\\");
                filename = Path.GetFileName(file_path);
            }

            K2_Save_Class data_save = new K2_Save_Class();            if (!data_save.DataSave(dt, TB_taskname.Text, file_path, filename))            {                return false;            }
            return true;

        }

        protected void UploadButton_Click(object sender, EventArgs e)        {            if (FileUpload.HasFile)            {                try                {
                    #region photoupload way1 (save server)
                    //string folderPath = Server.MapPath("~/UploadImgFiles/");
                    ////フォルダあるかどうかチェック
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    //フォルダ作成
                    //    Directory.CreateDirectory(folderPath);
                    //}

                    //ファイル名取る
                    string filename_ext = FileUpload.FileName;

                    K_ClientConnection_Class dhenkou = new K_ClientConnection_Class();
                    string s_datetime = dhenkou.Getdhenkou();//アップ日付取る

                    string filename = filename_ext.Split('.')[0];
                    string ext = filename_ext.Split('.')[1];

                    filename = filename + s_datetime + "." + ext;//アップ日付を付けてアップファイル名を編集


                    //FileUpload.SaveAs(folderPath + filename);//ファイルを保存


                    string local_folderPath = @"C:\UploadImg\";
                    if (!Directory.Exists(local_folderPath))
                    {
                        //フォルダを作成
                        Directory.CreateDirectory(local_folderPath);
                    }
                    FileUpload.SaveAs(local_folderPath + filename);

                    string file_path = local_folderPath + filename;

                    string imgurl = "";
                    #region 画像を表示
                    if (File.Exists(file_path))
                    {
                        FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bt = br.ReadBytes((Int32)fs.Length);
                        br.Close();
                        fs.Close();
                        string base64string = Convert.ToBase64String(bt, 0, bt.Length);

                        imgurl = "data:image/png;base64," + base64string;
                        Image.ImageUrl = imgurl;

                        Session["filepath"] = file_path;


                    }
                    #endregion

                    #endregion

                }                catch (Exception) { }            }        }
    }
}