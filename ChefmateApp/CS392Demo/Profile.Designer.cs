using System;
using System.Windows.Forms;

namespace RecipeAPIDemo
{
    partial class Profile
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
            this.txtUsername = new System.Windows.Forms.Label();
            this.btnSaved = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPantry = new System.Windows.Forms.Button();
            this.help_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.forage_btn = new System.Windows.Forms.Button();
            this.profile_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.ShoppingListbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.txtUsername.Location = new System.Drawing.Point(44, 41);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(176, 49);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username";
            this.txtUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtUsername.UseCompatibleTextRendering = true;
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            // 
            // btnSaved
            // 
            this.btnSaved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.btnSaved.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.btnSaved.Location = new System.Drawing.Point(403, 159);
            this.btnSaved.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaved.Name = "btnSaved";
            this.btnSaved.Size = new System.Drawing.Size(237, 50);
            this.btnSaved.TabIndex = 1;
            this.btnSaved.Text = "Saved Recipes";
            this.btnSaved.UseVisualStyleBackColor = false;
            this.btnSaved.Click += new System.EventHandler(this.btnSaved_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.btnLogout.Location = new System.Drawing.Point(403, 384);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(237, 50);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPantry
            // 
            this.btnPantry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.btnPantry.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPantry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.btnPantry.Location = new System.Drawing.Point(403, 301);
            this.btnPantry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPantry.Name = "btnPantry";
            this.btnPantry.Size = new System.Drawing.Size(237, 50);
            this.btnPantry.TabIndex = 4;
            this.btnPantry.Text = "Pantry";
            this.btnPantry.UseVisualStyleBackColor = false;
            this.btnPantry.Click += new System.EventHandler(this.btnPantry_Click);
            // 
            // help_btn
            // 
            this.help_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.help_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.help_btn.Location = new System.Drawing.Point(831, 566);
            this.help_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.help_btn.Name = "help_btn";
            this.help_btn.Size = new System.Drawing.Size(216, 73);
            this.help_btn.TabIndex = 19;
            this.help_btn.Text = "Help";
            this.help_btn.UseVisualStyleBackColor = false;
            this.help_btn.Click += new System.EventHandler(this.help_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.shop_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.shop_btn.Location = new System.Drawing.Point(626, 566);
            this.shop_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(216, 73);
            this.shop_btn.TabIndex = 18;
            this.shop_btn.Text = "Shop";
            this.shop_btn.UseVisualStyleBackColor = false;
            this.shop_btn.Click += new System.EventHandler(this.shop_btn_Click);
            // 
            // forage_btn
            // 
            this.forage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.forage_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forage_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.forage_btn.Location = new System.Drawing.Point(414, 566);
            this.forage_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.forage_btn.Name = "forage_btn";
            this.forage_btn.Size = new System.Drawing.Size(216, 73);
            this.forage_btn.TabIndex = 17;
            this.forage_btn.Text = "Forage";
            this.forage_btn.UseVisualStyleBackColor = false;
            this.forage_btn.Click += new System.EventHandler(this.forage_btn_Click);
            // 
            // profile_btn
            // 
            this.profile_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.profile_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.profile_btn.Location = new System.Drawing.Point(207, 566);
            this.profile_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.profile_btn.Name = "profile_btn";
            this.profile_btn.Size = new System.Drawing.Size(216, 73);
            this.profile_btn.TabIndex = 16;
            this.profile_btn.Text = "Profile";
            this.profile_btn.UseVisualStyleBackColor = false;
            this.profile_btn.Click += new System.EventHandler(this.profile_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.search_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.search_btn.FlatAppearance.BorderSize = 5;
            this.search_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.search_btn.Location = new System.Drawing.Point(-3, 566);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(216, 73);
            this.search_btn.TabIndex = 15;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // ShoppingListbtn
            // 
            this.ShoppingListbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.ShoppingListbtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingListbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.ShoppingListbtn.Location = new System.Drawing.Point(403, 228);
            this.ShoppingListbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShoppingListbtn.Name = "ShoppingListbtn";
            this.ShoppingListbtn.Size = new System.Drawing.Size(237, 50);
            this.ShoppingListbtn.TabIndex = 20;
            this.ShoppingListbtn.Text = "Shopping List";
            this.ShoppingListbtn.UseVisualStyleBackColor = false;
            this.ShoppingListbtn.Click += new System.EventHandler(this.ShoppingListbtn_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 640);
            this.Controls.Add(this.ShoppingListbtn);
            this.Controls.Add(this.help_btn);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.forage_btn);
            this.Controls.Add(this.profile_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.btnPantry);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSaved);
            this.Controls.Add(this.txtUsername);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            this.ResumeLayout(false);

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Would you like to log out?", "Message", MessageBoxButtons.YesNo)) ==
                DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        #endregion

        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Button btnSaved;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPantry;
        private Button help_btn;
        private Button shop_btn;
        private Button forage_btn;
        private Button profile_btn;
        private Button search_btn;
        private Button ShoppingListbtn;
    }
}