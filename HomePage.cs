using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class AddNewProperty : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");
        
        public AddNewProperty()
        {
            InitializeComponent();
        }

        
        private void HomePage_Load(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(@"select Property_Name,Property_pic from property", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
               
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

        Button b1 = new Button();
        Button b2 = new Button();
        Label l1 = new Label();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form property = new Form();
            property.Size = new Size(600, 411);
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.AutoScroll = true;
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.TopDown;
            Label l2 = new Label();
            Label l3 = new Label();
            Panel p1 = new Panel();
            l1.AutoSize = true;
            l2.AutoSize = true;
            l3.AutoSize = true;
            l1.ForeColor = Color.White;
            l2.ForeColor = Color.White;
            l3.ForeColor = Color.White;
            MySqlCommand cmd2 = new MySqlCommand(@"select Property_Name,Address from property where Property_Name = '" + dataGridView1.CurrentCell.Value.ToString() + "'", con);
            MySqlCommand cmd3 = new MySqlCommand(@"select Sale_Price,Commission,Age_of_Property,Kitchen_Layout,No_of_rooms,No_of_bathrooms from sale_property", con);
            MySqlDataReader mdr2 = cmd2.ExecuteReader();
            while (mdr2.Read())
            {
                l1.Text = "Property Name: " + mdr2["Property_Name"].ToString();
                l3.Text = "Address: " + mdr2["Address"].ToString();
            }
            mdr2.Dispose();
            MySqlDataReader mdr3 = cmd3.ExecuteReader();
            while (mdr3.Read())
            {
                l2.Text = "Price: " + mdr3["Sale_Price"].ToString() + "\n" +
                 "Commission: " + mdr3["Commission"].ToString() + "\n" +
                 "Age_of_Property" + mdr3["Age_of_Property"].ToString() + "\n" +
                 "Kitchen Layout: " + mdr3["Kitchen_Layout"].ToString() + "\n" +
                 "No. of Rooms: " + mdr3["No_of_rooms"].ToString() + "\n" +
                 "No. of Bathrooms: " + mdr3["No_of_bathrooms"].ToString();
            }
            mdr3.Dispose();

            b1.Text = "Edit";
            b2.Text = "Delete";
            b1.ForeColor = Color.White;
            b1.BackColor = Color.Gray;
            b2.ForeColor = Color.White;
            b2.BackColor = Color.Gray;
            flp.Controls.Add(l1);
            flp.Controls.Add(l2);
            b1.Click += new EventHandler(button1_Click);
            b2.Click += new EventHandler(button2_Click);
            
            
            MySqlCommand cmd1 = new MySqlCommand(@"select Property_pic from property where Property_Name = '" + dataGridView1.CurrentCell.Value.ToString() + "'", con);
            MySqlDataReader mdr1 = cmd1.ExecuteReader();

            property.BackColor = Color.FromArgb(30, 31, 68);
            PictureBox pb = new PictureBox();
            p1.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;

            while (mdr1.Read())
            {
                long len = mdr1.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                mdr1.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                MemoryStream ms = new MemoryStream(array);
                pb.Image = Image.FromStream(ms);
            }
            flp.Controls.Add(p1);
            flp.Controls.Add(b1);
            flp.Controls.Add(b2);
            property.Controls.Add(flp);
            property.Show();
            mdr1.Dispose();
        }
        private void button2_Click(object sender, EventArgs e) {
            Button b2 = sender as Button;
                MySqlCommand cmd1 = new MySqlCommand(@"Delete from property where Property_Name = '" + l1.Text.Substring(15) + "'", con);
                cmd1.ExecuteNonQuery();
                this.Close();
            MessageBox.Show("Property Deleted");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Main master = (Main)Application.OpenForms["Main"];
            master.AddButton.PerformClick();
            this.Close();
        }
       }

    }

