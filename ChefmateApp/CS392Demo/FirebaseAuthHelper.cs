using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;

namespace Phase1Login
{
    internal class FirebaseAuthHelper
    {
        private FirebaseAuthProvider authProvider;
        private string apiKey = "API KEY"; // Replace this with your Firebase API Key

        public FirebaseAuthHelper()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        }

        public async Task<FirebaseAuthLink> SignUp(string email, string password)
        {
            try
            {
                // Creates a new user with email and password
                var authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return authLink;
            }
            catch (FirebaseAuthException ex)  // Catch more specific exceptions if possible
            {
                // Handle known authentication errors specifically
                MessageBox.Show("Authentication failed: " + ex.Reason, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)  // Catch all other exceptions
            {
                // Handle unknown errors
                MessageBox.Show("Failed to create user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;  // Return null if there was an exception
        }

        public async Task<FirebaseAuthLink> SignIn(string email, string password)
        {
            try
            {
                // Signs in an existing user with email and password
                var authLink = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return authLink;
            }
            catch (FirebaseAuthException ex)  // Catch specific Firebase exceptions if possible
            {
                // Handle known authentication errors specifically
                MessageBox.Show("Authentication failed: " + ex.Reason, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)  // Catch all other exceptions
            {
                // Handle unknown or other exceptions
                MessageBox.Show("Sign in failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;  // Return null if there was an exception
        }
    }
}
