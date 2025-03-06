using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlinePosBilling
{
    public partial class UserLoginPanel: Form
    {
        public UserLoginPanel()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = userNametext.Text;
            string password = passwordtext.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password",
                                "Incomplete Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var loginData = new { UserName = username, Password = password };
            string json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");
                    HttpResponseMessage response = await client.PostAsync("login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);

                        if (loginResponse != null && loginResponse.success)
                        {
                            MessageBox.Show("Login successful",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            // Open Billing form and pass username and store
                            var billingForm = new onlinePosBilling.Component.Billing(loginResponse.user.UserName, loginResponse.user.Store);
                            billingForm.Show();

                            // Optionally hide or close the login form
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Login failed: " + (loginResponse?.message ?? "Unknown error"),
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Server error: " + response.StatusCode,
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message,
                                "Connection Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Define classes to match the API response structure
        public class LoginResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public User user { get; set; }
        }

        public class User
        {
            public string UserName { get; set; }
            public string Image { get; set; }
            public string Store { get; set; }
            public string Type { get; set; }
            public string Email { get; set; }
            public string LastLogin { get; set; }
        }
    }
}
