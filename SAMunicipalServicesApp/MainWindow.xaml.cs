using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SAMunicipalServicesApp
{
    public partial class MainWindow : MetroWindow
    {
        private readonly EmergencyContactService _emergencyContactService = new EmergencyContactService();
        private readonly RequestService _requestService = new RequestService();
        private readonly ComingSoonService _comingSoonService = new ComingSoonService();
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly List<string> _videoPaths = new List<string>();
        private int _currentVideoIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadWeatherData();
            LoadCityNews();
            InitializeVideoPlaylist();
            PlayNextVideo();
            this.StateChanged += MainWindow_StateChanged;
        }

        private void BtnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            var reportIssuesWindow = new ReportIssuesWindow();
            reportIssuesWindow.Show();
            this.Close();  // Closes-Opens 
        }

        private void BtnEmergencyContactServices_Click(object sender, RoutedEventArgs e)
        {
            var emergencyContactWindow = new EmergencyContactWindow();
            emergencyContactWindow.Show();
            this.Close();
        }

        private void BtnRequestService_Click(object sender, RoutedEventArgs e)
        {
            var requestServiceWindow = new RequestServiceWindow();
            requestServiceWindow.Show();
            this.Close();
        }

        private void BtnEvents_Click(object sender, RoutedEventArgs e)
        {//overflow
            var eventsWindow = new EventsWindow();
            eventsWindow.Show();
            this.Close();
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {//stackoverflow
            if (this.WindowState != WindowState.Minimized)
            {
                this.Width = SystemParameters.PrimaryScreenWidth;
                this.Height = SystemParameters.PrimaryScreenHeight;
                //this.Width = SystemParameters.VirtualScreenWidth;
                //this.Height =SystemParameters.VirtualScreenHeight;
                //this.Width = SystemParameters.WorkArea.Width                            
                //this.Height =SystemParameters.WorkArea.Height;
            }
        }

        private void BtnSubmitEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To submit an event or announcement, please email admin@municipalservices.com with the event details.",
                "Submit Event/Announcement",//madeup email
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void BtnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            var serviceRequestStatusWindow = new ServiceRequestStatusWindow();
            serviceRequestStatusWindow.Show();
            this.Close();
        }

        //ContentDisplay element
        private void DisplayContent(string content)
        {
            ContentDisplay.Content = new TextBlock
            {
                Text = content,
                FontSize = 16,
                Foreground = new SolidColorBrush(Colors.White),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10)
            };
        }

        private async void LoadWeatherData()
        {
            string apiKey = "e561551eb236deefec2cf7663887eac5";
            string cityName = "Durban"; // Hard-coded, but can become dynamic
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={apiKey}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseData);

                DisplayWeatherData(weatherData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get weather data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayWeatherData(WeatherData weatherData)
        {
            if (weatherData != null)
            {
                lblCity.Text = $"City: {weatherData.Name}";
                lblTemperature.Text = $"Temperature: {weatherData.Main.Temp}°C";
                lblCondition.Text = $"Condition: {weatherData.Weather[0].Description}";
            }
        }

        //city news:)
        private void LoadCityNews()
        {
            // Dummy news for demonstration purposes
            List<string> newsItems = new List<string>
    {
        "Road Maintenance on Main St. - Expect delays from June 10 to June 15.",
        "Public Holiday on June 16 - Municipal offices will be closed.",
        "City Council Meeting: June 20 - Open for all citizens to attend.",
        "New Park Opening on July 1 - A new park is being inaugurated in the city center.",
        "Water Supply Disruption: June 25 - Maintenance on the water system will cause outages."
    };

            // Clear news items
            CityNews.Children.Clear();

            
            foreach (string news in newsItems)
            {
                TextBlock newsTextBlock = new TextBlock
                {
                    Text = $"• {news}",
                    FontSize = 14,
                    Foreground = Brushes.LightGray,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Left, 
                    Margin = new Thickness(0, 5, 0, 10) 
                };

                CityNews.Children.Add(newsTextBlock);
            }
        }

        private void InitializeVideoPlaylist()//+video for temporary purpose..
        {
            _videoPaths.Add(@"c:\users\rbalr\source\repos\prog part 2\samunicipalservicesapp\images\weather\moving.mp4");
            _videoPaths.Add(@"c:\users\rbalr\source\repos\prog part 2\samunicipalservicesapp\images\weather\rain.mp4");
            _videoPaths.Add(@"c:\users\rbalr\source\repos\prog part 2\samunicipalservicesapp\images\weather\solar.mp4");
            _videoPaths.Add(@"c:\users\rbalr\source\repos\prog part 2\samunicipalservicesapp\images\weather\sunset.mp4");
            _videoPaths.Add(@"c:\users\rbalr\source\repos\prog part 2\samunicipalservicesapp\images\weather\tornado.mp4");
        }

        private void PlayNextVideo()
        {
            if (_videoPaths.Count == 0) return;

            WeatherVideoPlayer.Source = new Uri(_videoPaths[_currentVideoIndex]);
            WeatherVideoPlayer.Play();
            //wanted to cycle the video after it finishes
            _currentVideoIndex = (_currentVideoIndex + 1) % _videoPaths.Count;
        }

        private void WeatherVideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            PlayNextVideo();
        }

        // Classes for weather data
        public class WeatherData
        {
            public Main Main { get; set; }
            public Weather[] Weather { get; set; }
            public string Name { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
        }

        public class Weather
        {
            public string Description { get; set; }
        }
    }
}
