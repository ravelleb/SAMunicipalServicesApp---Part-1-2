using System.Windows;

namespace SAMunicipalServicesApp
{
    public partial class EmergencyContactWindow : Window
    {
        private readonly EmergencyContactService _emergencyContactService;

        public EmergencyContactWindow()
        {
            InitializeComponent();
            _emergencyContactService = new EmergencyContactService();

            LoadEmergencyContacts();
        }

        private void LoadEmergencyContacts()
        {
            var contacts = _emergencyContactService.GetEmergencyContacts();
            ContactList.ItemsSource = contacts;  // Display emergency contacts in ListBox
        }

        private void SendEmergencyRequest_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (EmergencyContact)ContactList.SelectedItem;
            if (selectedContact != null)
            {
                _emergencyContactService.SendEmergencyRequest(selectedContact, "Help needed!");
                MessageBox.Show($"Emergency request sent to {selectedContact.Name} ({selectedContact.ServiceType})");
            }
            else
            {
                MessageBox.Show("Please select a contact from the list.");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
