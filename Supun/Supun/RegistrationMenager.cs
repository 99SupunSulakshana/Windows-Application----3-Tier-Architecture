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
    public partial class RegistrationMenager : Form
    {
        public RegistrationMenager()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void loadgrid()
        {
            DataTable dt = blu.GetAllUser();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public void reset()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboUserType.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void RegistrationMenager_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = blu.CreateUser(txtUsername.Text, txtPassword.Text, cboUserType.Text);
                if (i > 0)
                {
                    if (MessageBox.Show("User Details Created Successfully!", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                if (userid == 0)
                {
                    MessageBox.Show("Cannot Update user Details");
                }
                else
                {
                    int i = blu.UpdateUser(txtUsername.Text, txtPassword.Text, cboUserType.Text, userid);

                    if (i > 0)
                    {
                        MessageBox.Show("User Details Sucessfully!");
                        loadgrid();

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
                    int i = blu.DeleteUser(userid);
                    if (i > 0)
                    {
                        MessageBox.Show("User Deleted Sucessfully!");
                        loadgrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error info: " + ex.Message);
            }
        }

        public int userid = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cboUserType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = blu.GetUserbyUsername(txtSearch.Text);
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
    }
}
