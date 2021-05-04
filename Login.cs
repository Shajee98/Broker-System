using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");
        private void button1_Click(object sender, EventArgs e)
        {
            isRegistered();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp f2 = new SignUp();
            f2.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.MaxLength = 14;
        }

        public Boolean isEmpty()
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                label5.Visible = true;
                label6.Visible = true;
                return true;
            }
            if (textBox1.Text == "")
            {
                label5.Visible = true;
                label6.Visible = false;
                return true;
            }
            if (textBox2.Text == "")
            {
                label6.Visible = true;
                label5.Visible = false;
                return true;
            }
            label5.Visible = false;
            label6.Visible = false;
            return false;
        }
        public void isRegistered()
        {
            if (isEmpty() == false)
            {
                con.Open();
                String username = textBox1.Text;
                String password = textBox2.Text;
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from register where (Username = @Username)", con);
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Password", password);
                cmd1.ExecuteNonQuery();
                int result1 = Convert.ToInt32(cmd1.ExecuteScalar());

                if (result1 > 0)
                {
                    MySqlCommand cmd2 = new MySqlCommand("select count(*) from register where (Username = @Username and Password = @Password)", con);
                    cmd2.Parameters.AddWithValue("@Username", username);
                    cmd2.Parameters.AddWithValue("@Password", password);
                    cmd2.ExecuteNonQuery();
                    int result2 = Convert.ToInt32(cmd2.ExecuteScalar());

                    if (result2 > 0)
                    {
                        Main f4 = new Main();
                        f4.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please fill in correct details.");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("This username is not registered!");
                    con.Close();
                }
            }
            else
            {
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
