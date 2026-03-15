using FoodStreetGuide.Data;
using FoodStreetGuide.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace FoodStreetGuide
{
    public partial class MainPage : ContentPage
    {

        class PlaceDisplay
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
        }

        readonly ObservableCollection<PlaceDisplay> Places = new();
        readonly ISpeechService speech = new SpeechService();

        public MainPage()
        {
            InitializeComponent();

            // Load places and map to display model
            var list = PlaceData.GetPlaces();
            foreach (var p in list)
            {
                Places.Add(new PlaceDisplay
                {
                    Id = p.Id,
                    Name = p.GetName(System.Globalization.CultureInfo.CurrentCulture.Name),
                    Description = p.GetDescription(System.Globalization.CultureInfo.CurrentCulture.Name),
                    ImageUrl = p.ImageUrl
                });
            }

            PlacesView.ItemsSource = Places;
        }

        private async void OnSpeakClicked(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is string text)
            {
                await speech.SpeakAsync(text, System.Globalization.CultureInfo.CurrentCulture.Name);
            }
        }

        private async void OnPlaceSelected(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as PlaceDisplay;
            if (item == null) return;

            // Navigate to market detail page
            await Shell.Current.GoToAsync($"marketdetail?placeId={item.Id}");

            // clear selection
            if (sender is CollectionView cv)
                cv.SelectedItem = null;
        }

        // Counter removed for mobile layout. Add interaction handlers here if needed.
    }
}
