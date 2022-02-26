using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAO
    {
        //public SqlConnection con = new SqlConnection("Data Source=DESKTOP-R1DNECE;Initial Catalog=eventdb;Persist Security Info=True;User ID=sa;Password=1234");
        public static string connectionStr
        {

            get { return ConfigurationSettings.AppSettings["myconnection"]; }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(connectionStr);
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
        public static DataTable GetTable(string sql, SqlParameter[] param)
        {
            DataTable dt = null;
            using (SqlConnection con = DAO.GetConnection())
            {
               using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if(param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public static int ExecProce(string sql, SqlParameter[] param)
        {
            using (SqlConnection con = DAO.GetConnection())
            {
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //cmd.CommandType = CommandType.StoredProcedure;
                    if(param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
