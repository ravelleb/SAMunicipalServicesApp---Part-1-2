using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SAMunicipalServicesApp
{
    public partial class EventsWindow : Window
    {
        private ObservableCollection<Event> Events { get; set; }
        private ObservableCollection<Event> FilteredEvents { get; set; }
        private ObservableCollection<Event> RecommendedEvents { get; set; }

        public EventsWindow()
        {
            InitializeComponent();
            InitializeCollections();
            LoadEvents();
            SetupEventHandlers();
        }

        private void InitializeCollections()
        {
            Events = new ObservableCollection<Event>();
            FilteredEvents = new ObservableCollection<Event>();
            RecommendedEvents = new ObservableCollection<Event>();

            eventsListBox.ItemsSource = FilteredEvents;
            recommendationsListBox.ItemsSource = RecommendedEvents;
        }

        private void SetupEventHandlers()
        {
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbCategoryFilter.SelectionChanged += (s, e) => ApplyFilters();
            datePicker.SelectedDateChanged += (s, e) => ApplyFilters();
        }

        private void LoadEvents()
        {
            //sampls added to test 
            Events.Add(new Event
            {
                EventName = "Community Clean-up Drive",
                EventDate = new DateTime(2024, 2, 15),
                Category = "Community",
                EventDescription = "Join us for a community-wide clean-up initiative to make Durban cleaner.",
                Location = "Central Park, Durban, KwaZulu-Natal",
                MaxAttendees = 150,
                CurrentAttendees = 120
            });

            Events.Add(new Event
            {
                EventName = "Music Festival",
                EventDate = new DateTime(2024, 3, 5),
                Category = "Music",
                EventDescription = "Live music festival featuring top South African artists.",
                Location = "Kings Park Stadium, Durban, KwaZulu-Natal",
                MaxAttendees = 500,
                CurrentAttendees = 450
            });

            Events.Add(new Event
            {
                EventName = "Food and Wine Expo",
                EventDate = new DateTime(2024, 4, 20),
                Category = "Food",
                EventDescription = "Enjoy the best of South African cuisine and wine tasting from local producers.",
                Location = "V&A Waterfront, Cape Town, Western Cape",
                MaxAttendees = 300,
                CurrentAttendees = 280
            });

            Events.Add(new Event
            {
                EventName = "Health and Wellness Camp",
                EventDate = new DateTime(2024, 5, 12),
                Category = "Health",
                EventDescription = "Free health screenings and wellness workshops for all residents.",
                Location = "Pretoria Central Park, Pretoria, Gauteng",
                MaxAttendees = 200,
                CurrentAttendees = 150
            });

            Events.Add(new Event
            {
                EventName = "Youth Day Celebration",
                EventDate = new DateTime(2024, 6, 16),
                Category = "Community",
                EventDescription = "Join us in celebrating South Africa's Youth Day with music, food, and fun activities.",
                Location = "Freedom Park, Johannesburg, Gauteng",
                MaxAttendees = 400,
                CurrentAttendees = 350
            });

            Events.Add(new Event
            {
                EventName = "Wildlife Photography Exhibition",
                EventDate = new DateTime(2024, 7, 10),
                Category = "Art",
                EventDescription = "A stunning exhibition of wildlife photography from across South Africa.",
                Location = "Kruger National Park, Mpumalanga",
                MaxAttendees = 200,
                CurrentAttendees = 180
            });

            Events.Add(new Event
            {
                EventName = "Heritage Day Festival",
                EventDate = new DateTime(2024, 9, 24),
                Category = "Culture",
                EventDescription = "Celebrate South African heritage with cultural performances, traditional food, and music.",
                Location = "UShaka Marine World, Durban, KwaZulu-Natal",
                MaxAttendees = 300,
                CurrentAttendees = 270
            });

            Events.Add(new Event
            {
                EventName = "Chris Brown Concert",
                EventDate = new DateTime(2024, 12, 14),
                Category = "Culture",
                EventDescription = "Celebrate South African concert with performances, traditional food, and music.",
                Location = "FNB Stadium, Johannesburg, KwaZulu-Natal",
                MaxAttendees = 300,
                CurrentAttendees = 270
            });

            Events.Add(new Event
            {
                EventName = "Spring Gardening Workshop",
                EventDate = new DateTime(2024, 10, 5),
                Category = "Community",
                EventDescription = "Learn the secrets of successful gardening with experts from all over South Africa.",
                Location = "Botanical Gardens, Pietermaritzburg, KwaZulu-Natal",
                MaxAttendees = 100,
                CurrentAttendees = 80
            });

            Events.Add(new Event
            {
                EventName = "Christmas Market",
                EventDate = new DateTime(2024, 12, 15),
                Category = "Community",
                EventDescription = "Join us for a festive Christmas market with local crafts, gifts, and food stalls.",
                Location = "Durban Beachfront, Durban, KwaZulu-Natal",
                MaxAttendees = 500,
                CurrentAttendees = 450
            });

            Events.Add(new Event
            {
                EventName = "Wild Coast Marathon",
                EventDate = new DateTime(2024, 11, 10),
                Category = "Sports",
                EventDescription = "An adventurous marathon along the Wild Coast of the Eastern Cape.",
                Location = "Wild Coast, Eastern Cape",
                MaxAttendees = 300,
                CurrentAttendees = 280
            });

            Events.Add(new Event
            {
                EventName = "Cultural Dance Competition",
                EventDate = new DateTime(2024, 8, 20),
                Category = "Culture",
                EventDescription = "A cultural dance competition showcasing local talent from Limpopo.",
                Location = "Polokwane Cultural Center, Limpopo",
                MaxAttendees = 200,
                CurrentAttendees = 180
            });

            Events.Add(new Event
            {
                EventName = "Stargazing Night",
                EventDate = new DateTime(2024, 9, 10),
                Category = "Science",
                EventDescription = "Enjoy a night of stargazing with astronomers from North West University.",
                Location = "Magaliesberg, North West",
                MaxAttendees = 150,
                CurrentAttendees = 100
            });

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedCategory = ((ComboBoxItem)cmbCategoryFilter.SelectedItem)?.Content.ToString();
            DateTime? selectedDate = datePicker.SelectedDate;

            var filtered = Events.AsQueryable();
            var recommended = new ObservableCollection<Event>(Events);

            if (selectedCategory != "All Events" && !string.IsNullOrEmpty(selectedCategory))
            {
                filtered = filtered.Where(e => e.Category.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase));
            }
            
            if (selectedDate.HasValue)
            {
                filtered = filtered.Where(e => e.EventDate.Date == selectedDate.Value.Date);
            }

            //Search Filter
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(e =>
                    e.EventName.ToLower().Contains(searchText) ||
                    e.EventDescription.ToLower().Contains(searchText) ||
                    e.Location.ToLower().Contains(searchText));
            }

            // Update Filtered Events
            FilteredEvents.Clear();
            foreach (var evt in filtered.OrderBy(e => e.EventDate))
            {
                FilteredEvents.Add(evt);
                recommended.Remove(evt); 
            }

            UpdateRecommendations(recommended);
        }

        private void UpdateRecommendations(ObservableCollection<Event> eventsToRecommend)
        {
            RecommendedEvents.Clear();
            var recommended = eventsToRecommend.OrderByDescending(e => e.CurrentAttendees).Take(5);
            foreach (var evt in recommended)
            {
                RecommendedEvents.Add(evt);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            datePicker.SelectedDate = null;
            cmbCategoryFilter.SelectedIndex = 0; //reset
            ApplyFilters();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedEvent = (Event)button.DataContext;

            MessageBox.Show($"Event Details:\n\nName: {selectedEvent.EventName}\nDate: {selectedEvent.EventDate:MMMM dd, yyyy}\nLocation: {selectedEvent.Location}\nDescription: {selectedEvent.EventDescription}\nAttendees: {selectedEvent.CurrentAttendees}/{selectedEvent.MaxAttendees}",
                "Event Details",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public class Event
        {
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public string Category { get; set; }
            public string EventDescription { get; set; }
            public string Location { get; set; }
            public int MaxAttendees { get; set; }
            public int CurrentAttendees { get; set; }
        }
    }
}
