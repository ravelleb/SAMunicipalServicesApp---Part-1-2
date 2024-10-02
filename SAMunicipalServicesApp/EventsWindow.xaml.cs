using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAMunicipalServicesApp
{
    /// <summary>
    /// Interaction logic for EventsWindow.xaml
    /// </summary>

    public partial class EventsWindow : Window
    {
        public EventsWindow()
        {
            InitializeComponent();
        }

        // Back button MainWindow
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  // Close the EventsWindow and return to MainWindow
        }
    }
}

