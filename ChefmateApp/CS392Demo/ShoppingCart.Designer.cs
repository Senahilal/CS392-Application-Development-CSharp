namespace RecipeAPIDemo
{
    partial class ShoppingCart
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
            this.ingredientListBox = new System.Windows.Forms.ListBox();
            this.deleteItemBtn = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.returnBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ingredientListBox
            // 
            this.ingredientListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientListBox.FormattingEnabled = true;
            this.ingredientListBox.ItemHeight = 25;
            this.ingredientListBox.Location = new System.Drawing.Point(240, 95);
            this.ingredientListBox.Name = "ingredientListBox";
            this.ingredientListBox.Size = new System.Drawing.Size(538, 329);
            this.ingredientListBox.TabIndex = 2;
            // 
            // deleteItemBtn
            // 
            this.deleteItemBtn.Location = new System.Drawing.Point(581, 449);
            this.deleteItemBtn.Name = "deleteItemBtn";
            this.deleteItemBtn.Size = new System.Drawing.Size(125, 56);
            this.deleteItemBtn.TabIndex = 3;
            this.deleteItemBtn.Text = "Delete Selected Ingredient";
            this.deleteItemBtn.UseVisualStyleBackColor = true;
            this.deleteItemBtn.Click += new System.EventHandler(this.deleteItemBtn_Click);
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(301, 449);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(126, 56);
            this.btnShop.TabIndex = 4;
            this.btnShop.Text = "Shop entire list";
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // userNameLbl
            // 
            this.userNameLbl.Font = new System.Drawing.Font("Arial", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.userNameLbl.Location = new System.Drawing.Point(29, 26);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(234, 60);
            this.userNameLbl.TabIndex = 11;
            this.userNameLbl.Text = "Shopping List";
            this.userNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnBtn
            // 
            this.returnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.returnBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.returnBtn.Location = new System.Drawing.Point(63, 529);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(168, 67);
            this.returnBtn.TabIndex = 12;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = false;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 640);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.btnShop);
            this.Controls.Add(this.deleteItemBtn);
            this.Controls.Add(this.ingredientListBox);
            this.Name = "ShoppingCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping List";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ingredientListBox;
        private System.Windows.Forms.Button deleteItemBtn;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Button returnBtn;
    }
}