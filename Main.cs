using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        
        private IconButton currBtn;
        private System.Windows.Forms.Panel LeftBorderBtn;
        private Form currChildForm;
        public Main()
        {
            InitializeComponent();
            LeftBorderBtn = new System.Windows.Forms.Panel();
            LeftBorderBtn.Size = new System.Drawing.Size(7,50);
            Menupanel.Controls.Add(LeftBorderBtn);
        }
        private void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currBtn = (IconButton)senderBtn;
                currBtn.BackColor = Color.FromArgb(37, 36, 81);
                currBtn.ForeColor = color;
                currBtn.TextAlign = ContentAlignment.MiddleCenter;
                currBtn.IconColor = color;
                currBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currBtn.ImageAlign = ContentAlignment.MiddleRight;
                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new System.Drawing.Point(0, currBtn.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currBtn != null)
            {
                currBtn.BackColor = Color.FromArgb(31,30,68);
                currBtn.ForeColor = Color.Gainsboro;
                currBtn.TextAlign = ContentAlignment.MiddleLeft;
                currBtn.IconColor = Color.Gainsboro;
                currBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currChildForm != null)
            {
                currChildForm.Close();
            }
            currChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            DesktopPanel.Controls.Add(childForm);
            DesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        public void HomeButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.Gainsboro);
            OpenChildForm(new AddNewProperty());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.Gainsboro);
            OpenChildForm(new AddProperty());
        }

        private void FindRentButton_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.Gainsboro);
            OpenChildForm(new FindPropertyforSale());
        }

        private void FindSaleButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.Gainsboro);
            OpenChildForm(new FindPropertyforRent());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
