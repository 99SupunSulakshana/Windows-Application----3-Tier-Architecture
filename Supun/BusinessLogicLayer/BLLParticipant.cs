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
    public class BLLParticipant
    {
        public int partiid = 0;
        public DataTable GetAllParti()
        {
            return DAO.GetTable("select * from tblparticipant", null);
        }
        public DataTable GetPartibyPartiid(string custid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid",custid)
            };
            return DAO.GetTable("select * from tblparticipant where Custid=@custid", param);
        }

        public int CreateParti(string custid,string eventid, int count, string duration, string venue, string date, string type, int price, int total)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid", custid),
                new SqlParameter("@eventid", eventid),
                new SqlParameter("@count",count),
                new SqlParameter("@duration",duration),
                new SqlParameter("@venue",venue),
                new SqlParameter("@date",date),
                new SqlParameter("@type",type),
                new SqlParameter("@price",price),
                new SqlParameter("@total",total)
            };
            return DAO.ExecProce("insert into tblparticipant values(@custid,@eventid,@count,@duration,@venue,@date,@type,@price,@total)", param);

        }
        public int UpdateParti(string custid, string eventid, int count, string duration, string venue, string date, string type, int price, int total, int partiid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid", custid),
                new SqlParameter("@eventid", eventid),
                new SqlParameter("@count",count),
                new SqlParameter("@duration",duration),
                new SqlParameter("@venue",venue),
                new SqlParameter("@date",date),
                new SqlParameter("@type",type),
                new SqlParameter("@price",price),
                new SqlParameter("@total",total),
                new SqlParameter("@partiid",partiid)
            };
            return DAO.ExecProce("update tblparticipant set Custid=@custid,Eventid=@eventid,Count=@count,Duration=@duration,Venue=@venue,Date=@date,Type=@type,Price=@price,Total=@total where id=@partiid", param);

        }
        public int DeleteParti(int partiid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@partiid",partiid)
            };
            return DAO.ExecProce("delete from tblparticipant where id=@partiid", param);

        }
    }
}
