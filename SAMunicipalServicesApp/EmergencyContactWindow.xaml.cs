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
           
            var selectedContact = (EmergencyContact)ContactList.SelectedItem;
            if (selectedContact != null)
            {
                _emergencyContactService.SendEmergencyRequest(selectedContact, "Help needed!");
                MessageBox.Show($"Emergency request sent to {selectedContact.Name}");
            }
            else
            {
                MessageBox.Show("Please select a contact from the list.");
            }
        }

        // Back to Main Window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
