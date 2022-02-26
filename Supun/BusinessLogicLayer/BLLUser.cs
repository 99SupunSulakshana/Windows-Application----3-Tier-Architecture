using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLUser
    {
        public int userid = 0;

        //Get All Data......................................................................
        public DataTable GetAllUser()
        {
            return DAO.GetTable("select * from logins", null);
        }
        public DataTable GetUserbyUsername(string username)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",username)
            };
            return DAO.GetTable("select * from logins where Username=@username", param);
        }
        //Create User details....................................................................
        public int CreateUser(string username, string password, string usertype)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password",password),
                new SqlParameter("@usertype",usertype)
            };
            return DAO.ExecProce("insert into logins values(@username,@password,@usertype)",param);

        }
        public int UpdateUser(string username, string password, string usertype, int userid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password",password),
                new SqlParameter("@usertype",usertype),
                new SqlParameter("@userid",userid)
            };
            return DAO.ExecProce("update logins set Username=@username,Password=@password,Usertype=@usertype where id=@userid", param);

        }
        public int DeleteUser(int userid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return DAO.ExecProce("delete from logins where id=@userid", param);

        }
    }
}
