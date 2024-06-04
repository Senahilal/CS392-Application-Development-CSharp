using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using SerpAPITest;
using System.IO;

namespace RecipeAPIDemo
{
    public partial class Foraging : Form
    {
        private FirestoreService firestoreService;
        private const string PlantApiKey = "API KEY"; // Plant.id API key
        public static string comName = ""; // Store result of identified plant
        public Foraging()
        {
            InitializeComponent();
            firestoreService = FirestoreService.GetInstance(); // For pantry function
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName; // Upload photo in FileDialog window
                try
                {
                    pictureBox2.Image = Image.FromFile(imagePath); // Show uploaded photo
                    // Show hidden text for the image boxes
                    Reference.Show();
                    Uploaded.Show();

                    // Get plant information using the API
                    string jsonResponse = await IdentifyPlant(imagePath);
                    Console.WriteLine(jsonResponse);

                    // Parse the returned JSON
                    var (commonName, scientificName, plantClass, genus, order, family, phylum, kingdom, edibleParts, imageUrl) = ExtractPlantDetails(jsonResponse);

                    // Displaying the details of the plants
                    lblInfo.Text = $"Common Name: {commonName}";
                    
                    // Load and display the returned reference image
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        var imageBytes = await new HttpClient().GetByteArrayAsync(imageUrl);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }

                    // Check if the plants are edible
                    if (edibleParts == "")
                    {
                        MessageBox.Show("No edible parts found!!!", "No edible parts found!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Parse plant name from return JSON
        private (string CommonName, string ScientificName, string Class, string Genus, string Order, string family, string phylum, string kingdom, string edibleParts, string ImageUrl) ExtractPlantDetails(string jsonResponse)
        {
            JObject responseObject = JObject.Parse(jsonResponse);

            // Always pick the most frequent common name
            JToken firstSuggestion = responseObject["result"]?["classification"]?["suggestions"]?.FirstOrDefault();

            string commonName = firstSuggestion?["details"]?["common_names"]?.FirstOrDefault()?.ToString() ?? "Common names not found";
            comName = commonName;
            string scientificName = firstSuggestion?["name"]?.ToString() ?? "Scientific name not found";
            string plantClass = firstSuggestion?["details"]?["taxonomy"]?["class"]?.ToString() ?? "Class not found";
            string genus = firstSuggestion?["details"]?["taxonomy"]?["genus"]?.ToString() ?? "Genus not found";
            string order = firstSuggestion?["details"]?["taxonomy"]?["order"]?.ToString() ?? "Genus not found";
            string family = firstSuggestion?["details"]?["taxonomy"]?["family"]?.ToString() ?? "Genus not found";
            string phylum = firstSuggestion?["details"]?["taxonomy"]?["phylum"]?.ToString() ?? "Genus not found";
            string kingdom = firstSuggestion?["details"]?["taxonomy"]?["kingdom"]?.ToString() ?? "Genus not found";
            string edibleParts = firstSuggestion?["details"]?["edible_parts"]?.ToString() ?? "No edible parts";
            string imageUrl = firstSuggestion?["details"]?["image"]?["value"]?.ToString() ?? string.Empty;

            return (commonName, scientificName, plantClass, genus, order, family, phylum, kingdom, edibleParts, imageUrl);
        }

        // Access the API to get a JSON containing plant information
        private async Task<string> IdentifyPlant(string imagePath)
        {
            // Convert image to base64
            string base64Image = ImageToBase64(imagePath);

            // Create the HttpClient and HttpRequestMessage
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://plant.id/api/v3/identification?details=common_names,url,taxonomy,rank,image,edible_parts,watering &language=en");

            // Add the API key to the request header
            request.Headers.Add("Api-Key", PlantApiKey);

            // Create the JSON payload with the base64 encoded image
            string jsonPayload = "{\"images\": [\"data:image/jpeg;base64," + base64Image + "\"]}";
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                // Send the request to the API
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throws if not 2xx

                // Read the response as a string
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);
                return jsonResponse;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine($"Exception caught: {ex.Message}");
                return null; // Or however you wish to handle this
            }
        }

        private string ImageToBase64(string imagePath)
        {
            // Read the file into a byte array
            byte[] imageArray = System.IO.File.ReadAllBytes(imagePath);
            // Convert byte array to base64 string
            return Convert.ToBase64String(imageArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Shopping function
        private void button3_Click(object sender, EventArgs e)
        {
            var input = comName;
            if (string.IsNullOrWhiteSpace(input)) return;
            input = input.Trim();
            var ingredients = new List<string> { input };
            this.Close();
            shopIngredients shopForage = new shopIngredients(ingredients);
            shopForage.Show();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            label.Text = "";
        }

        // Pantry function
        private async void button2_Click(object sender, EventArgs e)
        {
            var input = comName;
            if (string.IsNullOrWhiteSpace(input)) return;

            input = input.Trim();

            var ingredients = new List<string> { input };

            try
            {
                await firestoreService.AddIngredientsToUserPantry(ingredients);
                MessageBox.Show("Successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add ingredients: {ex.Message}");
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Search searchForm = Search.GetInstance();
            searchForm.Show();
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profileForm = new Profile();
            profileForm.Show();
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            var helpForm = HelpForm.GetInstance();
            helpForm.Show();
            helpForm.BringToFront();
        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            shopIngredients shoppingForm = new shopIngredients();
            shoppingForm.Show();
        }

        private void Foraging_Load(object sender, EventArgs e)
        {
            Reference.Hide();
            Uploaded.Hide();
        }
    }
}
