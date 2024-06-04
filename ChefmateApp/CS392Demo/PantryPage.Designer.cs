namespace RecipeAPIDemo
{
    partial class PantryPage
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
            this.deleteItemBtn = new System.Windows.Forms.Button();
            this.ingredientListBox = new System.Windows.Forms.ListBox();
            this.returnBtn = new System.Windows.Forms.Button();
            this.addIngredientBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameLbl
            // 
            this.userNameLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.userNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.userNameLbl.Location = new System.Drawing.Point(118, 53);
            this.userNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(351, 100);
            this.userNameLbl.TabIndex = 10;
            this.userNameLbl.Text = "Username";
            this.userNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteItemBtn
            // 
            this.deleteItemBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.deleteItemBtn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItemBtn.Location = new System.Drawing.Point(332, 748);
            this.deleteItemBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteItemBtn.Name = "deleteItemBtn";
            this.deleteItemBtn.Size = new System.Drawing.Size(297, 53);
            this.deleteItemBtn.TabIndex = 9;
            this.deleteItemBtn.Text = "Delete Selected Ingredient";
            this.deleteItemBtn.UseVisualStyleBackColor = false;
            this.deleteItemBtn.Click += new System.EventHandler(this.deleteItemBtn_Click);
            // 
            // ingredientListBox
            // 
            this.ingredientListBox.BackColor = System.Drawing.Color.FloralWhite;
            this.ingredientListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientListBox.FormattingEnabled = true;
            this.ingredientListBox.ItemHeight = 42;
            this.ingredientListBox.Location = new System.Drawing.Point(332, 202);
            this.ingredientListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ingredientListBox.Name = "ingredientListBox";
            this.ingredientListBox.ScrollAlwaysVisible = true;
            this.ingredientListBox.Size = new System.Drawing.Size(912, 508);
            this.ingredientListBox.TabIndex = 8;
            // 
            // returnBtn
            // 
            this.returnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.returnBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.returnBtn.Location = new System.Drawing.Point(90, 844);
            this.returnBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(252, 105);
            this.returnBtn.TabIndex = 7;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = false;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // addIngredientBtn
            // 
            this.addIngredientBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.addIngredientBtn.Font = new System.Drawing.Font("Arial", 8F);
            this.addIngredientBtn.Location = new System.Drawing.Point(950, 748);
            this.addIngredientBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addIngredientBtn.Name = "addIngredientBtn";
            this.addIngredientBtn.Size = new System.Drawing.Size(297, 53);
            this.addIngredientBtn.TabIndex = 6;
            this.addIngredientBtn.Text = "Add Ingredients";
            this.addIngredientBtn.UseVisualStyleBackColor = false;
            this.addIngredientBtn.Click += new System.EventHandler(this.addIngredientBtn_Click);
            // 
            // PantryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1570, 1000);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.deleteItemBtn);
            this.Controls.Add(this.ingredientListBox);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.addIngredientBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PantryPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantryPage";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Button deleteItemBtn;
        private System.Windows.Forms.ListBox ingredientListBox;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.Button addIngredientBtn;
    }
}