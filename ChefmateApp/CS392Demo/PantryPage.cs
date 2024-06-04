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
    public partial class PantryPage : Form
    {
       
        private FirestoreService firestoreService;

        public PantryPage()
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance(); // Retrieves the single instance of FirestoreService
            DisplayUsername(); // Call the method to display the username on the form
            LoadIngredients(); // Call the method to load and display the ingredients

        }

        // Method to load the username and set it to the label
        private async void DisplayUsername()
        {
            try
            {
                // Await the fetching of username asynchronously
                string username = await firestoreService.GetUsernameAsync();

                // Check if a username is returned and update the label text
                if (username != null) 
                {
                    userNameLbl.Text = username;
                }
                else
                {
                    userNameLbl.Text = "Unknown"; // If no username, set the default text
                }
            }
            catch (Exception ex)
            {
                // Show a message box if an exception occurs
                MessageBox.Show($"Failed to load username: {ex.Message}");
            }
        }


        private async void LoadIngredients()
        {
            try
            {
                // Await the fetching of ingredients asynchronously
                var ingredients = await firestoreService.GetUserPantryIngredientsAsync();
                ingredientListBox.Items.Clear(); // Clear existing items from the list box

                //Adding each ingredient in the ingredients list into listbox.
                foreach (var ingredient in ingredients)
                {
                    ingredientListBox.Items.Add(ingredient);
                }
            }
            catch (Exception ex)
            {
                // Show a message box if an exception occurs
                MessageBox.Show($"Failed to load ingredients: {ex.Message}");
            }
        }

        private async void addIngredientBtn_Click(object sender, EventArgs e)
        {
            // Display input box (with an example of input) and get user input for new ingredients
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter ingredients separated by commas:", "Add Ingredients", "Example: Salt, Pepper, Oregano");
            
            // Check if input is not empty
            if (string.IsNullOrWhiteSpace(input)) return;

            // Split input by commas, trim each ingredient, and remove empty entries and put ingredients into array
            var ingredients = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(ing => ing.Trim())
                                   .Where(ing => !string.IsNullOrEmpty(ing))
                                   .ToList();

            try
            {
                // Add the ingredients to the user's pantry in Firestore and await the operation
                await firestoreService.AddIngredientsToUserPantry(ingredients);
                LoadIngredients();  // Refresh the list of ingredients displayed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add ingredients: {ex.Message}");
            }
        }


        private async void deleteItemBtn_Click(object sender, EventArgs e)
        {
            // Check if an ingredient is selected for deletion
            if (ingredientListBox.SelectedItem == null)
            {
                // If not, show a message box asking the user to select an ingredient
                MessageBox.Show("Please select an ingredient to delete.");
                return;
            }

            // Get the selected ingredient as a string
            var ingredient = ingredientListBox.SelectedItem.ToString();
            try
            {
                // Remove the ingredient from the user's pantry in Firestore and await the operation
                await firestoreService.RemoveIngredientFromUserPantry(ingredient);
                LoadIngredients();  // Refresh the list box after deletion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete ingredient: {ex.Message}");
            }
        }

       
        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profileForm = new Profile();
            profileForm.Show();
        }

        
    }
}
