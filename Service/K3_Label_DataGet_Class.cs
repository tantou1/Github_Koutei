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
        public DataTable Get_Label()
        {
            MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
            String qr = "SELECT";
            qr += " lb.id as label_id";
            qr += " ,lb.title title";
            qr += " ,bo.label_order label_order";
            qr += " ,bo.koutei_id koutei_id";
            qr += " ,k.title koutei_name";
            qr += " from label lb";
            qr += " inner join board bo";
            qr += " on lb.id = bo.label_id";
            qr += " inner join koutei k";
            qr += " on bo.koutei_id = k.id";
            qr += " where lb.status='0'";
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
    }
}
