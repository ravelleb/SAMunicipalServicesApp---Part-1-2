using System.Windows;

namespace SAMunicipalServicesApp
{
    public partial class RequestServiceWindow : Window
    {
        private RequestService _requestService;
        //service
        public RequestServiceWindow()
        {
            InitializeComponent();
            _requestService = new RequestService();

            // Load available services
            LoadAvailableServices();
        }

        private void LoadAvailableServices()
        {

            var services = _requestService.GetAvailableServices();
            ServiceList.ItemsSource = services;
        }

        private void SubmitServiceRequest_Click(object sender, RoutedEventArgs e)
        {

            var selectedService = (string)ServiceList.SelectedItem;
            if (selectedService != null)
            {
                // Submit service reques
                _requestService.SubmitServiceRequest(selectedService, "User Location", "Request Description");
                MessageBox.Show($"Service request for {selectedService} submitted.", "Request Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a service from the list.", "No Service Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  // Close the Request
        }
    }
}
