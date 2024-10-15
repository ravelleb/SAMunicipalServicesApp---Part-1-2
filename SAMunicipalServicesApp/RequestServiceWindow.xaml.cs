using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SAMunicipalServicesApp
{
    public partial class RequestServiceWindow : Window
    {
        public RequestServiceWindow()
        {
            InitializeComponent();
            LoadAvailableServices();
        }

        private void LoadAvailableServices()
        {
            //logos
            List<ServiceItem> services = new List<ServiceItem>
            {
                new ServiceItem { Name = "Water Supply Issue", ImagePath = "Images\\Weather\\water.png" },
                new ServiceItem { Name = "Road Maintenance", ImagePath = "Images\\Weather\\road.png" },
                new ServiceItem { Name = "Electricity Issue", ImagePath = "Images\\Weather\\electricity.jpeg" },
                new ServiceItem { Name = "Garbage Collection", ImagePath = "Images\\Weather\\garbage.png" }
            };

            ServiceList.ItemsSource = services;
        }

        private void SubmitServiceRequest_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = (ServiceItem)ServiceList.SelectedItem;

            if (selectedService != null)
            {
                MessageBox.Show($"Service request for '{selectedService.Name}' has been submitted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a service from the list.");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  
            // Close
        }
    }

    public class ServiceItem
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
