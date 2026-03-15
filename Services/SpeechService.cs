using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FoodStreetGuide.Services
{
    public interface ISpeechService
    {
        Task SpeakAsync(string text, string locale = "vi-VN");
        Task StopAsync();
    }

    // Simple cross-platform stub implementation. Replace with platform text-to-speech
    // (Microsoft.Maui.ApplicationModel.TextToSpeech) when integrating into UI.
    public class SpeechService : ISpeechService
    {
        public Task SpeakAsync(string text, string locale = "vi-VN")
        {
            if (string.IsNullOrWhiteSpace(text)) return Task.CompletedTask;

            // For now, just write to debug output. Replace with actual TTS implementation.
            Debug.WriteLine($"[SpeechService] Speak ({locale}): {text}");
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            Debug.WriteLine("[SpeechService] Stop");
            return Task.CompletedTask;
        }
    }
}
