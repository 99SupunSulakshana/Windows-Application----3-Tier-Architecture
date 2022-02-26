using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAcessLayer
    {
        // Connect the sql connection
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-R1DNECE;Initial Catalog=eventdb;Persist Security Info=True;User ID=sa;Password=1234");

        // Create a function getcon to check whether the Db connection is open
        public SqlConnection getcon()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
            finally
            {
                Console.Write("Re- try with your Connection.");
            }

            return con;
        }

        // Create a function ExeNon Query to Perform Insert, Update, Delete..etc.
        public int ExeNonQuery(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            int rowsaffected = -1;
            rowsaffected = cmd.ExecuteNonQuery();
            return rowsaffected;

        }

        // Create a Fubction ExeScalar to Retrieve a Single Value from Db or Query
        public object ExeScalar(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            object obj = -1;
            obj = cmd.ExecuteScalar();
            con.Close();
            return obj;
        }

        // Create a function ExeReader to perform select query
        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            SqlDataReader sdr;
            DataTable dt = new DataTable();

            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;

        }
    }
}
