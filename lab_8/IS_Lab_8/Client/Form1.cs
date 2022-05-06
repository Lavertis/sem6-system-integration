using System.Net;
using System.Text;
using Newtonsoft.Json;
using Server.Entities;
using Server.Models;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new();
        private string _token = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SignOut()
        {
            userCountLabel.Text = "";
            magicNumberLabel.Text = "";
            userListTextBox.Text = "";
            jwtTokenTextBox.Text = "";
            _token = "";
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
        }

        private bool IsUserSignedIn()
        {
            if (_token != string.Empty) return true;
            MessageBox.Show(
                @"Please sign in first.",
                @"Not signed in",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop
            );
            return false;
        }

        private bool IsRequestForbidden(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.Forbidden) return false;
            MessageBox.Show(
                @"You are not allowed to perform this action.",
                @"Action not allowed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return true;
        }

        private async void signInButton_Click(object sender, EventArgs e)
        {
            SignOut();
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;
            var authenticationRequest = new AuthenticationRequest(username, password);

            var jsonRequest = JsonConvert.SerializeObject(authenticationRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7266/api/User/authenticate", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonResult);
                if (authenticationResponse == null)
                    return;

                _token = authenticationResponse.Token;
                jwtTokenTextBox.Text = _token;
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
            }
            else
            {
                _token = string.Empty;
                MessageBox.Show(
                    @"Invalid username or password.",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void getUserCountButton_Click(object sender, EventArgs e)
        {
            if (!IsUserSignedIn()) return;
            var response = await _httpClient.GetAsync("https://localhost:7266/api/User/count");
            if (IsRequestForbidden(response)) return;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var userCount = JsonConvert.DeserializeObject<int>(jsonResult);
                userCountLabel.Text = userCount.ToString();
            }
            else
            {
                userCountLabel.Text = "";
            }
        }

        private async void getMagicNumberButton_Click(object sender, EventArgs e)
        {
            if (!IsUserSignedIn()) return;

            var response = await _httpClient.GetAsync("https://localhost:7266/api/Math/random-prime");
            if (IsRequestForbidden(response)) return;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var magicNumber = JsonConvert.DeserializeObject<int>(jsonResult);
                magicNumberLabel.Text = magicNumber.ToString();
            }
            else
            {
                magicNumberLabel.Text = "";
            }
        }

        private async void getAllUsersButton_Click(object sender, EventArgs e)
        {
            if (!IsUserSignedIn()) return;

            var response = await _httpClient.GetAsync("https://localhost:7266/api/User");
            if (IsRequestForbidden(response)) return;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var userList = JsonConvert.DeserializeObject<List<User>>(jsonResult);
                if (userList == null)
                    return;
                var listAsString = string.Join(Environment.NewLine, userList);
                userListTextBox.Text = listAsString;
            }
            else
            {
                userListTextBox.Text = string.Empty;
            }
        }
    }
}