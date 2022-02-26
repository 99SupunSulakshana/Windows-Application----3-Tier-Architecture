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
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserAccess rg = new AdminUserAccess();
            rg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminNotify nm = new AdminNotify();
            nm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
    }
}
