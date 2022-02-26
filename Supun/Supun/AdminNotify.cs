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
    public partial class AdminNotify : Form
    {
        public AdminNotify()
        {
            InitializeComponent();
        }
        BLLNotify blu = new BLLNotify();

        public void loadgrid()
        {
            DataTable dt = blu.GetAllNotify();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public void reset()
        {
            txtmessage.Text = "";
            cboaction.SelectedIndex = 0;
        }
        private void AdminNotify_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = blu.CreateNotify(txtmessage.Text, cboaction.Text);
                if (i > 0)
                {
                    if (MessageBox.Show("Notification Details Created Successfully!", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                if (notifyid == 0)
                {
                    MessageBox.Show("Cannot Update user Details");
                }
                else
                {
                    int i = blu.UpdateNotify(txtmessage.Text, cboaction.Text, notifyid);

                    if (i > 0)
                    {
                        MessageBox.Show("User Details Sucessfully!");
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
                    int i = blu.DeleteNotify(notifyid);
                    if (i > 0)
                    {
                        MessageBox.Show("Message Deleted Sucessfully!");
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

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        public int notifyid = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            notifyid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtmessage.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cboaction.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = blu.GetNotifybyAction(txtSearch.Text);
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
