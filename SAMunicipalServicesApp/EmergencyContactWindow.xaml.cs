using System.Windows;

namespace SAMunicipalServicesApp
{
    public partial class EmergencyContactWindow : Window
    {
        private EmergencyContactService _emergencyContactService;  

        public EmergencyContactWindow()
        {
            InitializeComponent();
            _emergencyContactService = new EmergencyContactService();

            LoadEmergencyContacts();
        }

        private void LoadEmergencyContacts()
        {
            var contacts = _emergencyContactService.GetEmergencyContacts();
            ContactList.ItemsSource = contacts;
        }

        private void SendEmergencyRequest_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected contact from the ListBox
            var selectedContact = (string)ContactList.SelectedItem;
            if (selectedContact != null)
            {
                _emergencyContactService.SendEmergencyRequest(selectedContact, "Help needed!");
                MessageBox.Show($"Emergency request sent to {selectedContact}");
            }
            else
            {
                MessageBox.Show("Please select a contact from the list.");
            }
        }

        // Back MainWindow
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  // Close the EmergencyContactWindow and return to MainWindow
        }
    }
}
