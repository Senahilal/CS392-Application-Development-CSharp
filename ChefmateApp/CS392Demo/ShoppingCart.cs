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
    public partial class ShoppingCart : Form
    {
        private FirestoreService firestoreService;

        public ShoppingCart()
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance();
            LoadIngredients();
        }

        private async void LoadIngredients()
        {
            try
            {
                var ingredients = await firestoreService.GetUserShoppingCartIngredientsAsync();
                ingredientListBox.Items.Clear();
                foreach (var ingredient in ingredients)
                {
                    ingredientListBox.Items.Add(ingredient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load ingredients: {ex.Message}");
            }
        }

        private async void deleteItemBtn_Click(object sender, EventArgs e)
        {
            if (ingredientListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an ingredient to delete.");
                return;
            }

            var ingredient = ingredientListBox.SelectedItem.ToString();
            try
            {
                await firestoreService.RemoveIngredientFromUserShoppingCart(ingredient);
                LoadIngredients();  // Refresh the list box after deletion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete ingredient: {ex.Message}");
            }
        }

        private async void btnShop_Click(object sender, EventArgs e)
            // Passes users Shopping list into Shop page to allow user to shop for ingredients
        {
            // 1. Asynchronously fetch the ingredients from the user's shopping cart.
            var ingredients = await firestoreService.GetUserShoppingCartIngredientsAsync();
            // 2. Close the current form
            this.Close();
            // 3. Create a new instance of the shopIngredients form, passing the fetched ingredients.
            shopIngredients shoplist = new shopIngredients(ingredients);
            // 4. Show Shopping form
            shoplist.Show();

        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profileForm = new Profile();
            profileForm.Show();
        }
    }
}
