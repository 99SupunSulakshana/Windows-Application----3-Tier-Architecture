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
    public partial class CustomerMain : Form
    {
        public CustomerMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsCust ec = new EventsCust();
            ec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParticipatantCust pc = new ParticipatantCust();
            pc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
    }
}
