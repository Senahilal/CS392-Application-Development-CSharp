using SerpAPITest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeAPIDemo
{
    public partial class Profile : Form
    {
        private FirestoreService firestoreService;
        public Profile()
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance();
            DisplayUsername();
        }

        private async void DisplayUsername()
        {
            try
            {
                string username = await firestoreService.GetUsernameAsync();
                if (username != null)
                {
                    txtUsername.Text =  username;
                }
                else
                {
                    txtUsername.Text = "Unknown"; // Default text or handle accordingly
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load username: {ex.Message}");
            }
        }

        private void btnPantry_Click(object sender, EventArgs e)
        {
            this.Close();
            PantryPage pantryForm = new PantryPage();
            pantryForm.Show();
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            this.Close();
            SavedRecipePage savedRecipesForm = new SavedRecipePage();
            savedRecipesForm.Show();
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Search searchForm = Search.GetInstance();
            searchForm.Show();
        }

        private void forage_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Foraging foragingForm = new Foraging();
            foragingForm.Show();
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            var helpForm = HelpForm.GetInstance();
            helpForm.Show();
            helpForm.BringToFront();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            shopIngredients shoppingForm = new shopIngredients();
            shoppingForm.Show();
        }

        private void ShoppingListbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            ShoppingCart shoppingList = new ShoppingCart();
            shoppingList.Show();
        }
    }
}
