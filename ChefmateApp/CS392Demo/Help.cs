using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SerpAPITest;
using Google.Cloud.Firestore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeAPIDemo
{
    public partial class HelpForm : Form
    {

        private static HelpForm _instance;
        private static readonly object _lock = new object();

        private static readonly HttpClient client = new HttpClient();
        private List<object> conversationContext;
        public HelpForm()
        {
            InitializeComponent();
            resetConversation();
        }

        // Public static method to get the instance of the HelpForm.
        public static HelpForm GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new HelpForm();
                }
                return _instance;
            }
        }

        // Override the OnFormClosing method to hide the form instead of closing it.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }

        private void resetConversation()
        {
            conversationContext = new List<object>
            {
                new { role = "system", content = "You are a helpful assistant who provides suggestions on meals to prepare based on provided criteria." }
            };
            helpResultsBox.Text = "";
            helpResultsBox.SelectionFont = new Font(helpResultsBox.Font, FontStyle.Bold);
            helpResultsBox.AppendText("Assistant: ");
            helpResultsBox.SelectionFont = helpResultsBox.Font;
            helpResultsBox.AppendText("How can I help you today?\r\n");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            helpSearchBox.Enabled = false; // Prevents multiple clicks
            help_ask_btn.Enabled = false;

            String textbox_content = helpSearchBox.Text;

            string apiKey = "API KEY"; //API KEY GOES HERE
            // Get the search query from the text box
            conversationContext.Add(new { role = "user", content = textbox_content });

            // Clear the content of the TextBox (helpSearchBox) by setting Text to an empty string
            helpSearchBox.Text = string.Empty;

            // Create an HTTP request to the Chat GPT API
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"https://api.openai.com/v1/chat/completions"))
            {
                try
                {
                    // Build the JSON body of the request
                    var jsonBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = conversationContext
                    };

                    // Serialize the JSON body
                    string jsonBodyString = JsonConvert.SerializeObject(jsonBody);
                    requestMessage.Content = new StringContent(jsonBodyString);

                    // Set Authorization/Content-Type Headers
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Asynchronously call the API and await the response
                    HttpResponseMessage resp = await client.SendAsync(requestMessage);

                    if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        // Remove the last thing the user said from the conversation context since it was not processed
                        conversationContext.RemoveAt(conversationContext.Count - 1);

                        MessageBox.Show($"An error occurred: {await resp.Content.ReadAsStringAsync()}");
                        return;
                    }

                    // Parse the JSON response
                    JObject data = JObject.Parse(await resp.Content.ReadAsStringAsync());

                    // Put the response into the conversation context
                    conversationContext.Add(new { role = "assistant", content = data["choices"][0]["message"]["content"].ToString() });

                    // Get the response and put it into the result box, while fixing the line endings for windows
                    string normalized = Regex.Replace(data["choices"][0]["message"]["content"].ToString(), @"\r\n|\n\r|\n|\r", "\r\n");

                    helpResultsBox.AppendText("******************************************************************************************************************\r\n");
                    helpResultsBox.SelectionFont = new Font(helpResultsBox.Font, FontStyle.Bold);
                    helpResultsBox.AppendText("You: ");
                    helpResultsBox.SelectionFont = helpResultsBox.Font;
                    helpResultsBox.AppendText(textbox_content + "\r\n");

                    helpResultsBox.SelectionFont = new Font(helpResultsBox.Font, FontStyle.Bold);
                    helpResultsBox.AppendText("Assistant: ");
                    helpResultsBox.SelectionFont = helpResultsBox.Font;
                    helpResultsBox.AppendText(normalized + "\r\n\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    helpSearchBox.Enabled = true; // Re-enable the button
                    help_ask_btn.Enabled = true;
                }
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search searchForm = Search.GetInstance();
            searchForm.Show();
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profileForm = new Profile();
            profileForm.Show();
        }

        private void forage_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Foraging foragingForm = new Foraging();
            foragingForm.Show();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            resetConversation();
        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            shopIngredients shoppingForm = new shopIngredients();
            shoppingForm.Show();
        }
    }
}
