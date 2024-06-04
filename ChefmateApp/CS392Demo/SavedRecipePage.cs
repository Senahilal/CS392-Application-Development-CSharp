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
    public partial class SavedRecipePage : Form
    {

        private FirestoreService firestoreService;

        public SavedRecipePage()
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance();
            DisplayUsername();
            DisplayRecipes();

        }
        private async void DisplayUsername()
        {
            try
            {
                // Await the fetching of username from FirestoreService
                string username = await firestoreService.GetUsernameAsync();
                if (username != null)
                {
                    userNameLbl.Text = username; // If a username is received, set it on the label control
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

        // Asynchronous method to display recipes saved by the user
        private async Task DisplayRecipes()
        {
            try
            {
                // Await the fetching of user recipes from FirestoreService
                var recipeTitles = await firestoreService.GetUserRecipesAsync();
                // Populate the list box with the received recipe titles
                PopulateRecipeListBox(recipeTitles);
            }
            catch (Exception ex)
            {
                // If an exception occurs, show it in a message box
                MessageBox.Show($"Error retrieving recipes: {ex.Message}");
            }
        }


        // Update the ListBox with the fetched recipe titles
        private void PopulateRecipeListBox(List<string> titles)
        {
            if (InvokeRequired)
            {
                // If the current thread is not the UI thread, call this method on the UI thread
                Invoke(new Action<List<string>>(PopulateRecipeListBox), new object[] { titles });
            }
            else
            {
                savedRecipeListBox.Items.Clear();
                foreach (var title in titles)
                {
                    savedRecipeListBox.Items.Add(title);
                }
            }
        }


        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profileForm = new Profile();
            profileForm.Show();
        }


        // Event handler for double-clicking on an item in the savedRecipeListBox
        private void savedRecipeListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (savedRecipeListBox.SelectedIndex != -1)
            {
                // If a recipe is selected, retrieve the selected recipe
                string selectedRecipe = savedRecipeListBox.SelectedItem.ToString();
                this.Close(); 
                // Create and show the SearchResults form for the selected recipe
                SearchResults resultsForm = new SearchResults(selectedRecipe, "recipe");
                resultsForm.Show();

            }
        }

        // Asynchronous event handler for clicking the Delete Recipe button
        private async void deleteRecipeBtn_Click(object sender, EventArgs e)
        {
            // Check if a recipe is selected in the ListBox
            if (savedRecipeListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe to delete.");
                return;
            }

            // Confirm before deleting
            if (MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string selectedRecipeTitle = savedRecipeListBox.SelectedItem.ToString();
                try
                {
                    // Call FirestoreService to delete the recipe
                    await firestoreService.DeleteUserRecipeAsync(selectedRecipeTitle);

                    // Refresh the recipe list to reflect the deletion
                    await DisplayRecipes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete recipe: {ex.Message}");
                }
            }
        }
    }
}
