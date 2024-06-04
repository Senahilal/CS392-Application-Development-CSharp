using Newtonsoft.Json.Linq;
using SerpAPITest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeAPIDemo
{
    public partial class shopIngredients : Form
    {
        // Fields to store the missing ingredients and product links
        private List<string> missingItems;
        private static readonly HttpClient client = new HttpClient();
        private Dictionary<string, string> productLinks = new Dictionary<string, string>();
        private FirestoreService firestoreService;

        public shopIngredients(List<string> items) // Constructor with a list of missing ingredients
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance();
            missingItems = items; // Assign items to MissingItems
            UpdateList(); // Populate the list box with the missing items
        }
        public shopIngredients() // Default constructor
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance();
        }

        private async void IngredientsListBox_DoubleClick(object sender, EventArgs e) 
            // Event handler for double-clicking an ingredient in the list box
        {
            if (IngredientsListBox.SelectedIndex != -1)
            {
                string selectedIngredient = IngredientsListBox.SelectedItem.ToString(); // 1. Get selected ingredient
                await SearchAndDisplayResults(selectedIngredient); // 2. Call function to search and display results
            }
        }

        private async Task SearchAndDisplayResults(string item)
        // Search for and display results for a specific ingredient
        {
            //api key and search url
            string apiKey = "API KEY";
            string url = $"https://serpapi.com/search.json?engine=google_shopping&q={Uri.EscapeDataString(item)}&api_key={apiKey}";

            try
            {
                string responseString = await client.GetStringAsync(url); // 1. Get response
                JObject data = JObject.Parse(responseString); // 2. Parse response into JObject
                var shoppingResults = data["shopping_results"];  // 3. Get shopping results from response JObject
                UpdateResultsList(shoppingResults); // 4. Call function to update results list with shopping results
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data for {item}: {ex.Message}");
            }
        }

        private void UpdateResultsList(JToken shoppingResults)
            // Update the result list with shopping results
        {
            listViewResults.Items.Clear(); // 1. Clear current results
            string filterSource = GetCheckedItem(); // 2. Get the currently checked source from ServicesCheckList

            foreach (var result in shoppingResults) // 3. Iterate through results
            {
                string source = result["source"].ToString(); // 4. Get source of Result
                if (source.Contains(filterSource)) // 5. Check if source is same as ticked source
                {
                    // 6. Get data ready to display
                    string description = result["title"].ToString();
                    string price = result["price"].ToString();
                    string link = result["link"].ToString();

                    ListViewItem item = new ListViewItem(source);
                    item.SubItems.Add(description);
                    item.SubItems.Add(price);
                    item.Tag = link;

                    listViewResults.Items.Add(item); // 7. Display data
                }
            }
        }

        private void UpdateList()
        // Populate the list box with missing ingredients
        {
            foreach (var ingredient in missingItems) // 1. Iterate through each Ingredient
            {
                IngredientsListBox.Items.Add(ingredient); // 2. Add Ingredient to ListBox
            }
        }

        private void listViewResults_DoubleClick(object sender, EventArgs e)
        // Open the link of the selected item in the default web browser
        {
            if (listViewResults.SelectedItems.Count > 0) // 1. Check if item is selected
            {
                ListViewItem selectedItem = listViewResults.SelectedItems[0];
                string url = selectedItem.Tag as string; // 2. Retrieve the URL from the Tag property of selected item

                if (!string.IsNullOrEmpty(url)) // 3. Check if url is empty
                {
                    try
                    {
                        System.Diagnostics.Process.Start("cmd", $"/c start {url}"); // 4. Open the URL in the default web browser
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not open the link: {ex.Message}");
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // this.Hide();
            // var mainForm = SearchResults.GetInstance();
            // mainForm.Show();
        }

        private void sortButton_Click(object sender, EventArgs e)
            // Sort items in Ascending order
        {
            // 1. Extract items
            var items = listViewResults.Items.Cast<ListViewItem>().ToList();
            // 2. Sort ascending
            items = items.OrderBy(item => Decimal.TryParse(item.SubItems[2].Text.Trim('$'), out decimal price) ? price : decimal.MaxValue).ToList();
           

            // 3. Clear and repopulate ListView
            listViewResults.Items.Clear();
            listViewResults.Items.AddRange(items.ToArray());
        }

        private async void btnShopAll_Click(object sender, EventArgs e)
            // Search all items in MissingItems and display results
        {
            // 1. Ensure that missingItems is initialized and not null
            if (missingItems != null && missingItems.Any())
            {
                listViewResults.Items.Clear();
                var tasks = missingItems.Select(item => SearchAndDisplayResultsAll(item)).ToList(); // 2. Delegate tasks to search each item
                await Task.WhenAll(tasks);
            }
            else
            {
                // Handle the case where missingItems is null or empty
                MessageBox.Show("There are no items to search for.");
            }
        }

        private async Task SearchAndDisplayResultsAll(string item)
            // Search for item using SERPAPI
        {
            string apiKey = "API KEY";
            string url = $"https://serpapi.com/search.json?engine=google_shopping&q={Uri.EscapeDataString(item)}&api_key={apiKey}";

            try
            {
                string responseString = await client.GetStringAsync(url); // 1. Get Response
                JObject data = JObject.Parse(responseString); // 2. Parse Response into JOject
                var shoppingResults = data["shopping_results"]; // 3. Get Shopping results from JObject
                UpdateResultsListAll(shoppingResults); // 4. Call function to search and display results
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data for {item}: {ex.Message}");
            }
        }

        private void UpdateResultsListAll(JToken shoppingResults)
            // Update the result list with shopping results
        {
            string filterSource = GetCheckedItem(); // 1. Get the currently checked source from ServicesCheckList

            foreach (var result in shoppingResults) // 2. Go over each result
            {
                
                string source = result["source"].ToString(); // 3.Get Source of result
                if (source.Contains(filterSource)) // 4. Check if result source and target source are the same
                {
                    // 5. Get data ready for Display
                    string description = result["title"].ToString();
                    string price = result["price"].ToString();
                    string link = result["link"].ToString();

                    ListViewItem item = new ListViewItem(source);
                    item.SubItems.Add(description);
                    item.SubItems.Add(price);
                    item.Tag = link;
                    // 6. Display data
                    listViewResults.Items.Add(item);
                    break; // 6. Break after one result for one ingredient
                }
            }
        }


        private void ServicesCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
            // Make sure only 1 option in CheckList is selected
        {
            if (e.NewValue == CheckState.Checked)
            {
                // 1. Loop through all items in the CheckedListBox
                for (int i = 0; i < ServicesCheckList.Items.Count; i++)
                {
                    // 2. Uncheck all items except the currently selected one
                    if (i != e.Index)
                    {
                        ServicesCheckList.SetItemChecked(i, false);
                    }
                }
            }
        }

        private string GetCheckedItem()
            // Get checked item from CheckList
        {
            foreach (int index in ServicesCheckList.CheckedIndices) //1. Only one checked indice because of code above
            {
                return ServicesCheckList.Items[index].ToString(); // Returns the source name
            }
            return ""; // Return empty string if nothing is checked
        }

        private async void Search_Click(object sender, EventArgs e)
            // Search and return results for ingredient in Searchtxt
        {
            await SearchAndDisplayResults(Searchtxt.Text); // Search and return results for ingredient in Searchtxt
        }

        private void search_btn_Click(object sender, EventArgs e)
            // Open Search page
        {
            this.Close(); // 1. Close the current form.
            Search searchForm = Search.GetInstance(); // 2. Get instance of Search page
            searchForm.Show(); // 3. Display search page
        }

        private void profile_btn_Click(object sender, EventArgs e)
            // Open Profile page
        {
            this.Close(); // 1. Close the current form.
            Profile profileForm = new Profile(); // 2. Get instance of Profile page
            profileForm.Show(); // 3. Display Profile page
        }

        private void help_btn_Click(object sender, EventArgs e)
            // Open help page
        {
            this.Close(); // 1. Close the current form.
            var helpForm = HelpForm.GetInstance(); // 2. Get instance of help page
            helpForm.Show(); // 3. Display help page
            helpForm.BringToFront();
        }
        private void forage_btn_Click(object sender, EventArgs e)
            // Open forage page
        {
            this.Close(); // 1. Close the current form.
            Foraging foragingForm = new Foraging(); // 2. Get instance of forage page
            foragingForm.Show(); // 3. Display Forage page
        }

        private async void ListShopbtn_Click(object sender, EventArgs e)
            // Load users shopping list into Ingredient ListBox
        {
            try
            {
                var ingredients = await firestoreService.GetUserShoppingCartIngredientsAsync(); // 1. Get user shop list
                IngredientsListBox.Items.Clear(); // 2. Clear current Ingredients list
                missingItems = ingredients; // 3. Assign Ingredients in shopping list to list<String> missingItems
                foreach (var ingredient in ingredients) // 4. Go over each ingredient
                {
                    IngredientsListBox.Items.Add(ingredient); // 5. Display each ingredient
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load ingredients: {ex.Message}");
            }
        }
    }
}
