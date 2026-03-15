using FoodStreetGuide.Data;
using FoodStreetGuide.Models;
using System.Collections.Generic;

namespace FoodStreetGuide.Pages
{
    [QueryProperty("PlaceId", "placeId")]
    public partial class MarketPage : ContentPage
    {
        public string PlaceId
        {
            set
            {
                LoadPlace(value);
            }
        }

        public MarketPage()
        {
            InitializeComponent();
        }

        void LoadPlace(string id)
        {
            var place = PlaceData.GetPlaceById(id);
            if (place == null) return;

            MarketName.Text = place.GetName(System.Globalization.CultureInfo.CurrentCulture.Name);
            MarketAddress.Text = place.Address;
            MarketHours.Text = $"Hours: {place.OpeningHours}";
            MarketDescription.Text = place.GetDescription(System.Globalization.CultureInfo.CurrentCulture.Name);

            if (!string.IsNullOrWhiteSpace(place.ImageUrl))
                HeaderImage.Source = place.ImageUrl;

            // For demo: show some sample stalls inside the market
            var stalls = new List<object>
            {
                new { Name = "Quầy Phở Bò", Description = "Phở bò truyền thống, nước dùng thơm" },
                new { Name = "Quầy Bánh Mì", Description = "Bánh mì nóng giòn, heo quay" },
                new { Name = "Quầy Chè", Description = "Chè thập cẩm mát lạnh" }
            };

            StallsView.ItemsSource = stalls;
        }
    }
}
