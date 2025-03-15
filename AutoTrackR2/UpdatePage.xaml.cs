using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoTrackR2
{
    public partial class UpdatePage : UserControl
    {
        private static string currentVersion = "2.07-soundsandserver-002";
        private static string repoOwner = "Koda-Dog";
        private static string repoName = "AutoTrackR2";
        private static string downloadePath = Path.GetTempPath();
        private static string Url = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";
        private string latestVersion;

        public UpdatePage()
        {
            InitializeComponent();
            CurrentVersionText.Text = currentVersion;
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            try
            {
                // Fetch the latest release info from GitHub
                latestVersion = await GetLatestVersionInfoFromGitHub();

                // Update the Available Version field
                AvailableVersionText.Text = latestVersion;

                // Enable the Install button if a new version is available
                if (IsNewVersionAvailable(currentVersion, latestVersion))
                {
                    InstallButton.IsEnabled = true;
                    InstallButton.Style = (Style)FindResource("ButtonStyle");
                }
            }
            catch (Exception ex)
            {
                AvailableVersionText.Text = "Error checking updates.";
                MessageBox.Show($"Failed to check for updates: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task<string> GetLatestVersionInfoFromGitHub()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "AutoTrackR2");

            string url = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases";

            try
            {
                // Attempt to fetch the latest release
                var response = await client.GetStringAsync($"{url}/latest");

                // Parse the JSON using System.Text.Json
                using var document = System.Text.Json.JsonDocument.Parse(response);
                var root = document.RootElement;
                var tagName = root.GetProperty("tag_name").GetString();

                return tagName;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Fallback to releases list if 'latest' not found
                var response = await client.GetStringAsync(url);

                using var document = System.Text.Json.JsonDocument.Parse(response);
                var root = document.RootElement;

                // Get the tag name of the first release
                if (root.GetArrayLength() > 0)
                {
                    var firstRelease = root[0];
                    return firstRelease.GetProperty("tag_name").GetString();
                }

                throw new Exception("No releases found.");
            }
        }

        private async Task<string> GetLatestVersionFileFromGitHub(string version)
        {

            try
            {
                string fileName = $"{repoName}_setup.exe"; 
                string downloadUrl = $"https://github.com/{repoOwner}/{repoName}/releases/download/{version}/{fileName}";
                string updatePath = Path.Combine(downloadePath, fileName);

                await DownloadFileAsync(downloadUrl, Path.Combine(downloadePath, updatePath));

                AvailableVersionText.Text = "Downloaded update.";
                return updatePath;
            }
            catch (Exception ex)
            {
                AvailableVersionText.Text = "Error download update.";
                MessageBox.Show($"Failed to download update: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "error";
            }
        }

        static async Task DownloadFileAsync(string url, string zielPfad)
        {
            using (WebClient webClient = new WebClient())
            {
                await webClient.DownloadFileTaskAsync(new Uri(url), zielPfad);
            }
        }

        private bool IsNewVersionAvailable(string currentVersion, string latestVersion)
        {
            // Return true if the versions are different
            return !currentVersion.Equals(latestVersion, StringComparison.Ordinal);
        }

        private async void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InstallButton.IsEnabled = false;
                InstallButton.Content = "Preparing to Update...";

                string updatePath = await GetLatestVersionFileFromGitHub(latestVersion);
                if (updatePath is not "error")
                {
                    MessageBox.Show("Update process has started. Please follow the instructions of the Installer.", "Update Started", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Run update programm
                    System.Diagnostics.Process.Start(updatePath);

                    // Gracefully close the app after running the script
                    Application.Current.Shutdown();             
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                InstallButton.IsEnabled = true;
                InstallButton.Content = "Install Update";
            }
        }
    }
}
