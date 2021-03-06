using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace Service
{
    public class K3_Label_DataGet_Class
    {
        public DateTime dHENKOU { get; set; }

        public DataTable Get_Label(bool f_santou)
        {
            MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
            String qr = "SELECT";
            qr += " lb.id as label_id";
            qr += " ,lb.title title";
            qr += ",lb.anken_id as anken_id";
            qr += " ,bo.label_order label_order";
            qr += " ,bo.koutei_id koutei_id";
            qr += " ,k.title koutei_name";
            qr += " ,mf.sPATH_SERVER_SOURCE sPATH_SERVER_SOURCE";

            qr += " from label lb";

            qr += " inner join anken a on lb.anken_id = a.id";

            qr += " inner join board bo";
            qr += " on lb.id = bo.label_id";

            qr += " inner join koutei k";
            qr += " on bo.koutei_id = k.id";

            qr += " left join m_file mf";
            qr += " on lb.id = mf.label_id";

            if (f_santou == true)
            {
                qr += " inner join(select min(b2.koutei_id) as koutei_id,b2.label_id";
                qr += " from board b2";
                qr += " group by b2.label_id) mn";
                qr += " on bo.koutei_id = mn.koutei_id and bo.label_id = mn.label_id";
            }

            qr += " where lb.status='0'";
            if (f_santou == true)
            {
                qr += " group by a.id";
            }
            qr += " order by label_order asc";

            DataTable dt = new DataTable();
            con.Close();
            con.Open();
            using (MySqlDataAdapter adap = new MySqlDataAdapter(qr, con))
            {
                adap.Fill(dt);
            }
            con.Close();
            return dt;
        }
        public bool EndLable(string labelid)
        {
            MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);

            dHENKOU = ConstantVal.Fu_GetDateTime(con);

            String qr_update = "Update ";
            qr_update += " label";
            qr_update += " SET status='1'";
            qr_update += ",updated_at='" +dHENKOU + "'";
            qr_update += " where id='"+ labelid+"'";

            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {
                MySqlCommand c = new MySqlCommand(qr_update, con);
                c.ExecuteNonQuery();
                tran.Commit();
                con.Close();
            }
            catch
            {
                try
                {
                    tran.Rollback();
                }
                catch
                {
                }
                con.Close();
                return false;
            }

            return true;
        }

        public string Get_TaskCount(string koutei_id)
        {
            MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
            String qr = "SELECT";
            qr += " count(koutei_id) as koutei_id";
            qr += " from board bo";
            qr += " inner join label lb";
            qr += " on bo.label_id= lb.id";
            qr += " where status='0' and";
            qr += " koutei_id='" + koutei_id + "'";

            DataTable dt = new DataTable();

            con.Close();
            con.Open();
            using (MySqlDataAdapter adap = new MySqlDataAdapter(qr, con))
            {
                adap.Fill(dt);
            }
            con.Close();
            return dt.Rows[0][0].ToString();
        }
    }
}
