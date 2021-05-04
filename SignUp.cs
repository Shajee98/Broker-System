using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        Login f1 = new Login();
        public SignUp()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            String a = textBox1.Text;
            String b = textBox2.Text;
            String c = textBox3.Text;
            String d = textBox4.Text;
            String f = textBox5.Text;
            con.Open();
            MySqlCommand cmd1 = new MySqlCommand(@"INSERT INTO `users`.`register`
            (`FirstName`,
            `LastName`,
            `Username`,
            `Password`,
            `Broker_CNIC`)
            VALUES
            ('" + a + "','" + b + "','" + c + "','" + d + "','"+ f +"')", con);
            if (isnotNull() == false)
            {
                cmd1.Cancel();
                MessageBox.Show("Please fill in all the details.");
            }
            else
            {
                if (checkUsername() == false)
                {
                    cmd1.Cancel();
                    MessageBox.Show("Username already exist!");
                }
                else
                {
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully!");
                    this.Hide();
                    f1.Show();
                }
            }
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            textBox4.MaxLength = 14;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }  
        public Boolean checkUsername()
        {
            String a = textBox3.Text;
            MySqlCommand cmd2 = new MySqlCommand("select count(*) from register where (Username = @Username)", con);
            cmd2.Parameters.AddWithValue("@Username", a);
            int result = Convert.ToInt32(cmd2.ExecuteScalar());
            if (result > 0)
            {
                return false;
            }
            return true;
        }
        public Boolean isnotNull()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                return false;
            }
            return true;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    }
}
