using Phase1Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeAPIDemo
{
    public partial class Registration : Form
    {
        private FirebaseAuthHelper firebaseAuthHelper;
        private Login loginForm;
        public Registration(Point startPosition, Login login)
        {

            InitializeComponent();
            this.loginForm = login;

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.BackColor = Color.FromArgb(241, 242, 233);
            btnCancel.MouseEnter += new EventHandler(btnCancel_MouseEnter);
            btnCancel.MouseLeave += new EventHandler(btnCancel_MouseLeave);
            btnCancel.ForeColor = Color.FromArgb(64, 64, 64);
            btnCancel.Paint += new PaintEventHandler(btnCancel_Paint);

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.BackColor = Color.FromArgb(241, 242, 233);
            btnRegister.MouseEnter += new EventHandler(btnRegister_MouseEnter);
            btnRegister.MouseLeave += new EventHandler(btnRegister_MouseLeave);
            btnRegister.ForeColor = Color.FromArgb(64, 64, 64);
            btnRegister.Paint += new PaintEventHandler(btnRegister_Paint);

            this.Paint += Form_Paint;


            this.StartPosition = FormStartPosition.Manual; // Set start position to Manual
            this.Location = startPosition; // Set the start position to the provided location
            firebaseAuthHelper = new FirebaseAuthHelper();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {  
            if (txtPassword.Text.Equals(textBox3.Text)) //textBox3 is the confirm password textbox
            {
                var userCredential = await firebaseAuthHelper.SignUp(txtEmail.Text, txtPassword.Text);
                if (userCredential != null)
                {
                    string userId = userCredential.User.LocalId;  //userCredential has a User object with a LocalId property

                    // Get username from the registration form
                    string username = textBox4.Text; //textBox4 is the textbox where the user inputs their username

                    // Save user details, including the username
                    await FirestoreService.GetInstance().SaveUserDetailsAsync(userId, txtEmail.Text, username);

                    MessageBox.Show("Registration successful!");
                    this.Close();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }

        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawShadow(e.Graphics, this.txtEmail);
            DrawShadow(e.Graphics, this.txtPassword);
            DrawShadow(e.Graphics, this.textBox3);
            DrawShadow(e.Graphics, this.textBox4);
            // Repeat for other text boxes if needed.
        }
        private void DrawShadow(Graphics graphics, Control control)
        {
            int shadowSize = 5; // Adjust the size of the shadow
            int shadowMargin = 2; // Adjust the spacing between the text box and the shadow
            Rectangle shadowRect = new Rectangle(
                control.Location.X - shadowMargin,
                control.Location.Y - shadowMargin,
                control.Width + (shadowMargin * 2),
                control.Height + (shadowMargin * 2));

            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(30, Color.Black))) // Adjust the color and transparency
            {
                graphics.FillRectangle(shadowBrush, shadowRect);
            }
        }

        private void btnRegister_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Clear the button's background to be transparent or match the form's background
            g.Clear(this.BackColor);

            int shadowOffset = 3; // Adjust shadow offset as needed
            int cornerRadius = 20; // Adjust the radius to your liking
            Rectangle rect = new Rectangle(0, 0, btn.Width - shadowOffset, btn.Height - shadowOffset);
            Rectangle shadowRect = new Rectangle(shadowOffset, shadowOffset, btn.Width - shadowOffset, btn.Height - shadowOffset);

            // Draw the shadow
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, cornerRadius, cornerRadius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - cornerRadius, shadowRect.Y, cornerRadius, cornerRadius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - cornerRadius, shadowRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush brush = new PathGradientBrush(shadowPath))
                {
                    brush.WrapMode = WrapMode.Clamp;
                    ColorBlend colorBlend = new ColorBlend(3);
                    colorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(50, Color.Black), Color.FromArgb(100, Color.Black) };
                    colorBlend.Positions = new float[] { 0f, .1f, 1f };

                    brush.InterpolationColors = colorBlend;

                    g.FillPath(brush, shadowPath);
                }
            }

            // Draw the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                // Fill the rounded rectangle with the background color of the button
                g.FillPath(new SolidBrush(btn.BackColor), path);

                // Draw the button's text
                TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(161, 168, 171); // Use the appropriate RGB values for your color
        }
        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(161, 168, 171); // Use the appropriate RGB values for your color
        }
        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.White;
        }
        private void btnCancel_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Clear the button's background to be transparent or match the form's background
            g.Clear(this.BackColor);

            int shadowOffset = 3; // Adjust shadow offset as needed
            int cornerRadius = 20; // Adjust the radius to your liking
            Rectangle rect = new Rectangle(0, 0, btn.Width - shadowOffset, btn.Height - shadowOffset);
            Rectangle shadowRect = new Rectangle(shadowOffset, shadowOffset, btn.Width - shadowOffset, btn.Height - shadowOffset);

            // Draw the shadow
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, cornerRadius, cornerRadius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - cornerRadius, shadowRect.Y, cornerRadius, cornerRadius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - cornerRadius, shadowRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush brush = new PathGradientBrush(shadowPath))
                {
                    brush.WrapMode = WrapMode.Clamp;
                    ColorBlend colorBlend = new ColorBlend(3);
                    colorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(50, Color.Black), Color.FromArgb(100, Color.Black) };
                    colorBlend.Positions = new float[] { 0f, .1f, 1f };

                    brush.InterpolationColors = colorBlend;

                    g.FillPath(brush, shadowPath);
                }
            }

            // Draw the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                // Fill the rounded rectangle with the background color of the button
                g.FillPath(new SolidBrush(btn.BackColor), path);

                // Draw the button's text
                TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
    }
}
