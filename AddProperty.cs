using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class AddProperty : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=users;Password=United98");

        public AddProperty()
        {
            InitializeComponent();
        }

        private void UploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                PropertyPicture.Image = new Bitmap(opnfd.FileName);
                String PicPath = opnfd.FileName.ToString();
                PicturePath.Text = PicPath;
                PropertyPicture.ImageLocation = PicPath;
            }
        }

        private void forSaleButton_CheckedChanged(object sender, EventArgs e)
        {
            SalePanel.Visible = true;
            forRentPanel.Visible = false;
            
        }

        private void forRentButton_CheckedChanged(object sender, EventArgs e)
        {
            forRentPanel.Visible = true;
            SalePanel.Visible = false;
        }

        private void SaveProperty_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(this.PicturePath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] img = br.ReadBytes((int)fs.Length);
                String a = AddressBox.Text;
                String b = PropertyName.Text;
                String c = Plot_size.Text;
                String purpose = string.Empty;

                con.Open();
                if (forSaleButton.Checked)
                {
                    purpose = "for sale";
                }
                if (forRentButton.Checked)
                {
                    purpose = "for rent";
                }
                MySqlCommand cmd1 = new MySqlCommand(@"INSERT INTO `users`.`property`
                    (`Address`,`Property_pic`,`Property_Name`,`Plot_type`,`Plot_size`,`Purpose`)
                    VALUES ('" + a + "',@img,'" + b + "','" + Plot_Type.SelectedItem + "','" + c + "','" + purpose + "')", con);
                    cmd1.Parameters.Add(new MySqlParameter("@img", img));
                    cmd1.ExecuteNonQuery();
                if (forSaleButton.Checked)
                {       
                    MySqlCommand cmd4 = new MySqlCommand(@"INSERT INTO `users`.`sale_property`
                    (`Sale_price`,`Commission`,`Age_of_property`,`Kitchen_Layout`,`No_of_rooms`,`No_of_bathrooms`)
                    VALUES ('" + PropertyPrice.Text + "','" + SaleCommission.Text + "','" + PropertyAge.SelectedItem + "','" + KLayout.SelectedItem + "','" + RoomsSale.SelectedItem + "','" + BathroomsSale.SelectedItem + "')", con);
                    cmd4.ExecuteNonQuery();
                }
                else if (forRentButton.Checked)
                {
                    MySqlCommand cmd5 = new MySqlCommand(@"INSERT INTO `users`.`rent_property`
                    (`Rent`,`Gaurantor`,`Advance`,`Increase_in_rent`,`Break_clause`,`Furnished`,`No_of_rooms`,`No_of_bathrooms`,`Commission`)
                    VALUES ('" + Rent.Text + "','" + Gaurantor.SelectedItem + "','" + AdvanceRent.Text + "','" + IncreaseInRent.SelectedItem + "','" + BreakClause.SelectedItem + "','" + Furnished.SelectedItem + "','" + NoOfRoomsRent.SelectedItem + "','" + NoOfBathroomsRent.SelectedItem + "','" + CommissionOnRent.Text + "')", con);
                    cmd5.ExecuteNonQuery();
                }
               
                MySqlCommand cmd3 = new MySqlCommand(@"INSERT INTO `users`.`owner` 
            (`Owner_Name`,`Phone_No`,`Owner_Address`,`Owner_CNIC`)
            VALUES ('" + OwnerName.Text + "','" + OwnerNumber.Text + "','" + OwnerAddress.Text + "','" + OwnerCNIC.Text + "')", con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Property Added!");
                if (PropertyPicture.Image != null)
                {
                    PropertyPicture.Image.Dispose();
                    PropertyPicture.Image = null;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            AddressBox.Text = "";
            PropertyName.Text = "";
            Plot_Type.SelectedItem = null;
            Plot_size.Text = "";
            OwnerName.Text = "";
            OwnerNumber.Text = "";
            OwnerAddress.Text = "";
            OwnerCNIC.Text = "";
            if (forRentButton.Checked == true)
            {
                Rent.Text = "";
                Gaurantor.SelectedItem = null;
                CommissionOnRent.Text = "";
                AdvanceRent.Text = "";
                IncreaseInRent.SelectedItem = null;
                BreakClause.SelectedItem = null;
                NoOfBathroomsRent.SelectedItem = null;
                NoOfRoomsRent.SelectedItem = null;
                Furnished.SelectedItem = null;
            }
            if (forSaleButton.Checked == true)
            {
                PropertyPrice.Text = "";
                SaleCommission.Text = "";
                RoomsSale.SelectedItem = null;
                BathroomsSale.SelectedItem = null;
                PropertyAge.SelectedItem = null;
                KLayout.SelectedItem = null;
            }
            con.Close();
        }

        private void AddProperty_Load(object sender, EventArgs e)
        {
            forSaleButton.Checked = true;
        }

        private void CancelProperty_Click(object sender, EventArgs e)
        {
            Main master = (Main)Application.OpenForms["Main"];
            master.HomeButton.PerformClick();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            this.Controls.Remove(forSalePanel);
        }

        private void SaveSale_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(this.PicturePath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] img = br.ReadBytes((int)fs.Length);
                String a = AddressBox.Text;
                String b = PropertyName.Text;
                String c = Plot_size.Text;
                String purpose = string.Empty;

                con.Open();
                if (forSaleButton.Checked)
                {
                    purpose = "for sale";
                }
                if (forRentButton.Checked)
                {
                    purpose = "for rent";
                }
                MySqlCommand cmd1 = new MySqlCommand(@"INSERT INTO `users`.`property`
                (`Address`,`Property_pic`,`Property_Name`,`Plot_type`,`Plot_size`,`Purpose`)
                VALUES ('" + a + "',@img,'" + b + "','" + Plot_Type.SelectedItem + "','" + c + "','" + purpose + "')", con);
                cmd1.Parameters.Add(new MySqlParameter("@img", img));
                cmd1.ExecuteNonQuery();
                if (forSaleButton.Checked)
                {
                    MySqlCommand cmd4 = new MySqlCommand(@"INSERT INTO `users`.`sale_property`
                (`Sale_price`,`Commission`,`Age_of_property`,`Kitchen_Layout`,`No_of_rooms`,`No_of_bathrooms`)
                VALUES ('" + PropertyPrice.Text + "','" + SaleCommission.Text + "','" + PropertyAge.SelectedItem + "','" + KLayout.SelectedItem + "','" + RoomsSale.SelectedItem + "','" + BathroomsSale.SelectedItem + "')", con);
                    cmd4.ExecuteNonQuery();
                }
                else if (forRentButton.Checked)
                {
                    MySqlCommand cmd5 = new MySqlCommand(@"INSERT INTO `users`.`rent_property`
                (`Rent`,`Gaurantor`,`Advance`,`Increase_in_rent`,`Break_clause`,`Furnished`,`No_of_rooms`,`No_of_bathrooms`,`Commission`)
                VALUES ('" + Rent.Text + "','" + Gaurantor.SelectedItem + "','" + AdvanceRent.Text + "','" + IncreaseInRent.SelectedItem + "','" + BreakClause.SelectedItem + "','" + Furnished.SelectedItem + "','" + NoOfRoomsRent.SelectedItem + "','" + NoOfBathroomsRent.SelectedItem + "','" + CommissionOnRent.Text + "')", con);
                    cmd5.ExecuteNonQuery();
                }
               
                MySqlCommand cmd3 = new MySqlCommand(@"INSERT INTO `users`.`owner` 
            (`Owner_Name`,`Phone_No`,`Owner_Address`,`Owner_CNIC`)
            VALUES ('" + OwnerName.Text + "','" + OwnerNumber.Text + "','" + OwnerAddress.Text + "','" + OwnerCNIC.Text + "')", con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Property Added!");
                if (PropertyPicture.Image != null)
                {
                    PropertyPicture.Image.Dispose();
                    PropertyPicture.Image = null;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            AddressBox.Text = "";
            PropertyName.Text = "";
            Plot_Type.SelectedItem = null;
            Plot_size.Text = "";
            OwnerName.Text = "";
            OwnerNumber.Text = "";
            OwnerAddress.Text = "";
            OwnerCNIC.Text = "";
            if (forRentButton.Checked == true)
            {
                Rent.Text = "";
                Gaurantor.SelectedItem = null;
                CommissionOnRent.Text = "";
                AdvanceRent.Text = "";
                IncreaseInRent.SelectedItem = null;
                BreakClause.SelectedItem = null;
                NoOfBathroomsRent.SelectedItem = null;
                NoOfRoomsRent.SelectedItem = null;
                Furnished.SelectedItem = null;
            }
            if (forSaleButton.Checked == true)
            {
                PropertyPrice.Text = "";
                SaleCommission.Text = "";
                RoomsSale.SelectedItem = null;
                BathroomsSale.SelectedItem = null;
                PropertyAge.SelectedItem = null;
                KLayout.SelectedItem = null;
            }
            con.Close();
        }

        private void CancelSave_Click(object sender, EventArgs e)
        {
            Main master = (Main)Application.OpenForms["Main"];
            master.HomeButton.PerformClick();
        }
    }
}
