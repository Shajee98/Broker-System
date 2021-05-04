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
    public partial class FindPropertyforRent : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");
        MySqlDataReader mdr;
        
        public FindPropertyforRent()
        {
            InitializeComponent();
        }

        private void FindPropertyforRent_Load(object sender, EventArgs e)
        {
            con.Open();
            FindPropertyForRent();
        }
        private void FindPropertyForRent()
        {
            try
            {
                String forrent = "for rent";
                MySqlCommand cmd1 = new MySqlCommand(@"select Property_Name,Address,Property_pic from property where Purpose ='" + forrent + "'", con);
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
            /*MySqlCommand cmd1 = new MySqlCommand(@"select Property_Name,Address,Property_pic from property where Purpose  ='" + forrent + "'", con);
            mdr = cmd1.ExecuteReader();
            while (mdr.Read())
            {
                Panel panel = new Panel();
                panel.Width = PropertyForRent.Width - 30;
                Label label1 = new Label();
                label1.ForeColor = Color.Gainsboro;
                PictureBox property_pic = new PictureBox();
                panel.Controls.Add(label1);
                panel.Controls.Add(property_pic);
                label1.Text = mdr["Property_Name"].ToString();
                PropertyForRent.Controls.Add(panel);
            }
            mdr.Dispose();*/
        }

        private void iconButton1_Click(object sender, EventArgs e)
        { 
            String property_name = RentSearchBox.Text;
            MySqlCommand cmd2 = new MySqlCommand(@"select Property_Name,Address,Property_pic from property where Property_Name='" + property_name +"'", con);
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

        private void RentSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (RentSearchBox.Text != "")
            {
                dataGridView1.Controls.Clear();
            }
            else
                FindPropertyForRent();
                
        }
        public Boolean checkProperty()
        {
            String property_name = RentSearchBox.Text;
            String purpose = "for rent";
            MySqlCommand cmd2 = new MySqlCommand(@"select count(Property_Name) from property where Property_Name='" + property_name + "' and Purpose = '" + purpose + "'", con);
            int result = Convert.ToInt32(cmd2.ExecuteScalar());
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
