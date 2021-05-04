namespace WindowsFormsApp1
{
    partial class FindPropertyforSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaleSearchBox = new System.Windows.Forms.TextBox();
            this.SearchSale = new FontAwesome.Sharp.IconButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaleSearchBox
            // 
            this.SaleSearchBox.Location = new System.Drawing.Point(12, 7);
            this.SaleSearchBox.Name = "SaleSearchBox";
            this.SaleSearchBox.PlaceholderText = "Search Property";
            this.SaleSearchBox.Size = new System.Drawing.Size(266, 23);
            this.SaleSearchBox.TabIndex = 0;
            // 
            // SearchSale
            // 
            this.SearchSale.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SearchSale.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.SearchSale.IconColor = System.Drawing.Color.Black;
            this.SearchSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SearchSale.IconSize = 18;
            this.SearchSale.Location = new System.Drawing.Point(274, 7);
            this.SearchSale.Name = "SearchSale";
            this.SearchSale.Rotation = 0D;
            this.SearchSale.Size = new System.Drawing.Size(25, 23);
            this.SearchSale.TabIndex = 1;
            this.SearchSale.UseVisualStyleBackColor = true;
            this.SearchSale.Click += new System.EventHandler(this.SearchSale_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.dataGridView1.Location = new System.Drawing.Point(-3, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(604, 416);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // FindPropertyforSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(600, 447);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SearchSale);
            this.Controls.Add(this.SaleSearchBox);
            this.Name = "FindPropertyforSale";
            this.Text = "FindPropertyforSale";
            this.Load += new System.EventHandler(this.FindPropertyforSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SaleSearchBox;
        private FontAwesome.Sharp.IconButton SearchSale;
        private FontAwesome.Sharp.IconButton Sale;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}