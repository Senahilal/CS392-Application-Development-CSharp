using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using RecipeAPIDemo;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using HttpMethod = System.Net.Http.HttpMethod;



namespace SerpAPITest
{
    public partial class Search : Form
    {

        private static Search instance;
        private FirestoreService firestoreService;

        // Public static method to access the singleton instance
        public static Search GetInstance()
        {
            // Check if the existing instance is null or has been disposed of
            if (instance == null || instance.IsDisposed)
            {
                instance = new Search();  // Create a new instance if necessary
            }
            return instance;
        }
        private Search()
        {
            InitializeComponent();
            searchMode.SelectedIndex = 0;
            firestoreService = FirestoreService.GetInstance();
        }

        private void SearchFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Prevent the form from closing
            this.Hide(); // Hide the form instead
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            // if (searchTextBox.Text.Length == 0)
            // {
            //    ;
            // }
            String searchText = searchTextBox.Text;
            if (includePantry.Checked && searchMode.SelectedIndex == 0)
            {
                searchText += "," + String.Join(",", await firestoreService.GetUserPantryIngredientsAsync());
            }
            searchButton.Enabled = false; // Prevents multiple clicks
            this.Hide();
            SearchResults resultsForm = new SearchResults(searchText, searchMode.Text, includePantry.Checked);
            resultsForm.Show();
            searchButton.Enabled = true;
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile();
            profileForm.Show();
        }

        private void forage_btn_Click(object sender, EventArgs e)
        {
            Foraging foragingForm = new Foraging();
            foragingForm.Show();
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            var helpForm = HelpForm.GetInstance();
            helpForm.Show();
            helpForm.BringToFront();
        }

        private void searchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchMode.SelectedIndex == 0)
            {
                includePantry.Enabled = true;
            }
            else
            {
                includePantry.Enabled = false;
            }
        }
		
        private void shop_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            shopIngredients shoppingForm = new shopIngredients();
            shoppingForm.Show();
        }
    }
}
