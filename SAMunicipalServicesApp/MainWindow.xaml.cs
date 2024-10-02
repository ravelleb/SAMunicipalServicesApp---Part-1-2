using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SAMunicipalServicesApp
{
    public partial class MainWindow : MetroWindow
    {
        private EmergencyContactService _emergencyContactService = new EmergencyContactService();
        private RequestService _requestService = new RequestService();
        private ComingSoonService _comingSoonService = new ComingSoonService();

        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void BtnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssuesWindow reportIssuesWindow = new ReportIssuesWindow();
            reportIssuesWindow.Show();
            this.Hide();  // Hides the MainWindow but keeps the app running
        }

        
        private void BtnEmergencyContactServices_Click(object sender, RoutedEventArgs e)
        {
            EmergencyContactWindow emergencyContactWindow = new EmergencyContactWindow();
            emergencyContactWindow.Show();
            this.Hide();  
        }

        
        private void BtnRequestService_Click(object sender, RoutedEventArgs e)
        {
            RequestServiceWindow requestServiceWindow = new RequestServiceWindow();
            requestServiceWindow.Show();
            this.Hide();  
        }

        
        private void BtnEvents_Click(object sender, RoutedEventArgs e)
        {
            EventsWindow eventsWindow = new EventsWindow();
            eventsWindow.Show();
            this.Hide();  
        }

        
        private void BtnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow serviceRequestStatusWindow = new ServiceRequestStatusWindow();
            serviceRequestStatusWindow.Show();
            this.Hide();  
        }

        //ContentControl
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
    }
}
