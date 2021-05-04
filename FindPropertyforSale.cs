using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FindPropertyforSale : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");
       
        public FindPropertyforSale()
        {
            InitializeComponent();
        }

        private void FindPropertyforSale_Load(object sender, EventArgs e)
        {
            con.Open();
            FindPropertyForSale();
        }
        private void FindPropertyForSale()
        {
            try
            {
                String forsale = "for sale";
                MySqlCommand cmd1 = new MySqlCommand(@"select Property_Name,Address,Property_pic from property where Purpose ='" + forsale + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                dataGridView1.RowTemplate.Height = 100;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowHeadersVisible = false;
                /*dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

       
        public Boolean checkProperty()
        {
            String property_name = SaleSearchBox.Text;
            String purpose = "for sale";
            MySqlCommand cmd2 = new MySqlCommand(@"select count(Property_Name) from property where Property_Name='" + property_name + "'and Purpose = '" + purpose + "'", con);
            int result = Convert.ToInt32(cmd2.ExecuteScalar());
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        private void SaleSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (SaleSearchBox.Text != "")
            {
                dataGridView1.Controls.Clear();
            }
            else
                FindPropertyForSale();
        }

        private void SearchSale_Click_1(object sender, EventArgs e)
        {
            String property_name = SaleSearchBox.Text;
            MySqlCommand cmd2 = new MySqlCommand(@"select Property_Name,Address,Property_pic from property where Property_Name='" + property_name + "'", con);
            if (checkProperty() == false)
            {
                MessageBox.Show("No property by this name exist.");
            }
            else
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    dataGridView1.RowTemplate.Height = 100;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersVisible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
    }
