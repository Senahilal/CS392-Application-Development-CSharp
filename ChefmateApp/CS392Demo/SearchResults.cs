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
using HttpMethod = System.Net.Http.HttpMethod;



namespace SerpAPITest
{
    public partial class SearchResults : Form
    {
        readonly string apiKey = "API KEY";
        private FirestoreService firestoreService;
        string searchText;
        string searchMode;
        List<string> recipeIDs = new List<string>();
        List<string> recipeNames = new List<string>();
        List<List<string>> recipeMissingIngredients = new List<List<string>>();
        private List<string> videoIds = new List<string>();
        private int currentVideoIndex = -1;
        bool pantry_on = true;


        private static readonly HttpClient client = new HttpClient();

        public SearchResults(string text, string mode, bool pantry)
        {
            pantry_on = pantry;
            InitializeComponent();
            searchText = text;
            searchMode = mode;
            firestoreService = FirestoreService.GetInstance();
            RecipeSearch();
        }

        public SearchResults(string text, string mode)
        {
            InitializeComponent();
            searchText = text;
            searchMode = mode;
            firestoreService = FirestoreService.GetInstance();
            RecipeSearch();
        }

        private void RecipeSearch()
        {
            if (searchMode == "Ingredients")
            {
                SearchByIngredients();
            }
            else
            {
                SearchByRecipies();
            }
        }

        private async void SearchByIngredients()
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/findByIngredients?ingredients={Uri.EscapeDataString(searchText)}&number=5"))
            {
                try
                {
                    // Add the API key in a request header
                    requestMessage.Headers.Add("x-api-key", apiKey);
                    // Asynchronously call the API and await the response
                    HttpResponseMessage resp = await client.SendAsync(requestMessage);

                    // Parse the JSON response
                    JArray data = JArray.Parse(await resp.Content.ReadAsStringAsync());

                    if (data.ToArray().Length == 0)
                    {
                        MessageBox.Show("No results found");
                        search_btn_Click(null, null);
                        return;
                    }

                    // Update UI
                    UpdateResultsList1(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private async void SearchByRecipies()
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/complexSearch?query={Uri.EscapeDataString(searchText)}&number=5&sort=popularity&sortDirection=desc&instructionsRequired=true&fillIngredients=true"))
            {
                try
                {
                    // Add the API key in a request header
                    requestMessage.Headers.Add("x-api-key", apiKey);
                    // Asynchronously call the API and await the response
                    HttpResponseMessage resp = await client.SendAsync(requestMessage);

                    // Parse the JSON response
                    JObject data = JObject.Parse(await resp.Content.ReadAsStringAsync());

                    if (data["totalResults"].ToString() == "0")
                    {
                        MessageBox.Show("No results found");
                        search_btn_Click(null, null);
                        return;
                    }

                    // Update UI
                    UpdateResultsList1(data["results"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }




        private async void UpdateResultsList1(JToken recipeResults)
        {
            // Clear the results list
            resultsListView.Items.Clear();
            recipeIDs.Clear();
            recipeNames.Clear();
            recipeMissingIngredients.Clear();
            if (pantry_on) { }
            // Retrieve pantry ingredients from the Firestore service
            var pantryIngredients = await firestoreService.GetUserPantryIngredientsAsync();
            var pantryIngredientSet = new HashSet<string>(pantryIngredients.SelectMany(ing => ing.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries))); // Split ingredients into components

            // Loop over the results and add each recipe to the results list
            int resultCount = 0;
            foreach (var result in recipeResults.OrderBy(obj => (int)obj["missedIngredientCount"]).ToList())
            {
                string title = result["title"].ToString();
                string missedIngredientCount = result["missedIngredientCount"].ToString();
                string likes = result["likes"].ToString();

                
                var MissedIngredients = new List<string>();
                // Create a new ListViewItem with title
                ListViewItem item = new ListViewItem(title);
                if (pantry_on)
                {
                    // Filter out pantry ingredients from the missed ingredients
                    var filteredMissedIngredients = new List<string>();
                    
                    foreach (var ingredient in result["missedIngredients"])
                    {
                        string ingredientName = ingredient["name"].ToString();
                        MissedIngredients.Add(ingredientName);
                        bool isIngredientFound = pantryIngredientSet.Any(pantryIng => ingredientName.Contains(pantryIng) || pantryIng.Contains(ingredientName));

                        if (!isIngredientFound)
                        {
                            filteredMissedIngredients.Add(ingredientName);
                        }
                    }


                    // Update the missed ingredient count based on filtered results
                    item.SubItems.Add(filteredMissedIngredients.Count.ToString());
                    recipeMissingIngredients.Add(filteredMissedIngredients);
                }
                else
                {
                    item.SubItems.Add(MissedIngredients.Count.ToString());
                    recipeMissingIngredients.Add(MissedIngredients);
                }
                item.SubItems.Add(likes);

                resultsListView.Items.Add(item);  // Add the item to the ListView

                // Add ID and Name to lists
                recipeIDs.Add(result["id"].ToString());
                recipeNames.Add(title);

                resultCount++;
            }
        }

        private void UpdateRecipeBox(JToken recipeData, JToken stepsData)
        {
            StringBuilder sb = new StringBuilder();

            // Add ingredients to StringBuilder
            foreach (var ingredient in recipeData["extendedIngredients"])
            {
                sb.AppendLine(ingredient["original"].ToString());
            }

            sb.AppendLine("\r\n---\r\n");

            // Safely add steps to StringBuilder
            if (stepsData != null && stepsData.Any() && stepsData[0]["steps"] != null)
            {
                foreach (var step in stepsData[0]["steps"])
                {
                    sb.AppendLine($"{step["number"]}. {step["step"]}");
                }
            }
            else
            {
                sb.AppendLine("No detailed steps available.");
            }

            // Set the text of recipeBox
            recipeBox.Text = sb.ToString();
        }

        private void displayVideo(int index)
        {
            if (index >= 0 && index < videoIds.Count)
            {
                string videoId = videoIds[index];
                string html = $"<html><head>" +
                              "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>" +
                              $"</head><body><iframe id='video' src='https://www.youtube.com/embed/{videoId}' " +
                              $"width={webBrowser1.Size.Width - 20} height={webBrowser1.Size.Height - 20} frameborder='0' allowfullscreen></iframe>" +
                              "</body></html>";
                webBrowser1.DocumentText = html;
            }
        }


        internal class VideoSearch
        {
            // Adjust this method to store video IDs and display the first video
            public async Task<List<string>> RunAsync(string searchQuery) // Accept the search query as a parameter.
            {
                var videoIds = new List<string>();
                try
                {
                    var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                    {
                        ApiKey = "YT API KEY", // Make sure to replace this with your actual API key.
                        ApplicationName = this.GetType().ToString()
                    });

                    var searchListRequest = youtubeService.Search.List("snippet");
                    searchListRequest.Q = searchQuery; // Use the searchQuery parameter for the search.
                    searchListRequest.MaxResults = 25;

                    var searchListResponse = await searchListRequest.ExecuteAsync();

                    foreach (var searchResult in searchListResponse.Items)
                    {
                        if (searchResult.Id.Kind == "youtube#video")
                        {
                            videoIds.Add(searchResult.Id.VideoId);
                        }
                    }

                    return videoIds;


                }
                catch (AggregateException ex)
                {
                    // This catch block can be expanded as needed to handle specific exceptions.
                    foreach (var e in ex.InnerExceptions)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    return null;
                }
            }

        }

        private void displayPreviousRecipeVideo_Click(object sender, EventArgs e)
        {
            if (currentVideoIndex > 0)
            {
                currentVideoIndex--;
                displayVideo(currentVideoIndex);
            }
        }

        private void displayNextRecipeVideo_Click(object sender, EventArgs e)
        {
            if (currentVideoIndex < videoIds.Count - 1)
            {
                currentVideoIndex++;
                displayVideo(currentVideoIndex);
            }
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

        private void search_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Search searchForm = Search.GetInstance();
            searchForm.Show();
        }

        private void purchase_btn_Click(object sender, EventArgs e)
            // Passes Missing ingredients from selected recipe into Shop page to allow user to shop for ingredients
        {
            // 1. Check if there is at least one item selected in the ListView
            if (resultsListView.SelectedItems.Count > 0)
            {
                // 2. Retrieve the first selected item from the ListView
                ListViewItem selectedItem = resultsListView.SelectedItems[0];
                // 3. Get the index of the selected item in the ListView
                int selectedRecipeIndex = selectedItem.Index;

                // 4. Check if a valid index is obtained (sanity check, should always be true in this context)
                if (selectedRecipeIndex != -1)
                {
                    // 5. Retrieve the list of missing ingredients for the selected recipe
                    var missingIngredients = recipeMissingIngredients[selectedRecipeIndex];
                    // 6. Create a new instance of the shopIngredients form, passing the missing ingredients
                    shopIngredients shoppingForm = new shopIngredients(missingIngredients);
                    // 7. Display the new form to allow shopping for the missing ingredients
                    shoppingForm.Show();
                }
                else
                {
                    // If for some reason the selected index is invalid, show an error message
                    MessageBox.Show("Please select a recipe first.");
                }
            }
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            var helpForm = HelpForm.GetInstance();
            helpForm.Show();
            helpForm.BringToFront();
        }

        private async void saveRecipeBtn_Click(object sender, EventArgs e)
        {
            if (resultsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = resultsListView.SelectedItems[0];
                int selectedRecipeIndex = selectedItem.Index;
                if (selectedRecipeIndex != -1) // Ensure a recipe is selected
                {
                    string recipeId = recipeIDs[selectedRecipeIndex];
                    string title = recipeNames[selectedRecipeIndex];
                    List<string> ingredients = recipeMissingIngredients[selectedRecipeIndex];

                    await FirestoreService.GetInstance().AddRecipeToUser(recipeId, title, ingredients);
                    MessageBox.Show("Recipe saved successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a recipe to save.");
                }
            }
        }

        private void LikeRecipeBtn_Click(object sender, EventArgs e)
        {

        }

        private async void add_to_list_btn_Click(object sender, EventArgs e)
        {
            if (resultsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = resultsListView.SelectedItems[0];
                int selectedRecipeIndex = selectedItem.Index;

                if (selectedRecipeIndex != -1) // Ensure a recipe is selected
                {
                    await firestoreService.AddIngredientsToUserShoppingCart(recipeMissingIngredients[selectedRecipeIndex]);
                    await FirestoreService.GetInstance().AddRecipeToUser(recipeIDs[selectedRecipeIndex], recipeNames[selectedRecipeIndex], recipeMissingIngredients[selectedRecipeIndex]);
                    MessageBox.Show("Ingredients have been added to your shopping list.");
                }
                else
                {
                    MessageBox.Show("Please select a recipe first.");
                }
            }
        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            shopIngredients shoppingForm = new shopIngredients();
            shoppingForm.Show();
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {

        }

        private async void resultsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject recipeData;
            JArray stepsData;
            if (resultsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = resultsListView.SelectedItems[0];
                string selectedDishName = selectedItem.Text;


                videoIds = await new VideoSearch().RunAsync("how to make " + selectedDishName);
                if (videoIds.Count > 0)
                {
                    currentVideoIndex = 0; // Start with the first video
                    displayVideo(currentVideoIndex);
                }
                else
                {
                    MessageBox.Show("No videos found for the selected recipe.");
                }
                // Create a new HTTP request to the Spoonacular API, and fill in the query parameters
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/{recipeIDs[resultsListView.SelectedItems[0].Index]}/information"))
                {
                    try
                    {
                        // Add the API key in a request header
                        requestMessage.Headers.Add("x-api-key", apiKey);
                        // Asynchronously call the API and await the response
                        HttpResponseMessage resp = await client.SendAsync(requestMessage);

                        // Parse the JSON response
                        recipeData = JObject.Parse(await resp.Content.ReadAsStringAsync());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        return;
                    }
                }

                // Create a new HTTP request to the Spoonacular API, and fill in the query parameters
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.spoonacular.com/recipes/{recipeIDs[resultsListView.SelectedItems[0].Index]}/analyzedInstructions"))
                {
                    try
                    {
                        // Add the API key in a request header
                        requestMessage.Headers.Add("x-api-key", apiKey);
                        // Asynchronously call the API and await the response
                        HttpResponseMessage resp = await client.SendAsync(requestMessage);

                        // Parse the JSON response
                        stepsData = JArray.Parse(await resp.Content.ReadAsStringAsync());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                        return;
                    }
                    Console.WriteLine(recipeData);
                    // Update UI (ensure execution on UI thread)
                    UpdateRecipeBox(recipeData, stepsData);
                }
            }
        }
    }
}
