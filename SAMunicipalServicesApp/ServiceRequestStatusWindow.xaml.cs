using System.Windows;

namespace SAMunicipalServicesApp
{
    /// <summary>
    /// Interaction logic for ServiceRequestStatusWindow.xaml
    /// </summary>
    public partial class ServiceRequestStatusWindow : Window
    {
        public ServiceRequestStatusWindow()
        {
            InitializeComponent();
        }

     
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  
        }
    }
}
