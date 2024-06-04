using System;

namespace RecipeAPIDemo
{
    partial class HelpForm
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
            this.helpSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.help_ask_btn = new System.Windows.Forms.Button();
            this.help_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.forage_btn = new System.Windows.Forms.Button();
            this.profile_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.helpResultsBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // helpSearchBox
            // 
            this.helpSearchBox.Location = new System.Drawing.Point(73, 456);
            this.helpSearchBox.Margin = new System.Windows.Forms.Padding(4);
            this.helpSearchBox.Multiline = true;
            this.helpSearchBox.Name = "helpSearchBox";
            this.helpSearchBox.Size = new System.Drawing.Size(719, 60);
            this.helpSearchBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Help";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // help_ask_btn
            // 
            this.help_ask_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.help_ask_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_ask_btn.Location = new System.Drawing.Point(816, 456);
            this.help_ask_btn.Margin = new System.Windows.Forms.Padding(4);
            this.help_ask_btn.Name = "help_ask_btn";
            this.help_ask_btn.Size = new System.Drawing.Size(136, 61);
            this.help_ask_btn.TabIndex = 3;
            this.help_ask_btn.Text = "Ask";
            this.help_ask_btn.UseVisualStyleBackColor = false;
            this.help_ask_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // help_btn
            // 
            this.help_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.help_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_btn.Location = new System.Drawing.Point(831, 570);
            this.help_btn.Margin = new System.Windows.Forms.Padding(4);
            this.help_btn.Name = "help_btn";
            this.help_btn.Size = new System.Drawing.Size(216, 72);
            this.help_btn.TabIndex = 32;
            this.help_btn.Text = "Help";
            this.help_btn.UseVisualStyleBackColor = false;
            // 
            // shop_btn
            // 
            this.shop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.shop_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.shop_btn.Location = new System.Drawing.Point(626, 570);
            this.shop_btn.Margin = new System.Windows.Forms.Padding(4);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(216, 72);
            this.shop_btn.TabIndex = 31;
            this.shop_btn.Text = "Shop";
            this.shop_btn.UseVisualStyleBackColor = false;
            this.shop_btn.Click += new System.EventHandler(this.shop_btn_Click);
            // 
            // forage_btn
            // 
            this.forage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.forage_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forage_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.forage_btn.Location = new System.Drawing.Point(414, 570);
            this.forage_btn.Margin = new System.Windows.Forms.Padding(4);
            this.forage_btn.Name = "forage_btn";
            this.forage_btn.Size = new System.Drawing.Size(216, 72);
            this.forage_btn.TabIndex = 30;
            this.forage_btn.Text = "Forage";
            this.forage_btn.UseVisualStyleBackColor = false;
            this.forage_btn.Click += new System.EventHandler(this.forage_btn_Click);
            // 
            // profile_btn
            // 
            this.profile_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.profile_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.profile_btn.Location = new System.Drawing.Point(207, 570);
            this.profile_btn.Margin = new System.Windows.Forms.Padding(4);
            this.profile_btn.Name = "profile_btn";
            this.profile_btn.Size = new System.Drawing.Size(216, 72);
            this.profile_btn.TabIndex = 29;
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
            this.search_btn.Location = new System.Drawing.Point(-4, 570);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(216, 72);
            this.search_btn.TabIndex = 28;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.reset_btn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.Location = new System.Drawing.Point(836, 47);
            this.reset_btn.Margin = new System.Windows.Forms.Padding(4);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(100, 28);
            this.reset_btn.TabIndex = 33;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = false;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // helpResultsBox
            // 
            this.helpResultsBox.Location = new System.Drawing.Point(85, 83);
            this.helpResultsBox.Margin = new System.Windows.Forms.Padding(4);
            this.helpResultsBox.Name = "helpResultsBox";
            this.helpResultsBox.ReadOnly = true;
            this.helpResultsBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.helpResultsBox.Size = new System.Drawing.Size(849, 364);
            this.helpResultsBox.TabIndex = 34;
            this.helpResultsBox.Text = "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 640);
            this.Controls.Add(this.helpResultsBox);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.help_btn);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.forage_btn);
            this.Controls.Add(this.profile_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.help_ask_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helpSearchBox);
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private System.Windows.Forms.TextBox helpSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button help_ask_btn;
        private System.Windows.Forms.Button help_btn;
        private System.Windows.Forms.Button shop_btn;
        private System.Windows.Forms.Button forage_btn;
        private System.Windows.Forms.Button profile_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.RichTextBox helpResultsBox;
    }
}