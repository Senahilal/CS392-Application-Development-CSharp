namespace SerpAPITest
{
    partial class SearchResults
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
            this.recipeBox = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.displayPreviousRecipeVideo = new System.Windows.Forms.Button();
            this.displayNextRecipeVideo = new System.Windows.Forms.Button();
            this.purchase_btn = new System.Windows.Forms.Button();
            this.add_to_list_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.profile_btn = new System.Windows.Forms.Button();
            this.forage_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.help_btn = new System.Windows.Forms.Button();
            this.saveRecipeBtn = new System.Windows.Forms.Button();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Results = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recipeBox
            // 
            this.recipeBox.BackColor = System.Drawing.Color.OldLace;
            this.recipeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeBox.Location = new System.Drawing.Point(15, 297);
            this.recipeBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.recipeBox.Multiline = true;
            this.recipeBox.Name = "recipeBox";
            this.recipeBox.ReadOnly = true;
            this.recipeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recipeBox.Size = new System.Drawing.Size(702, 549);
            this.recipeBox.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(724, 114);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(40, 38);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(874, 734);
            this.webBrowser1.TabIndex = 5;
            // 
            // displayPreviousRecipeVideo
            // 
            this.displayPreviousRecipeVideo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.displayPreviousRecipeVideo.Location = new System.Drawing.Point(948, 858);
            this.displayPreviousRecipeVideo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.displayPreviousRecipeVideo.Name = "displayPreviousRecipeVideo";
            this.displayPreviousRecipeVideo.Size = new System.Drawing.Size(170, 44);
            this.displayPreviousRecipeVideo.TabIndex = 6;
            this.displayPreviousRecipeVideo.Text = "Previous";
            this.displayPreviousRecipeVideo.UseVisualStyleBackColor = false;
            this.displayPreviousRecipeVideo.Click += new System.EventHandler(this.displayPreviousRecipeVideo_Click);
            // 
            // displayNextRecipeVideo
            // 
            this.displayNextRecipeVideo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.displayNextRecipeVideo.Location = new System.Drawing.Point(1148, 858);
            this.displayNextRecipeVideo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.displayNextRecipeVideo.Name = "displayNextRecipeVideo";
            this.displayNextRecipeVideo.Size = new System.Drawing.Size(170, 44);
            this.displayNextRecipeVideo.TabIndex = 7;
            this.displayNextRecipeVideo.Text = "Next";
            this.displayNextRecipeVideo.UseVisualStyleBackColor = false;
            this.displayNextRecipeVideo.Click += new System.EventHandler(this.displayNextRecipeVideo_Click);
            // 
            // purchase_btn
            // 
            this.purchase_btn.Location = new System.Drawing.Point(978, 56);
            this.purchase_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.purchase_btn.Name = "purchase_btn";
            this.purchase_btn.Size = new System.Drawing.Size(254, 44);
            this.purchase_btn.TabIndex = 8;
            this.purchase_btn.Text = "Purchase Ingredients";
            this.purchase_btn.UseVisualStyleBackColor = true;
            this.purchase_btn.Click += new System.EventHandler(this.purchase_btn_Click);
            // 
            // add_to_list_btn
            // 
            this.add_to_list_btn.Location = new System.Drawing.Point(1290, 56);
            this.add_to_list_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_to_list_btn.Name = "add_to_list_btn";
            this.add_to_list_btn.Size = new System.Drawing.Size(231, 44);
            this.add_to_list_btn.TabIndex = 9;
            this.add_to_list_btn.Text = "Add to shopping list";
            this.add_to_list_btn.UseVisualStyleBackColor = true;
            this.add_to_list_btn.Click += new System.EventHandler(this.add_to_list_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.search_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.search_btn.FlatAppearance.BorderSize = 5;
            this.search_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.Location = new System.Drawing.Point(-8, 920);
            this.search_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(340, 114);
            this.search_btn.TabIndex = 10;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // profile_btn
            // 
            this.profile_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.profile_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_btn.Location = new System.Drawing.Point(328, 920);
            this.profile_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.profile_btn.Name = "profile_btn";
            this.profile_btn.Size = new System.Drawing.Size(324, 114);
            this.profile_btn.TabIndex = 11;
            this.profile_btn.Text = "Profile";
            this.profile_btn.UseVisualStyleBackColor = false;
            this.profile_btn.Click += new System.EventHandler(this.profile_btn_Click);
            // 
            // forage_btn
            // 
            this.forage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.forage_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forage_btn.Location = new System.Drawing.Point(650, 920);
            this.forage_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.forage_btn.Name = "forage_btn";
            this.forage_btn.Size = new System.Drawing.Size(324, 114);
            this.forage_btn.TabIndex = 12;
            this.forage_btn.Text = "Forage";
            this.forage_btn.UseVisualStyleBackColor = false;
            this.forage_btn.Click += new System.EventHandler(this.forage_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.shop_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop_btn.Location = new System.Drawing.Point(966, 920);
            this.shop_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(328, 114);
            this.shop_btn.TabIndex = 13;
            this.shop_btn.Text = "Shop";
            this.shop_btn.UseVisualStyleBackColor = false;
            this.shop_btn.Click += new System.EventHandler(this.shop_btn_Click);
            // 
            // help_btn
            // 
            this.help_btn.AutoSize = true;
            this.help_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.help_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.help_btn.Location = new System.Drawing.Point(1290, 920);
            this.help_btn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.help_btn.Name = "help_btn";
            this.help_btn.Size = new System.Drawing.Size(328, 114);
            this.help_btn.TabIndex = 14;
            this.help_btn.Text = "Help";
            this.help_btn.UseVisualStyleBackColor = false;
            this.help_btn.Click += new System.EventHandler(this.help_btn_Click);
            // 
            // saveRecipeBtn
            // 
            this.saveRecipeBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.saveRecipeBtn.Location = new System.Drawing.Point(752, 56);
            this.saveRecipeBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveRecipeBtn.Name = "saveRecipeBtn";
            this.saveRecipeBtn.Size = new System.Drawing.Size(170, 44);
            this.saveRecipeBtn.TabIndex = 15;
            this.saveRecipeBtn.Text = "Save Recipe";
            this.saveRecipeBtn.UseVisualStyleBackColor = false;
            this.saveRecipeBtn.Click += new System.EventHandler(this.saveRecipeBtn_Click);
            // 
            // resultsListView
            // 
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.resultsListView.HideSelection = false;
            this.resultsListView.Location = new System.Drawing.Point(12, 112);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(702, 176);
            this.resultsListView.TabIndex = 16;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            this.resultsListView.SelectedIndexChanged += new System.EventHandler(this.resultsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Missing Items";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Likes";
            this.columnHeader3.Width = 100;
            // 
            // Results
            // 
            this.Results.AutoSize = true;
            this.Results.Font = new System.Drawing.Font("Arial", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(89)))), ((int)(((byte)(54)))));
            this.Results.Location = new System.Drawing.Point(2, 38);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(217, 62);
            this.Results.TabIndex = 17;
            this.Results.Text = "Results";
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1618, 1034);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.resultsListView);
            this.Controls.Add(this.saveRecipeBtn);
            this.Controls.Add(this.help_btn);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.forage_btn);
            this.Controls.Add(this.profile_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.add_to_list_btn);
            this.Controls.Add(this.purchase_btn);
            this.Controls.Add(this.displayNextRecipeVideo);
            this.Controls.Add(this.displayPreviousRecipeVideo);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.recipeBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChefMate";
            this.Load += new System.EventHandler(this.SearchResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox recipeBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button displayPreviousRecipeVideo;
        private System.Windows.Forms.Button displayNextRecipeVideo;
        private System.Windows.Forms.Button purchase_btn;
        private System.Windows.Forms.Button add_to_list_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button profile_btn;
        private System.Windows.Forms.Button forage_btn;
        private System.Windows.Forms.Button shop_btn;
        private System.Windows.Forms.Button help_btn;
        private System.Windows.Forms.Button saveRecipeBtn;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label Results;
    }
}

