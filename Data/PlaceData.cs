using System.Collections.Generic;
using FoodStreetGuide.Models;

namespace FoodStreetGuide.Data
{
    public static class PlaceData
    {
        // For the mobile app we only show the main market "Chợ Vĩnh Khách"
        public static List<FoodPlace> GetPlaces()
        {
            return new List<FoodPlace>
            {
                new FoodPlace
                {
                    Id = "vinh-khach-market",
                    Category = "Chợ",
                    Address = "Chợ Ẩm Thực Vĩnh Khách, Thành phố",
                    Latitude = null,
                    Longitude = null,
                    ImageUrl = "images/market.jpg",
                    OpeningHours = "06:00 - 22:00",
                    Names = new Dictionary<string,string>
                    {
                        { "vi-VN", "Chợ Vĩnh Khách" },
                        { "en-US", "Vinh Khach Market" }
                    },
                    Descriptions = new Dictionary<string,string>
                    {
                        { "vi-VN", "Chợ ẩm thực nổi tiếng tại Vĩnh Khách — nơi tập trung nhiều quầy hàng địa phương, món ăn đặc sắc và trải nghiệm văn hoá ẩm thực." },
                        { "en-US", "Vinh Khach food market — a lively place full of local stalls, signature dishes and culinary culture." }
                    }
                }
            };
        }

        public static FoodPlace? GetPlaceById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return GetPlaces().FirstOrDefault(p => p.Id == id);
        }
    }
}
