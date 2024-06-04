using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Auth;

public class FirestoreService
{
    private string userId = "";  // Private field for storing the current user's ID
    private static FirestoreService _instance;           // Singleton instance of FirestoreService
    private static readonly object _lock = new object(); // Object to lock for thread safety when creating the singleton instance
    private FirestoreDb db; // Firestore database object for database operations
    private static readonly string projectId = "PID"; //Replace with Project ID for the Firestore project

    private FirestoreService()
    {
        try
        {
            // Get the JSON credential file content.
            string jsonCredentialPath = getServiceFile();
            string jsonCredentials = File.ReadAllText(jsonCredentialPath); // Read the service account credentials from the file
            FirestoreClientBuilder builder = new FirestoreClientBuilder { JsonCredentials = jsonCredentials }; // Build a Firestore client with the service account credentials
            db = FirestoreDb.Create(projectId, builder.Build()); // Create a FirestoreDb object for interacting with the Firestore database
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to initialize Firestore: " + ex.Message);
            throw;  // Rethrow the exception to handle it further up the call stack
        }
    }

    // Static method to get the singleton instance of FirestoreService
    public static FirestoreService GetInstance()
    {
        lock (_lock)
        {
            // Ensure only one instance is created
            if (_instance == null)
            {
                _instance = new FirestoreService();
            }
        }
        return _instance;
    }

    // Method to set the current user's ID
    public void SetUserId(string id)
    {
        userId = id;
    }

    // Method to get the current user's ID
    public string GetUserId()
    {
        return userId;
    }


    // Static method to get the path to the service account key file
    public static string getServiceFile()
    {
        string baseDirName = "cs392Demo";                      // Name of the directory to look for
        string baseDirectory = FindBaseDirectory(baseDirName); // Call a method to find the directory

        // Throw an exception if the directory is not found
        if (baseDirectory == null) 
        {
            throw new InvalidOperationException("Base directory 'cs392Demo' not found.");
        }

        // Get the parent directory
        DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);
        DirectoryInfo parentDirectory = directoryInfo.Parent;
        if (parentDirectory == null)
        {
            throw new InvalidOperationException("Parent directory of 'cs392Demo' not found.");
        }

        // Return the path to the service account key file
        return Path.Combine(parentDirectory.FullName, "resources", "firebase", "serviceAccountKey.json");
    }

    // Recursive method to find a directory by name
    private static string FindBaseDirectory(string baseDirName)
    {
        // Start at the current application's directory
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        while (directory != null)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            // If the directory is found, return its full path
            if (directoryInfo.Name.Equals(baseDirName, StringComparison.OrdinalIgnoreCase))
            {
                return directory;
            }
            directory = directoryInfo.Parent?.FullName;
        }
        return null; // Return null if the directory was not found
    }

    // Asynchronous method to save user details to db
    public async Task SaveUserDetailsAsync(string userId, string email, string username)
    {
        // Get a reference to the document for the user
        DocumentReference docRef = db.Collection("users").Document(userId);

        // Create a dictionary for the user data
        Dictionary<string, object> user = new Dictionary<string, object>
        {
            { "Email", email },
            { "Username", username }
        };

        // Set the user data in Firestore
        await docRef.SetAsync(user);
    }

    // Asynchronous method to add a recipe to the user's saved recipes
    public async Task AddRecipeToUser(string recipeId, string title, List<string> ingredients)
    {
        var recipe = new Dictionary<string, object>
        {
            { title, ingredients }
        };
        await db.Collection("users").Document(userId).Collection("savedRecipes").Document(title).SetAsync(recipe);
    }

    public async Task<List<string>> GetUserRecipesAsync()
    {
        // Create a dictionary for the recipe data
        List<string> recipeTitles = new List<string>();

        // Ensure the user ID is not empty or null.
        if (string.IsNullOrEmpty(userId))
        {
            throw new InvalidOperationException("User ID is not set.");
        }

        // Get the collection of saved recipes for the user.
        try
        {
            var savedRecipesSnapshot = await db.Collection("users").Document(userId).Collection("savedRecipes").GetSnapshotAsync();

            foreach (var document in savedRecipesSnapshot.Documents)
            {
                // Assuming the document ID is the recipe title.
                recipeTitles.Add(document.Id);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving recipes: " + ex.Message);
            throw;
        }

        return recipeTitles;
    }

    public async Task DeleteUserRecipeAsync(string recipeTitle)
    {
        // Attempt to delete the recipe document by its title
        try
        {
            // Get a reference to the recipe document in the 'savedRecipes' subcollection
            DocumentReference recipeRef = db.Collection("users").Document(userId).Collection("savedRecipes").Document(recipeTitle);
            await recipeRef.DeleteAsync(); // Delete the recipe document
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting recipe: " + ex.Message);
            throw;
        }
    }

    // Asynchronous method to add new ingredients to the user's pantry
    public async Task AddIngredientsToUserPantry(List<string> newIngredients)
    {
        // Get a reference to the 'ingredients' document in the 'pantry' subcollection
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("pantry").Document("ingredients");

        // Prepare the update with the new ingredients, using ArrayUnion to prevent overwriting existing ones
        var update = new Dictionary<string, object>
        {
            { "list", FieldValue.ArrayUnion(newIngredients.ToArray()) }
        };

        // Merge the new ingredients into the existing array
        await docRef.SetAsync(update, SetOptions.MergeAll);
    }


    public async Task<List<string>> GetUserPantryIngredientsAsync()
    {
        // Get a reference to the 'ingredients' document in the 'pantry' subcollection
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("pantry").Document("ingredients");
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            // Convert the snapshot data to a dictionary
            Dictionary<string, object> pantry = snapshot.ToDictionary();
            if (pantry.TryGetValue("list", out object listObj)) // Try to get the list of ingredients
            {
                // Cast the objects to a list of strings and return
                List<object> list = (List<object>)listObj;
                return list.Cast<string>().ToList();
            }
        }
        return new List<string>(); // Return an empty list if the ingredients document does not exist
    }

    // Asynchronous method to remove an ingredient from the user's pantry
    public async Task RemoveIngredientFromUserPantry(string ingredient)
    {
        // Get a reference to the 'ingredients' document in the 'pantry' subcollection
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("pantry").Document("ingredients");

        // Using Firestore's ArrayRemove to remove the ingredient directly
        var update = new Dictionary<string, object>
        {
            { "list", FieldValue.ArrayRemove(ingredient) }
        };

        // Update the document by removing the specified ingredient
        await docRef.UpdateAsync(update);
    }

    // Asynchronous method to retrieve the username for the current user
    public async Task<string> GetUsernameAsync()
    {
        // Get a reference to the user's document
        DocumentReference userRef = db.Collection("users").Document(userId);
        DocumentSnapshot userSnapshot = await userRef.GetSnapshotAsync();
        if (userSnapshot.Exists)
        {
            // Check if the 'Username' field exists and return its value
            if (userSnapshot.TryGetValue("Username", out string username))
            {
                return username;
            }
        }
        return null; // or throw an exception, or handle the null return value in your form
    }

    // Asynchronous method to add new ingredients to the user's shopping cart
    public async Task AddIngredientsToUserShoppingCart(List<string> newIngredients)
    {
        // Get a reference to the 'ingredients' document in the 'shopping' subcollection
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("shopping").Document("ingredients");

        // Using Firestore's ArrayUnion to append ingredients without removing existing ones
        var update = new Dictionary<string, object>
        {
            { "list", FieldValue.ArrayUnion(newIngredients.ToArray()) }
        };

        // Merge the new ingredients into the existing array
        await docRef.SetAsync(update, SetOptions.MergeAll);
    }

    // Asynchronous method to add new ingredients to the user's shopping cart
    public async Task<List<string>> GetUserShoppingCartIngredientsAsync()
    {
        // Get a reference to the 'ingredients' document in the 'shopping' subcollection
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("shopping").Document("ingredients");
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            Dictionary<string, object> pantry = snapshot.ToDictionary();
            if (pantry.TryGetValue("list", out object listObj))
            {
                List<object> list = (List<object>)listObj;
                return list.Cast<string>().ToList();
            }
        }
        return new List<string>(); // Return empty list if not found
    }

    public async Task RemoveIngredientFromUserShoppingCart(string ingredient)
    {
        DocumentReference docRef = db.Collection("users").Document(userId).Collection("shopping").Document("ingredients");

        // Using Firestore's ArrayRemove to remove the ingredient directly
        var update = new Dictionary<string, object>
    {
        { "list", FieldValue.ArrayRemove(ingredient) }
    };

        await docRef.UpdateAsync(update);
    }
}
