using Microsoft.Win32;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System.ComponentModel;
using DocumentFormat.OpenXml.Bibliography;

namespace SAMunicipalServicesApp
{
    public partial class ReportIssuesWindow : Window
    {
        private static List<Issue> issues = new List<Issue>();

        public ReportIssuesWindow()
        {
            InitializeComponent();
        }

        private void btnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|Document files (*.pdf;*.docx)|*.pdf;*.docx"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle file attachment logic here
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Handle issue submission logic here
            string location = txtLocation.Text;
            string category = cmbCategory.Text;
            string description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;

            // Store this data in a list
            issues.Add(new Issue
            {
                Location = location,
                Category = category,
                Description = description
                // Optionally add media path here
            });

            // Show a thank you message
            lblEngagement.Visibility = Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Return to the main menu
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
