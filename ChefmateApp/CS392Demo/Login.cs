using Phase1Login;
using SerpAPITest;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RecipeAPIDemo
{
    public partial class Login : Form
    {
        private FirebaseAuthHelper firebaseAuthHelper;
        public Login()
        {
            InitializeComponent();
            firebaseAuthHelper = new FirebaseAuthHelper();
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(241,242,233);
            btnLogin.MouseEnter += new EventHandler(btnLogin_MouseEnter);
            btnLogin.MouseLeave += new EventHandler(btnLogin_MouseLeave);
            btnLogin.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogin.Paint += new PaintEventHandler(btnLogin_Paint);

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.BackColor = Color.FromArgb(241, 242, 233);
            btnRegister.MouseEnter += new EventHandler(btnRegister_MouseEnter);
            btnRegister.MouseLeave += new EventHandler(btnRegister_MouseLeave);
            btnRegister.ForeColor = Color.FromArgb(64, 64, 64);
            btnRegister.Paint += new PaintEventHandler(btnRegister_Paint);

            this.Paint += Form_Paint;

        }
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(161,168,171); // Use the appropriate RGB values for your color
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.White;
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(161, 168, 171); // Use the appropriate RGB values for your color
        }
        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.White;
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
        private void btnLogin_Paint(object sender, PaintEventArgs e)
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


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var authLink = await firebaseAuthHelper.SignIn(txtEmail.Text, txtPassword.Text);

            if (authLink != null)
            {
                // Login was successful
                FirestoreService.GetInstance().SetUserId(authLink.User.LocalId);  //`LocalId` is the user ID property

                this.Hide();
                Search searchForm = Search.GetInstance();
                searchForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your email and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawShadow(e.Graphics, txtEmail);
            DrawShadow(e.Graphics, txtPassword);
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registrationForm = new Registration(this.Location, this);
            registrationForm.Show();
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
