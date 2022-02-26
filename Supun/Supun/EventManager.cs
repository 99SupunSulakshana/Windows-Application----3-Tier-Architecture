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
    public partial class EventManager : Form
    {
        public EventManager()
        {
            InitializeComponent();
        }
        BLLEvents blu = new BLLEvents();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventsid == 0)
                {
                    MessageBox.Show("Cannot Update Event Details");
                }
                else
                {
                    int i = blu.UpdateEvent(txtevID.Text, Convert.ToInt32(txtCount.Text), txtDuration.Text, txtVenue.Text, txtDateTime.Text, txttype.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtTotal.Text), eventsid);

                    if (i > 0)
                    {
                        MessageBox.Show("Event Details Updated Sucessfully!");
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

        public void loadgrid()
        {
            DataTable dt = blu.GetAllevents();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public void reset()
        {
            txtevID.Text = "";
            txtCount.Text = "";
            txtDuration.Text = "";
            txtVenue.Text = "";
            txtDateTime.Text = "";
            txttype.Text = "";
            txtPrice.Text = "";
            txtTotal.Text = "";
        }

        private void EventManager_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = blu.CreateEvent(txtevID.Text, Convert.ToInt32(txtCount.Text),txtDuration.Text, txtVenue.Text, txtDateTime.Text, txttype.Text,Convert.ToInt32(txtPrice.Text),Convert.ToInt32(txtTotal.Text));
                if (i > 0)
                {
                    if (MessageBox.Show("Event Details Created Successfully!", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        loadgrid();
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot Create Event details!!!!");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }

        public int eventsid = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            eventsid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtevID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCount.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDuration.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtVenue.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDateTime.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txttype.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete this ?", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int i = blu.DeleteEvent(eventsid);
                    if (i > 0)
                    {
                        MessageBox.Show("Event Deleted Sucessfully!");
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
                DataTable dt = blu.GetEventbyEventid(txtSearch.Text);
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
            ManagerMain mm = new ManagerMain();
            mm.Show();
            
        }

        public void cal()
        {
            int a, b;
            a = Convert.ToInt32(txtCount.Text);
            b = Convert.ToInt32(txtPrice.Text);

            int result = a * b;
            txtTotal.Text = Convert.ToString(result);
        }

        private void txtTotal_MouseClick(object sender, MouseEventArgs e)
        {
            cal();
        }
    }
}
