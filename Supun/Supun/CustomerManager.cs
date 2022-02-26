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
    public partial class CustomerManager : Form
    {
        BLLCustomers blu = new BLLCustomers();
        public CustomerManager()
        {
            InitializeComponent();
        }
        public void loadgrid()
        {
            DataTable dt = blu.GetAllCustomers();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void CustomerManager_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        public void reset()
        {
            txtcustid.Text = "";
            txtcustname.Text = "";
            txtcustnic.Text = "";
            txtemail.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = blu.CreateCustomer(txtcustid.Text, txtcustname.Text, txtcustnic.Text, txtemail.Text, txtaddress.Text, Convert.ToInt32(txtcontact.Text));
                if (i > 0)
                {
                    if (MessageBox.Show("Customer Details Created Successfully!", "MessageInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                if (custid == 0)
                {
                    MessageBox.Show("Cannot Update Customer Details");
                }
                else
                {
                    int i = blu.UpdateCustomer(txtcustid.Text, txtcustname.Text, txtcustnic.Text, txtemail.Text, txtaddress.Text, Convert.ToInt32(txtcontact.Text), custid);

                    if (i > 0)
                    {
                        MessageBox.Show("Customer Details updated Sucessfully!");
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
                    int i = blu.DeleteCustomer(custid);
                    if (i > 0)
                    {
                        MessageBox.Show("Customer Deleted Sucessfully!");
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

        public int custid = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            custid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtcustid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcustname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtcustnic.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtcontact.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = blu.GetCustomerbyCustname(txtSearch.Text);
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
