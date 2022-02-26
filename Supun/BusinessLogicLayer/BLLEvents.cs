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
    public class BLLEvents
    {
        public int eventsid = 0;
        public DataTable GetAllevents()
        {
            return DAO.GetTable("select * from tblevent", null);
        }
        public DataTable GetEventbyEventid(string eventid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@eventid",eventid)
            };
            return DAO.GetTable("select * from tblevent where Eventid=@eventid", param);
        }

        public int CreateEvent(string eventid, int count, string duration, string venue, string date, string type, int price, int total)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@eventid", eventid),
                new SqlParameter("@count",count),
                new SqlParameter("@duration",duration),
                new SqlParameter("@venue",venue),
                new SqlParameter("@date",date),
                new SqlParameter("@type",type),
                new SqlParameter("@price",price),
                new SqlParameter("@total",total)

            };
            return DAO.ExecProce("insert into tblevent values(@eventid,@count,@duration,@venue,@date,@type,@price,@total)", param);

        }
        public int UpdateEvent(string eventid, int count, string duration, string venue, string date, string type, int price, int total, int eventsid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@eventid", eventid),
                new SqlParameter("@count",count),
                new SqlParameter("@duration",duration),
                new SqlParameter("@venue",venue),
                new SqlParameter("@date",date),
                new SqlParameter("@type",type),
                new SqlParameter("@price",price),
                new SqlParameter("@total",total),
                new SqlParameter("@eventsid",eventsid),
            };
            return DAO.ExecProce("update tblevent set Eventid=@eventid,Count=@count,Duration=@duration,Venue=@venue,Date=@date,Type=@type,Price=@price,Total=@total where id=@eventsid", param);

        }
        public int DeleteEvent(int eventsid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@eventsid",eventsid)
            };
            return DAO.ExecProce("delete from tblevent where id=@eventsid", param);

        }
    }
}
