namespace RecipeAPIDemo
{
    partial class SavedRecipePage
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
            this.userNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteRecipeBtn = new System.Windows.Forms.Button();
            this.returnBtn = new System.Windows.Forms.Button();
            this.savedRecipeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // userNameLbl
            // 
            this.userNameLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.userNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.userNameLbl.Location = new System.Drawing.Point(44, 41);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(234, 60);
            this.userNameLbl.TabIndex = 10;
            this.userNameLbl.Text = "Username";
            this.userNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Double click to open recipe in search";
            // 
            // deleteRecipeBtn
            // 
            this.deleteRecipeBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.deleteRecipeBtn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteRecipeBtn.Location = new System.Drawing.Point(631, 471);
            this.deleteRecipeBtn.Name = "deleteRecipeBtn";
            this.deleteRecipeBtn.Size = new System.Drawing.Size(179, 33);
            this.deleteRecipeBtn.TabIndex = 8;
            this.deleteRecipeBtn.Text = "Remove Recipe";
            this.deleteRecipeBtn.UseVisualStyleBackColor = false;
            this.deleteRecipeBtn.Click += new System.EventHandler(this.deleteRecipeBtn_Click);
            // 
            // returnBtn
            // 
            this.returnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.returnBtn.Location = new System.Drawing.Point(54, 532);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(168, 63);
            this.returnBtn.TabIndex = 7;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = false;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // savedRecipeListBox
            // 
            this.savedRecipeListBox.BackColor = System.Drawing.Color.FloralWhite;
            this.savedRecipeListBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedRecipeListBox.FormattingEnabled = true;
            this.savedRecipeListBox.ItemHeight = 17;
            this.savedRecipeListBox.Location = new System.Drawing.Point(259, 168);
            this.savedRecipeListBox.Name = "savedRecipeListBox";
            this.savedRecipeListBox.ScrollAlwaysVisible = true;
            this.savedRecipeListBox.Size = new System.Drawing.Size(551, 276);
            this.savedRecipeListBox.TabIndex = 6;
            this.savedRecipeListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.savedRecipeListBox_MouseDoubleClick);
            // 
            // SavedRecipePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 640);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteRecipeBtn);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.savedRecipeListBox);
            this.Name = "SavedRecipePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SavedRecipePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteRecipeBtn;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.ListBox savedRecipeListBox;
    }
}