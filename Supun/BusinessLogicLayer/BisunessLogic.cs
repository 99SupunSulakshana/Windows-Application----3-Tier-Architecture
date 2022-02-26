using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using App_properties;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BisunessLogic
    {
        // Create objects for DataAccess class 
        public DataAcessLayer db = new DataAcessLayer();
        // Insert Customer Data
        public int insertCust(App_Prop info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Customers VALUES ('"+info.CustId+"','"+info.CustName+"','"+info.CustNIC+"','"+info.Email+"','"+info.Address+"','"+info.Cont+"')";
            return db.ExeNonQuery(cmd);


        }

        public int updateCust(App_Prop info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Customers SET ('" + info.CustId + "','" + info.CustName + "','" + info.CustNIC + "','" + info.Email + "','" + info.Address + "','" + info.Cont + "' WHERE ID='"+info.CustId+"')";
            return db.ExeNonQuery(cmd);
        }
        // Insert User login details
        public int insertUser(registration_prop reg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO logins VALUES ('" + reg.Username + "','" + reg.Password + "','" + reg.UserType + "')";
            return db.ExeNonQuery(cmd);
        }
        //Insert Notification details
        public int insertNotify(Notify_prop noty)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO notifications VALUES ('" + noty.Message + "','" + noty.Action + "')";
            return db.ExeNonQuery(cmd);
        }
        //Insert Events details
        public int insertEvents(Events ev)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO events VALUES ('" + ev.Eventid + "','" + ev.Count + "','" + ev.Duration + "','" + ev.Venue + "','"+ ev.Date +"','"+ ev.Type +"','"+ ev.Price +"','"+ ev.Total +"')";
            return db.ExeNonQuery(cmd);
        }
        // Insert Partcitipant details
        public int insertParticipant(Participant pt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO participant2 VALUES ('" + pt.CustomerId + "','" + pt.EventId + "','" + pt.Count + "','" + pt.Duration + "','" + pt.Venue + "','" + pt.Date + "','" + pt.Type + "','"+ pt.Price +"','" + pt.Total + "')";
            return db.ExeNonQuery(cmd);
        }

        //Login...
        public DataTable login(registration_prop info) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM logins where username='" + info.Username + "' and password='" + info.Password + "'";
            return db.ExeReader(cmd);

        }

        public DataTable viewcustomers(App_Prop info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Customers";
            return db.ExeReader(cmd);

        }
    }
}
