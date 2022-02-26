using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_properties;
using BusinessLogicLayer;

namespace Sanjana_ICBT
{
    public partial class Login : Form
    {
        public registration_prop info = new registration_prop();
        public BisunessLogic bis = new BisunessLogic();
        public string utype;


        DataTable dt = new DataTable();

        public Login()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            username.Text = "";
            password.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            info.Username = username.Text;
            info.Password = password.Text;
            dt = bis.login(info);

            if(dt.Rows.Count > 0)
            { 

                utype = dt.Rows[0][3].ToString().Trim();
                if (utype=="MANAGER")
                {
                    MessageBox.Show("Your Login Successfully!!!!");
                    this.Hide();
                    ManagerMain mn = new ManagerMain();
                    mn.Show();

                }
                else if (utype=="ADMIN")
                {
                    MessageBox.Show("Your Login Successfully!!!!");
                    this.Hide();
                    AdminMain am = new AdminMain();
                    am.Show();

                }
                else
                {

                    MessageBox.Show("Your Login Successfully!!!!");
                    this.Hide();
                    Presentation_Layer.Customer mg = new Presentation_Layer.Customer();
                    mg.Show();

                }


            }
            else
            {
                MessageBox.Show("Please check your username and password!!!!");
                Clear();
            }

        }
    }
}
