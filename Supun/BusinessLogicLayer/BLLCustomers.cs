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
    public class BLLCustomers
    {
        public int customerid = 0;
        public DataTable GetAllCustomers()
        {
            return DAO.GetTable("select * from Customers", null);
        }

        public DataTable GetCustomerbyCustname(string custid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid",custid)
            };
            return DAO.GetTable("select * from Customers where Custid=@custid", param);
        }

        public int CreateCustomer(string custid, string custname, string custnic, string email, string address, int contact)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid", custid),
                new SqlParameter("@custname",custname),
                new SqlParameter("@custnic",custnic),
                new SqlParameter("@email",email),
                new SqlParameter("@address",address),
                new SqlParameter("@contact",contact),
            };
            return DAO.ExecProce("insert into Customers values(@custid,@custname,@custnic,@email,@address,@contact)", param);

        }

        public int UpdateCustomer(string custid, string custname, string custnic, string email, string address, int contact,int customerid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custid", custid),
                new SqlParameter("@custname",custname),
                new SqlParameter("@custnic",custnic),
                new SqlParameter("@email",email),
                new SqlParameter("@address",address),
                new SqlParameter("@contact",contact),
                new SqlParameter("@customerid",customerid)
            };
            return DAO.ExecProce("update Customers set Custid=@custid,Custname=@custname,Custnic=@custnic,Email=@email,Address=@address,Contact=@contact where id=@customerid", param);

        }

        public int DeleteCustomer(int customerid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@customerid",customerid)
            };
            return DAO.ExecProce("delete from Customers where id=@customerid", param);

        }

    }
}
