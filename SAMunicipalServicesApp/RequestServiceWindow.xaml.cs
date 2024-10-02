using System.Windows;

namespace SAMunicipalServicesApp
{
    public partial class RequestServiceWindow : Window
    {
        private RequestService _requestService;  // Reference to the backend service

        public RequestServiceWindow()
        {
            InitializeComponent();
            _requestService = new RequestService();

            // Load available services into the ListBox
            LoadAvailableServices();
        }

        private void LoadAvailableServices()
        {
            // Retrieve available services and bind them to the ListBox
            var services = _requestService.GetAvailableServices();
            ServiceList.ItemsSource = services;
        }

        private void SubmitServiceRequest_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected service from the ListBox
            var selectedService = (string)ServiceList.SelectedItem;
            if (selectedService != null)
            {
                // Submit service request using the backend service
                _requestService.SubmitServiceRequest(selectedService, "User Location", "Request Description");
                MessageBox.Show($"Service request for {selectedService} submitted.", "Request Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a service from the list.", "No Service Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Back button MainWindow
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  // Close the RequestServiceWindow and return to MainWindow
        }
    }
}
