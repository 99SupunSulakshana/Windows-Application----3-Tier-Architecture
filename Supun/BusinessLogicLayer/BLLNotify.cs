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
    public class BLLNotify
    {
        public int notifyid = 0;
        public DataTable GetAllNotify()
        {
            return DAO.GetTable("select * from notifications", null);
        }
        public DataTable GetNotifybyAction(string action)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@action",action)
            };
            return DAO.GetTable("select * from notifications where Action=@action", param);
        }

        public int CreateNotify(string message, string action)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@message", message),
                new SqlParameter("@action",action)
            };
            return DAO.ExecProce("insert into notifications values(@message,@action)", param);

        }
        public int UpdateNotify(string message, string action, int notifyid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@message", message),
                new SqlParameter("@action",action),
                new SqlParameter("@notifyid", notifyid)
            };
            return DAO.ExecProce("update notifications set Message=@message,Action=@action where id=@notifyid", param);

        }
        public int DeleteNotify(int notifyid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@notifyid",notifyid)
            };
            return DAO.ExecProce("delete from notifications where id=@notifyid", param);

        }
    }
}
