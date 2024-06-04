namespace RecipeAPIDemo
{
    partial class shopIngredients
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
            this.IngredientsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sortButton = new System.Windows.Forms.Button();
            this.btnShopAll = new System.Windows.Forms.Button();
            this.ServicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.Searchtxt = new System.Windows.Forms.TextBox();
            this.Search1 = new System.Windows.Forms.Button();
            this.help_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.forage_btn = new System.Windows.Forms.Button();
            this.profile_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.ListShopbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IngredientsListBox
            // 
            this.IngredientsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IngredientsListBox.FormattingEnabled = true;
            this.IngredientsListBox.ItemHeight = 25;
            this.IngredientsListBox.Location = new System.Drawing.Point(27, 132);
            this.IngredientsListBox.Margin = new System.Windows.Forms.Padding(4);
            this.IngredientsListBox.Name = "IngredientsListBox";
            this.IngredientsListBox.Size = new System.Drawing.Size(244, 329);
            this.IngredientsListBox.TabIndex = 0;
            this.IngredientsListBox.DoubleClick += new System.EventHandler(this.IngredientsListBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shop ingredients";
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Source,
            this.Description,
            this.Price});
            this.listViewResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(295, 136);
            this.listViewResults.Margin = new System.Windows.Forms.Padding(4);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(729, 332);
            this.listViewResults.TabIndex = 2;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.DoubleClick += new System.EventHandler(this.listViewResults_DoubleClick);
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = 150;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 250;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Double click to search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Double click to open in browser";
            // 
            // sortButton
            // 
            this.sortButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.sortButton.Location = new System.Drawing.Point(592, 473);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(113, 45);
            this.sortButton.TabIndex = 6;
            this.sortButton.Text = "Sort lowest";
            this.sortButton.UseVisualStyleBackColor = false;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // btnShopAll
            // 
            this.btnShopAll.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnShopAll.Location = new System.Drawing.Point(27, 473);
            this.btnShopAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnShopAll.Name = "btnShopAll";
            this.btnShopAll.Size = new System.Drawing.Size(103, 45);
            this.btnShopAll.TabIndex = 7;
            this.btnShopAll.Text = "Search all";
            this.btnShopAll.UseVisualStyleBackColor = false;
            this.btnShopAll.Click += new System.EventHandler(this.btnShopAll_Click);
            // 
            // ServicesCheckList
            // 
            this.ServicesCheckList.FormattingEnabled = true;
            this.ServicesCheckList.Items.AddRange(new object[] {
            "Amazon",
            "Walmart",
            "Target",
            "Doordash"});
            this.ServicesCheckList.Location = new System.Drawing.Point(592, 11);
            this.ServicesCheckList.Margin = new System.Windows.Forms.Padding(2);
            this.ServicesCheckList.Name = "ServicesCheckList";
            this.ServicesCheckList.Size = new System.Drawing.Size(145, 89);
            this.ServicesCheckList.TabIndex = 8;
            this.ServicesCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ServicesCheckList_ItemCheck);
            // 
            // Searchtxt
            // 
            this.Searchtxt.Location = new System.Drawing.Point(27, 77);
            this.Searchtxt.Margin = new System.Windows.Forms.Padding(2);
            this.Searchtxt.Name = "Searchtxt";
            this.Searchtxt.Size = new System.Drawing.Size(163, 22);
            this.Searchtxt.TabIndex = 9;
            // 
            // Search1
            // 
            this.Search1.BackColor = System.Drawing.Color.LavenderBlush;
            this.Search1.Location = new System.Drawing.Point(205, 75);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(113, 25);
            this.Search1.TabIndex = 10;
            this.Search1.Text = "Search";
            this.Search1.UseVisualStyleBackColor = false;
            this.Search1.Click += new System.EventHandler(this.Search_Click);
            // 
            // help_btn
            // 
            this.help_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.help_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.help_btn.Location = new System.Drawing.Point(831, 568);
            this.help_btn.Margin = new System.Windows.Forms.Padding(4);
            this.help_btn.Name = "help_btn";
            this.help_btn.Size = new System.Drawing.Size(216, 72);
            this.help_btn.TabIndex = 32;
            this.help_btn.Text = "Help";
            this.help_btn.UseVisualStyleBackColor = false;
            this.help_btn.Click += new System.EventHandler(this.help_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.AutoSize = true;
            this.shop_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.shop_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.shop_btn.Location = new System.Drawing.Point(627, 568);
            this.shop_btn.Margin = new System.Windows.Forms.Padding(4);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(216, 72);
            this.shop_btn.TabIndex = 31;
            this.shop_btn.Text = "Shop";
            this.shop_btn.UseVisualStyleBackColor = false;
            // 
            // forage_btn
            // 
            this.forage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.forage_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forage_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(140)))), ((int)(((byte)(73)))));
            this.forage_btn.Location = new System.Drawing.Point(415, 568);
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
            this.profile_btn.Location = new System.Drawing.Point(207, 568);
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
            this.search_btn.Location = new System.Drawing.Point(-2, 568);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(216, 72);
            this.search_btn.TabIndex = 28;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // ListShopbtn
            // 
            this.ListShopbtn.BackColor = System.Drawing.Color.LavenderBlush;
            this.ListShopbtn.Location = new System.Drawing.Point(155, 473);
            this.ListShopbtn.Name = "ListShopbtn";
            this.ListShopbtn.Size = new System.Drawing.Size(114, 45);
            this.ListShopbtn.TabIndex = 33;
            this.ListShopbtn.Text = "Search Shopping List";
            this.ListShopbtn.UseVisualStyleBackColor = false;
            this.ListShopbtn.Click += new System.EventHandler(this.ListShopbtn_Click);
            // 
            // shopIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 640);
            this.Controls.Add(this.ListShopbtn);
            this.Controls.Add(this.help_btn);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.forage_btn);
            this.Controls.Add(this.profile_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.Search1);
            this.Controls.Add(this.Searchtxt);
            this.Controls.Add(this.ServicesCheckList);
            this.Controls.Add(this.btnShopAll);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IngredientsListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "shopIngredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Ingredients";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox IngredientsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button btnShopAll;
        private System.Windows.Forms.CheckedListBox ServicesCheckList;
        private System.Windows.Forms.TextBox Searchtxt;
        private System.Windows.Forms.Button Search1;
        private System.Windows.Forms.Button help_btn;
        private System.Windows.Forms.Button shop_btn;
        private System.Windows.Forms.Button forage_btn;
        private System.Windows.Forms.Button profile_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button ListShopbtn;
    }
}