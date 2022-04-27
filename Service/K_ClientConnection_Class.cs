using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Service
{
    public class K_ClientConnection_Class
    {
        public DataTable GetKoutei()
        {
            MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
            String qr = "SELECT * FROM sample_np.koutei;";
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
