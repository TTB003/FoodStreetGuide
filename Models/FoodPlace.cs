using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodStreetGuide.Models
{
    public class FoodPlace
    {
        public string Id { get; set; }

        // Localized names keyed by language code (eg "vi-VN", "en-US")
        public Dictionary<string, string> Names { get; set; } = new();

        // Localized descriptions keyed by language code
        public Dictionary<string, string> Descriptions { get; set; } = new();

        public string Category { get; set; }

        public string Address { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ImageUrl { get; set; }

        public string OpeningHours { get; set; }

        // Return a localized name or fallback to any available name
        public string GetName(string locale)
        {
            if (string.IsNullOrWhiteSpace(locale)) locale = "vi-VN";
            if (Names == null || Names.Count == 0) return string.Empty;

            if (Names.TryGetValue(locale, out var n) && !string.IsNullOrWhiteSpace(n)) return n;

            // Try language-only match (eg "en" from "en-US")
            var lang = locale.Split('-').FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(lang))
            {
                var key = Names.Keys.FirstOrDefault(k => k.StartsWith(lang, StringComparison.OrdinalIgnoreCase));
                if (key != null) return Names[key];
            }

            // fallback to first available
            return Names.Values.FirstOrDefault() ?? string.Empty;
        }

        // Return a localized description or fallback
        public string GetDescription(string locale)
        {
            if (string.IsNullOrWhiteSpace(locale)) locale = "vi-VN";
            if (Descriptions == null || Descriptions.Count == 0) return string.Empty;

            if (Descriptions.TryGetValue(locale, out var d) && !string.IsNullOrWhiteSpace(d)) return d;

            var lang = locale.Split('-').FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(lang))
            {
                var key = Descriptions.Keys.FirstOrDefault(k => k.StartsWith(lang, StringComparison.OrdinalIgnoreCase));
                if (key != null) return Descriptions[key];
            }

            return Descriptions.Values.FirstOrDefault() ?? string.Empty;
        }
    }
}
