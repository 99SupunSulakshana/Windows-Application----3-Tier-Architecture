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
    public partial class ParticipatantManager : Form
    {
        public ParticipatantManager()
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

        public void reset()
        {
            txtcustid.Text = "";
            txtevid.Text = "";
            txtcount.Text = "";
            txtduration.Text = "";
            txtvenue.Text = "";
            txtdate.Text = "";
            txttype.Text = "";
            txtprice.Text = "";
            txttotal.Text = "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ParticipatantManager_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = blu.CreateParti(txtcustid.Text, txtevid.Text, Convert.ToInt32(txtcount.Text), txtduration.Text, txtvenue.Text, txtdate.Text, txttype.Text, Convert.ToInt32(txtprice.Text), Convert.ToInt32(txttotal.Text));
                if (i > 0)
                {
                    if (MessageBox.Show("Participatant Details Created Successfully!", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        loadgrid();
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot Create User details!!!!");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (partiid == 0)
                {
                    MessageBox.Show("Cannot Update Participatant Details");
                }
                else
                {
                    int i = blu.UpdateParti(txtcustid.Text, txtevid.Text, Convert.ToInt32(txtcount.Text), txtduration.Text, txtvenue.Text, txtdate.Text, txttype.Text, Convert.ToInt32(txtprice.Text), Convert.ToInt32(txttotal.Text), partiid);

                    if (i > 0)
                    {
                        MessageBox.Show("Participatant Details Sucessfully!");
                        loadgrid();
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete this ?", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int i = blu.DeleteParti(partiid);
                    if (i > 0)
                    {
                        MessageBox.Show("User Deleted Sucessfully!");
                        loadgrid();
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = blu.GetPartibyPartiid(txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    reset();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }
        public int partiid = 0;
        private void dataGridView1_RowHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            partiid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtcustid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtevid.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtcount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtduration.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtvenue.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtdate.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txttype.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txttotal.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerMain mm = new ManagerMain();
            mm.Show();
        }

        public void cal()
        {
            int a, b;
            a = Convert.ToInt32(txtcount.Text);
            b = Convert.ToInt32(txtprice.Text);

            int result = a * b;
            txttotal.Text = Convert.ToString(result);
        }
        private void txttotal_TextChanged(object sender, EventArgs e)
        {


        }

        private void txttotal_MouseClick(object sender, MouseEventArgs e)
        {
            cal();
        }
    }
}
