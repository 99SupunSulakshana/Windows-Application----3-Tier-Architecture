using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanjana_ICBT
{
    public partial class ManagerMain : Form
    {
        public ManagerMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationMenager rg = new RegistrationMenager();
            rg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerManager cm = new CustomerManager();
            cm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventManager ev = new EventManager();
            ev.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParticipatantManager pm = new ParticipatantManager();
            pm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            NotifyManager nm = new NotifyManager();
            nm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
    }
}
