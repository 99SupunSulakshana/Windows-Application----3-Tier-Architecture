using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Sanjana_ICBT
{
    public partial class ParticipatantCust : Form
    {
        public ParticipatantCust()
        {
            InitializeComponent();
        }
        BLLParticipant blu = new BLLParticipant();

        public void loadgrid()
        {
            DataTable dt = blu.GetAllParti();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void ParticipatantCust_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = blu.GetPartibyPartiid(txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain ad = new AdminMain();
            ad.Show();
        }
    }
}
