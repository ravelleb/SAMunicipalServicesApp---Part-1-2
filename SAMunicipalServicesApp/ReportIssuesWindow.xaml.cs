using Microsoft.Win32;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace SAMunicipalServicesApp
{
    public partial class ReportIssuesWindow : Window
    {
        private static readonly List<Issue> issues = new List<Issue>();
        private string attachedMediaPath = string.Empty;
        private static UserEngagement userEngagement = new UserEngagement();

        public ReportIssuesWindow()
        {
            InitializeComponent();
        }

        private void BtnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|Document files (*.pdf;*.docx)|*.pdf;*.docx"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                attachedMediaPath = openFileDialog.FileName;

                // Display the image preview if it's an image
                if (attachedMediaPath.EndsWith(".png") || attachedMediaPath.EndsWith(".jpeg") || attachedMediaPath.EndsWith(".jpg"))
                {
                    BitmapImage bitmap = new BitmapImage(new System.Uri(attachedMediaPath));
                    imgPreview.Source = bitmap;
                    imgPreview.Visibility = Visibility.Visible;
                }
                else
                {
                    imgPreview.Visibility = Visibility.Collapsed;
                }
            }
        }

        private static int submissionCount = 0; // Track number

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string streetAddress = txtStreetAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string landmark = txtLandmark.Text.Trim();
            string inputCategory = cmbCategory.Text.Trim();
            string inputDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim();

            // Validate the address details
            if (string.IsNullOrWhiteSpace(streetAddress) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(postalCode))
            {
                MessageBox.Show("Please provide a complete address including Street, City, and Postal Code.", "Incomplete Address", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add the issue to the list
            issues.Add(new Issue
            {
                StreetAddress = streetAddress,
                City = city,
                PostalCode = postalCode,
                Landmark = landmark,
                IssueCategory = inputCategory,
                IssueDescription = inputDescription,
                MediaPath = attachedMediaPath
            });

            // Update submission count and display acknowledgment
            submissionCount++;
            lblEngagement.Text = $"Thank you for your contribution! You have submitted {submissionCount} issue(s).";
            lblEngagement.Visibility = Visibility.Visible;

            // Display the submitted details in the preview section
            lblStreetAddress.Text = string.IsNullOrWhiteSpace(streetAddress) ? "N/A" : streetAddress;
            lblCity.Text = string.IsNullOrWhiteSpace(city) ? "N/A" : city;
            lblPostalCode.Text = string.IsNullOrWhiteSpace(postalCode) ? "N/A" : postalCode;
            lblLandmark.Text = string.IsNullOrWhiteSpace(landmark) ? "N/A" : landmark;
            lblCategory.Text = string.IsNullOrWhiteSpace(inputCategory) ? "N/A" : inputCategory;
            lblDescription.Text = string.IsNullOrWhiteSpace(inputDescription) ? "N/A" : inputDescription;

            if (!string.IsNullOrWhiteSpace(attachedMediaPath) &&
                (attachedMediaPath.EndsWith(".png") || attachedMediaPath.EndsWith(".jpeg") || attachedMediaPath.EndsWith(".jpg")))
            {
                BitmapImage bitmap = new BitmapImage(new System.Uri(attachedMediaPath));
                imgPreview.Source = bitmap;
                imgPreview.Visibility = Visibility.Visible;
            }
            else
            {
                imgPreview.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnSubmitFeedback_Click(object sender, RoutedEventArgs e)
        {
            string feedback = txtFeedback.Text.Trim();

            if (!string.IsNullOrWhiteSpace(feedback))
            {
                userEngagement.AddFeedback(feedback);
                MessageBox.Show("Thank you for your feedback!", "Feedback Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
                txtFeedback.Clear();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

    public class Issue
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Landmark { get; set; }
        public string IssueCategory { get; set; }
        public string IssueDescription { get; set; }
        public string MediaPath { get; set; }
    }

    
}
